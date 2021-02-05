﻿using System.Runtime.InteropServices;
using GameOffsets.Native;

namespace GameOffsets
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct TerrainData
    {
        [FieldOffset(0x18)] public long NumCols;
        [FieldOffset(0x20)] public long NumRows;
        [FieldOffset(0xB0)] public NativePtrArray LayerMelee;
        [FieldOffset(0xC8)] public NativePtrArray LayerRanged;
        [FieldOffset(0xE0)] public int BytesPerRow;
    }
}
