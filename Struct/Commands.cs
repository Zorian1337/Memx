using Memx.Extensions;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Memx.Struct;


// allows us to create dynamic functions in one place and change the return type
public class CommandAction<T>
{
    public CommandAction(Func<Socket, byte[], T?> ActionReturn) => this.ActionReturn = ActionReturn;
    public Func<Socket, byte[], T?> ActionReturn { get; set; }
    public T? Invoke(Socket socket, byte[] payload) => ActionReturn.Invoke(socket, payload);
}

public class Commands
{


    public static Dictionary<Command, CommandAction<string>> CommandRegisteryString = new Dictionary<Command, CommandAction<string>>()
    {
        [Command.CMD_BRANDING] = new CommandAction<string>((Connection, payload) =>
        {
            byte[] binaryPacket = new Packet(Command.CMD_BRANDING, payload).ToBinary();

            int SentBytes = Connection.SendAll(binaryPacket);

            if (SentBytes > 0)
            {
                byte[] ResponseLength = Connection.ReadExact(4);
                uint Length = BitConverter.ToUInt32(ResponseLength, 0);

                byte[] StringResponse = Connection.ReadExact((int)Length);
                if (StringResponse.Length <= 0) return String.Empty;
                else return Encoding.UTF8.GetString(StringResponse);
            }

            return String.Empty;
        }),
    };


    

    public static bool TryGetCommandSuccessLength(TcpClient Connection, Command Command, byte[] Payload, out int Result, Response ExpectedResponse = Response.CMD_SUCCESS)
    {
        Result = -1;

        if (Connection is null || !Connection.Connected) return false;

        Result = GetCommandSuccessLength(Connection, Command, Payload, ExpectedResponse);

        if (Result == -1) return false;
        else return true;
    }

    //public static byte[] GetCommandSucessArray(TcpClient Connection, Command Command, byte[] Payload)
    //{

    //}

    /// <summary>
    /// Gets the status result of a command and fetches the length param if successful
    /// </summary>
    /// <param name="Connection"></param>
    /// <param name="Command"></param>
    /// <param name="Payload"></param>
    /// <returns>-1 on fail</returns>
    public static int GetCommandSuccessLength(TcpClient Connection, Command Command, byte[] Payload, Response ExpectedResponse = Response.CMD_SUCCESS)
    {

        if (Connection is null || !Connection.Connected) return -1;
        byte[] binaryPayload = new Packet(Command, Payload).ToBinary();

        int SentBytes = Connection.Client.SendAll(binaryPayload);

        if (SentBytes > 0)
        {
            byte[] received = Connection.Client.ReadExact(8);
            byte[] Status = received[..4];
            byte[] Length = received[4..8];

            uint status = Status.Bitswap32();

            if (status == (uint)ExpectedResponse) return (int)BinaryPrimitives.ReadUInt32LittleEndian(Length);
            else return -1;
        }

        return -1;
    }
}
