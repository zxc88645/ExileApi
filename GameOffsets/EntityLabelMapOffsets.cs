﻿using System.Runtime.InteropServices;

namespace GameOffsets
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct EntityLabelMapOffsets
    {
        [FieldOffset(0x2F0)] public long EntityLabelMap;
    }
}
