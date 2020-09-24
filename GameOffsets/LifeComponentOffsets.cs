using System.Runtime.InteropServices;
using GameOffsets.Native;

namespace GameOffsets
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct LifeComponentOffsets
    {
        [FieldOffset(0x8)] public long Owner;
        [FieldOffset(0x254)] public int MaxHP;  //最大生命k
        [FieldOffset(0x25C)] public int CurHP;  //目前生命k
        [FieldOffset(0x190)] public float Regen;    //生命回復????
        [FieldOffset(0x258)] public int ReservedFlatHP; //生命保留值k
        [FieldOffset(0x260)] public int ReservedPercentHP;  //生命保留百分比k
        [FieldOffset(0x1BC)] public int MaxMana;    //最大魔力
        [FieldOffset(0x1C4)] public int CurMana;    //目前魔力 
        [FieldOffset(0x1B8)] public float ManaRegen;    //魔法回復
        [FieldOffset(0x1C0)] public int ReservedFlatMana;   //魔力保留值k
        [FieldOffset(0x1C8)] public int ReservedPercentMana;    //魔力保留百分比k
        [FieldOffset(0x1F4)] public int MaxES;  //最大能量戶頓
        [FieldOffset(0x1FC)] public int CurES;  //目前能量戶頓
        [FieldOffset(0x180)] public NativePtrArray Buffs;
    }
}
