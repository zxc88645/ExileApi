using System.Runtime.InteropServices;
using SharpDX;

namespace GameOffsets
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct ActionWrapperOffsets
    {
        [FieldOffset(0x78)] public Vector2 Destination;
        [FieldOffset(0x168)] public long Target;
        [FieldOffset(0x150)] public long Skill;
    }
}
