using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Memx.Struct;

public record DiscoveredConsole(string IP);

public class Discover
{
    // use detect local consoles to maintain connection check
    // if console is no longer detected then its most likely offline for our tcp client

    public static byte[] DiscoverMagic = { 0xAA, 0xAA, 0xFF, 0xFF };
    public static bool IsWatching = false;
    public static UdpClient Client { get; set; }
    public static CancellationTokenSource cancellationTokenSource { get; set; }

    public static HashSet<DiscoveredConsole> Discovered = new HashSet<DiscoveredConsole>();

    public static void DetectLocalConsoles()
    {


        IPAddress localIP = IPAddress.Parse("192.168.68.40");

        // only one instance of this watcher is needed
        if (IsWatching) return;

        if(Client is null)
        {
            Client = new UdpClient();
            Client.Client.ReceiveTimeout = 500;
            Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            Client.Client.Bind(new IPEndPoint(localIP, 1010));
            cancellationTokenSource = new CancellationTokenSource();
        }


        if (!IsWatching)
        {
            IsWatching = true;
            Client.EnableBroadcast = true;

            Task.Run(async () =>
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {

                    try
                    {
                        int Sent = Client.Send(DiscoverMagic, DiscoverMagic.Length, new IPEndPoint(IPAddress.Broadcast, 1010));
                        //MessageBox.Show(Sent.ToString());

                        // init blank EndPoint for our console address 
                        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0); //make auto discover later
                        byte[] buffer = Client.Receive(ref remoteEP);
                        Console.WriteLine(buffer.Length);

                        if (buffer.Length > 0 && !remoteEP.Address.Equals(localIP) && BitConverter.ToUInt32(buffer, 0) == 0xFFFFAAAA) //
                        {
                            //MessageBox.Show($"Found PS5 at {remoteEP.Address}");
                            Discovered.Add(new DiscoveredConsole(remoteEP.Address.ToString()));
                        }
                    }
                    catch (SocketException SEx) { MessageBox.Show(SEx.ToString()); }

                    await Task.Delay(new Random().Next(1000, 5000));
                }

                IsWatching = false;
            });
        }
    }


}
