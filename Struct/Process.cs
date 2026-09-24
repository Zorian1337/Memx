using System;
using System.Collections.Generic;
using System.Text;

namespace Memx.Struct;

[Flags]
public enum MemoryProtection : ushort
{
    None = 0x0,
    Read = 0x1,
    Write = 0x2,
    Execute = 0x4,
}

public record ProcessList(string name, uint pid);
public record VM_Entry(string name, ulong start, ulong end, ulong offset, MemoryProtection prot);