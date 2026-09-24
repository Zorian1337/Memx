using Memx.Struct;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Memx.Extensions;

public static class SocketExtensions
{
    private static readonly ConcurrentDictionary<Socket, NetworkStream> _streams = new();
    public static byte[] ReadExact(this Socket Connection, int Length)
    {
        NetworkStream stream = null;
        if (!_streams.TryGetValue(Connection, out stream)) {
            stream = new NetworkStream(Connection, ownsSocket: false);
            _streams.GetOrAdd(Connection, stream);
        }

        byte[] buffer = new byte[Length];
        int off = 0;

        

        while (off < Length)
        {
            int n = stream.Read(buffer, off, Length - off);

            if (n <= 0) throw new IOException($"Connection closed: read {off}/{Length} bytes.");
            off += n;
        }

        return buffer;
    }

    public static int SendAll(this Socket Connection, byte[] data)
    {
        int offset = 0;
        while (offset < data.Length)
        {
            int n = Connection.Send(data, offset, data.Length - offset, SocketFlags.None);
            if (n <= 0) return -1;
            offset += n;
        }

        return offset;
    }
}
