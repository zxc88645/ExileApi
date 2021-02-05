using System;
using ExileCore.PoEMemory.MemoryObjects;
using SharpDX;

namespace ExileCore
{
    public sealed class AreaInstance
    {
        public static uint CurrentHash;

        public AreaInstance(AreaTemplate area, uint hash, int realLevel)
        {
            Area = area;
            Hash = hash;
            RealLevel = realLevel;
            Name = area.Name;
            Act = area.Act;
            IsTown = area.IsTown || area.RawName.Equals("HeistHub");
            IsHideout = Name.Contains("Hideout") && !Name.Contains("Syndicate Hideout");
            IsHideout = (Name.Contains("�è��B") && !Name.Contains("�K���è��B")) || IsHideout;
            HasWaypoint = area.HasWaypoint || IsHideout;
        }

        public int RealLevel { get; }
        public string Name { get; }
        public int Act { get; }
        public bool IsTown { get; }
        public bool IsHideout { get; }
        public bool HasWaypoint { get; }
        public uint Hash { get; }
        public AreaTemplate Area { get; }
        public string DisplayName => string.Concat(Name, " (", RealLevel, ")");
        public DateTime TimeEntered { get; } = DateTime.UtcNow;
        public Color AreaColorName { get; set; } = Color.Aqua;

        public override string ToString()
        {
            return $"{Name} ({RealLevel}) #{Hash}";
        }

        public static string GetTimeString(TimeSpan timeSpent)
        {
            var allsec = (int)timeSpent.TotalSeconds;
            var secs = allsec % 60;
            var mins = allsec / 60;
            var hours = mins / 60;
            mins = mins % 60;
            return string.Format(hours > 0 ? "{0}:{1:00}:{2:00}" : "{1}:{2:00}", hours, mins, secs);
        }
    }
}
