using Memx.Extensions;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Memx.Struct;

public class Client
{
    public string IP { get; set; }
    public int Port { get; set; }

    public TcpClient? Connection { get; set; }
    
    public CancellationTokenSource cancellationTokenSource { get; set; }

    public UdpClient UDP { get; set; }

    public bool Connect(string IP = "192.168.68.7", int Port = 744)
    {
        // refresh connection
        if (Connection?.Connected == true)
        {
            MessageBox.Show("PS5Dbg already connected -> Disconnecting..");
            Connection.Close();
        }

        // init null client
        if (Connection is null)
        {
            Connection = new TcpClient();
            cancellationTokenSource = new CancellationTokenSource();
        }

        if (IPAddress.TryParse(IP, out IPAddress? Address))
        {

            try
            {
                Connection.Connect(Address, Port);

                if (Connection.Connected) return true;
                else return false;
            }
            catch(Exception Ex) { MessageBox.Show(Ex.ToString()); }
        }

        return false;
    }


    public void Authenticate(uint flags = 0xFFFFFFFF)
    {
        if (Connection is null || !Connection.Connected) return;

        byte[] Payload = new byte[8];

        BinaryPrimitives.WriteUInt32LittleEndian(Payload, Packet.AuthMagic);
        BinaryPrimitives.WriteUInt32LittleEndian(Payload, flags);
    }




    
    public bool GetProcessMap(uint pid, out List<VM_Entry> VMEntries)
    {
        VMEntries = new List<VM_Entry>();
        if (Connection is null || !Connection.Connected) return false;

        byte[] Payload = new byte[4];
        BinaryPrimitives.WriteUInt32LittleEndian(Payload, pid);

        if(Commands.TryGetCommandSuccessLength(Connection, Command.CMD_PROC_MAPS, Payload, out int Length))
        {
            int dataRange = 58;
            int ExpectedLength = Length * dataRange;

            Debug.WriteLine($"Status: Sucessful - Length: {Length} - VMEntryLength: {ExpectedLength}\n");

            byte[] VMEntryArray = Connection.Client.ReadExact(ExpectedLength);

            // increment by 58 each loop to grab names and pid until completion
            for (int i = 0; i < ExpectedLength; i += dataRange)
            {
                int offset = i;

                int eoffset = offset + 32;
                byte[] nameArray = VMEntryArray[offset..eoffset];
                //Debug.WriteLine($"first: {offset} - {eoffset}\n");
                offset = eoffset;
                eoffset += 8;
                byte[] startArray = VMEntryArray[offset..eoffset];

                offset = eoffset;
                eoffset += 8;
                byte[] endArray = VMEntryArray[offset..eoffset];

                offset = eoffset;
                eoffset += 8;
                byte[] offsetArray = VMEntryArray[offset..eoffset];

                offset = eoffset;
                eoffset += 2;
                byte[] protArray = VMEntryArray[offset..eoffset];

                string Name = nameArray.ToUTF8String().TrimEnd('\0', ' ');
                ulong Start = BinaryPrimitives.ReadUInt64LittleEndian(startArray);
                ulong End = BinaryPrimitives.ReadUInt64LittleEndian(endArray);
                ulong Offset = BinaryPrimitives.ReadUInt64LittleEndian(offsetArray);
                ushort Prot = BinaryPrimitives.ReadUInt16LittleEndian(protArray);

                VMEntries.Add(new VM_Entry(Name, Start, End, Offset, (MemoryProtection)Prot));
                Debug.WriteLine($"Entry = [{Name}, {Start}, {End}, {Offset}, {Prot}]");
            }

            return true;
        }

        return false;
    }

    public record PacketReadRequest(uint pid, ulong address, uint length)
    {
        public byte[] ToBinary()
        {
            byte[] buffer = new byte[16];

            BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(0), pid);
            BinaryPrimitives.WriteUInt64LittleEndian(buffer.AsSpan(4), address);
            BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(12), length);
            return buffer;
        }
    }

    public byte[] Read(uint pid, uint Address, uint Length)
    {
        if (Connection is null || !Connection.Connected) return Array.Empty<byte>();

        PacketReadRequest request = new PacketReadRequest(pid, Address, Length);

        byte[] binaryPayload = new Packet(Command.CMD_PROC_READ, request.ToBinary()).ToBinary();
        int SentBytes = Connection.Client.SendAll(binaryPayload);

        if (SentBytes > 0)
        {
            int EOL = 4 + (int)Length;
            byte[] received = Connection.Client.ReadExact(EOL); //was 8 but needs to be first 4 + data length
            byte[] Status = received[..4];

            byte[] AOB = received[4..EOL];

            uint status = Status.Bitswap32();

            if (status == (uint)Response.CMD_SUCCESS) return AOB;
            else return Array.Empty<byte>();
        }

        return Array.Empty<byte>();
    }

    
    public bool GetProcessList(out List<ProcessList> ProcessList)
    {
        ProcessList = new List<ProcessList>();

        if (Connection is null || !Connection.Connected) return false;
        byte[] binaryPayload = new Packet(Command.CMD_PROC_LIST, null).ToBinary();

        int SentBytes = Connection.Client.SendAll(binaryPayload);

        if (SentBytes > 0)
        {
            byte[] received = Connection.Client.ReadExact(8);
            byte[] Status = received[..4];
            byte[] ProcessAmount = received[4..8];

            uint status = Status.Bitswap32();
            if (status == (uint)Response.CMD_SUCCESS)
            {
                uint ProcessCounter = BinaryPrimitives.ReadUInt32LittleEndian(ProcessAmount);
                Debug.WriteLine($"Status: {status} - ProcessAmount: {ProcessCounter}\n");

                int bytesForProcList = (int)ProcessCounter * 36;
                byte[] processListArray = Connection.Client.ReadExact(bytesForProcList);

                // increment by 36 each loop to grab names and pid until completion
                for (int i = 0; i < bytesForProcList; i += 36)
                {
                    int offset = i;

                    int eoffset = offset + 32;
                    byte[] nameArray = processListArray[offset..eoffset];
                    //Debug.WriteLine($"first: {offset} - {eoffset}\n");
                    offset = eoffset;
                    eoffset += 4;
                    byte[] pidArray = processListArray[offset..eoffset];

                    string name = nameArray.ToUTF8String().TrimEnd('\0', ' ');
                    uint pid = BinaryPrimitives.ReadUInt32LittleEndian(pidArray);
                    ProcessList.Add(new Struct.ProcessList(name, pid));
                    Debug.WriteLine($"[{name}:{pid}]");
                }

                return true;
            }
            else if (status == (uint)Response.CMD_ERROR) return false;
        }

        return false;
    }


    // need to figure out how to dynamically set the return type while inside the function
    public bool SendCommand(Command Command, byte[] Payload)
    {
        if (Connection is null || !Connection.Connected) return false;
        if (Commands.CommandRegisteryString.TryGetValue(Command, out CommandAction<string>? Action))
        {
            string? Reult = Action.Invoke(Connection.Client, Payload);

            Debug.WriteLine($"Received: {Reult}\n");
        }
        else
        {

        }

        return false;
        //byte[] Command = new Packet((uint)cmd, payload).ToBinary();

        //string SIG = "";
        //foreach (var b in Command)
        //{
        //    SIG += $"{b.ToString("X2")} ";
        //}

        //Debug.WriteLine($"CommandPacket: {SIG}");

        //int SentBytes = Connection.Client.Send(Command);
        //if (SentBytes > 0)
        //{
        //    // wait for response after valid send

        //    if (Packet.InformationCommands.Contains(cmd)){
        //        byte[] ResponseLength = Connection.Client.ReadExact(4);

        //        uint Length = BitConverter.ToUInt32(ResponseLength, 0);

        //        Debug.WriteLine($"ResponseLength: {Length}");

        //        byte[] Response = Connection.Client.ReadExact((int)Length);

        //    }



        //    //byte[] Response = Connection.Client.ReadExact(4);

        //    //string Received = "";
        //    //foreach (var b in Response)
        //    //{
        //    //    Received += b.ToString("X2");
        //    //}

        //    //Debug.WriteLine($"Received: {Received}");








        //    return true;
        //}
        //else return false;
    }

    public async Task<bool> ConnectAsync(string IP = "192.168.68.7", int Port = 744)
    {
        Connection = new TcpClient();

        if(IPAddress.TryParse(IP, out IPAddress? Address))
        {
            MessageBox.Show("connecting");
            await Connection.ConnectAsync(Address, Port);
            MessageBox.Show("connected");
            //_ = Task.Run(async () =>
            //{
            //    while (Client.Connected)
            //    {
            //        var stream = Client.GetStream();

            //        string Received = "";
            //        while (stream.Position < stream.Length)
            //        {
            //            //stream.read
            //            Received += stream.ReadByte().ToString("X2");
            //        }
            //        MessageBox.Show(Received);


            //        await Task.Delay(10);
            //    }
            //});



            return true;
        }


        return false;
    }


}
