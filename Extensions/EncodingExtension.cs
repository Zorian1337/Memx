using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Memx.Extensions;

public static class EncodingExtension
{
    public static uint Bitswap32(this uint x) => ((x >> 1) & 0x55555555u) | ((x << 1) & 0xAAAAAAAAu);
    public static uint Bitswap32(this byte[] data) => BitConverter.ToUInt32(data).Bitswap32();
    public static string ToHex(this byte[] data, char sep = ' ') => string.Join(sep, data.Select(x => x.ToString("X2")));
    public static string ToUTF8String(this byte[] data)
    {
        if (data is null || data.Length == 0) return string.Empty;

        int nul = Array.IndexOf(data, (byte)0);
        int len = nul >= 0 ? nul : data.Length;

        return Encoding.UTF8.GetString(data, 0, len);
    }
}
