﻿using ExileCore.PoEMemory.FilesInMemory;

namespace ExileCore.PoEMemory.MemoryObjects.Heist
{
    public class HeistJobRecord : RemoteMemoryObject
    {
        public string Id => M.ReadStringU(M.Read<long>(Address + 0x00));
        public string Name => M.ReadStringU(M.Read<long>(Address + 0x08));
        public string RequiredSkillIcon => M.ReadStringU(M.Read<long>(Address + 0x10));
        public string SkillIcon => M.ReadStringU(M.Read<long>(Address + 0x18));
        //public float Value20 => M.Read<float>(Address + 0x20);
        //public int Value24 => M.Read<int>(Address + 0x24);
        public string MapIcon => M.ReadStringU(M.Read<long>(Address + 0x28));

        private long _LevelStatsKey => M.Read<long>(Address + 0x38);
        private long _AlertStatsKey => M.Read<long>(Address + 0x48);
        private long _AlarmStatsKey => M.Read<long>(Address + 0x58);
        private long _CostStatsKey => M.Read<long>(Address + 0x68);
        private long _ExperienceGainStatsKey => M.Read<long>(Address + 0x78);

        public StatsDat.StatRecord LevelStat => TheGame.Files.Stats.GetStatByAddress(_LevelStatsKey);
        public StatsDat.StatRecord AlertStat => TheGame.Files.Stats.GetStatByAddress(_AlertStatsKey);
        public StatsDat.StatRecord AlarmStat => TheGame.Files.Stats.GetStatByAddress(_AlarmStatsKey);
        public StatsDat.StatRecord CostStat => TheGame.Files.Stats.GetStatByAddress(_CostStatsKey);
        public StatsDat.StatRecord ExperienceGainStat => TheGame.Files.Stats.GetStatByAddress(_ExperienceGainStatsKey);

        public override string ToString()
        {
            return Name;
        }
    }
}