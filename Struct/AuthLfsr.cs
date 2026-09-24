using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Memx.Struct;

public sealed class AuthLfsr
{
    private uint _s1, _s2, _s3, _s4;

    public void SetState(uint a, uint b, uint c, uint d)
    {
        _s1 = a; _s2 = b; _s3 = c; _s4 = d;
    }

    public uint Next()
    {
        uint s1 = _s1, s2 = _s2, s3 = _s3, s4 = _s4;

        s1 = ((s1 << 18) & 0xFFF80000u) ^ ((s1 ^ (s1 << 6)) >> 13);
        s2 = ((s2 << 2) & 0xFFFFFFE0u) ^ ((s2 ^ (s2 << 2)) >> 27);
        s3 = ((s3 << 7) & 0xFFFFF800u) ^ ((s3 ^ (s3 << 13)) >> 21);
        s4 = ((s4 << 13) & 0xFFF00000u) ^ ((s4 ^ (s4 << 3)) >> 12);

        _s1 = s1; _s2 = s2; _s3 = s3; _s4 = s4;
        return s1 ^ s2 ^ s3 ^ s4;
    }

    public byte[] GenerateKeystream(int length = 256)
    {
        byte[] output = new byte[length];
        SetState(200, 300, 400, 500);
        for (int i = 0; i < length; i++)
            output[i] = (byte)Next();   
        return output;
    }

    public static byte[] CompleteChallenge(byte[] challenge)
    {
        var lfsr = new AuthLfsr();
        byte[] keystream = lfsr.GenerateKeystream(256);

        byte[] response = new byte[challenge.Length];
        for (int i = 0; i < challenge.Length; i++)
            response[i] = (byte)(challenge[i] ^ keystream[i]);

        return response;
    }
}