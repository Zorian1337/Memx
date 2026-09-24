using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Memx.Struct;


//public const uint BroadcastMagic = 0xFFFFAAAA;


public enum Response: uint
{
    CMD_SUCCESS = 0x40000000,
    CMD_ERROR = 0xF0000002,
    CMD_DATA_NULL = 0xF0000003,
    CMD_ALREADY_DEBUG = 0xF0000008,
    CMD_INVALID_INDEX = 0xF000000A
}

public enum Command: uint
{
    // info n ping
    CMD_VERSION = 0xBD000001,
    CMD_FW_VERSION = 0xBD000500,
    CMD_BRANDING = 0xBD000501,
    CMD_PLATFORM_ID = 0xBD000502,
    CMD_PROC_NOP = 0xBDAACC06, // response with CMD_SUCCESS

    //  process commands

    CMD_PROC_LIST = 0xBDAA0001,
    CMD_PROC_READ = 0xBDAA0002,
    CMD_PROC_WRITE = 0xBDAA0003,
    CMD_PROC_WRITE_MULTI_HANDLE = 0xBDAACC04,

    CMD_PROC_MAPS = 0xBDAA0004,
}





public class Packet
{
    public static uint AuthMagic = 0xBB40E64D;

    public Packet() { }

    public Packet(Command cmd, byte[] payload)
    {
        this.cmd = (uint)cmd;
        Payload = payload;

        if (Payload?.Length >= 0) this.datalen = (uint)Payload?.Length;
        else this.datalen = 0;
    }

    public Packet(uint cmd, byte[] payload)
    {
        this.cmd = cmd;
        Payload = payload;

        if (Payload?.Length >= 0) this.datalen = (uint)Payload?.Length;
        else this.datalen = 0;
    }

    public uint magic = 0xFFAABBCC;
    public uint cmd { get; set; }
    public uint datalen { get; set; }

    public byte[] Payload { get; set; }

    // anything after is extra

    public static readonly HashSet<Command> InformationCommands = new()
    {
        Command.CMD_VERSION,
        Command.CMD_FW_VERSION,
        Command.CMD_BRANDING,
        Command.CMD_PLATFORM_ID,
        Command.CMD_PROC_NOP,
    };


    public byte[] ToBinary()
    {
        byte[] buffer = new byte[12 + datalen];

        BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(0), magic);
        BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(4), cmd);
        BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(8), datalen);

        if (Payload?.Length > 0) Payload.CopyTo(buffer, 12);
        return buffer;
    }
}
