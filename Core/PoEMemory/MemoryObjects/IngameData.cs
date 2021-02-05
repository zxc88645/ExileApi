using System;
using System.Collections.Generic;
using ExileCore.Shared.Cache;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using GameOffsets;
using GameOffsets.Native;

namespace ExileCore.PoEMemory.MemoryObjects
{
    public class IngameData : RemoteMemoryObject
    {
        private readonly CachedValue<IngameDataOffsets> _IngameData;
        private readonly CachedValue<AreaTemplate> _CurrentArea;
        private readonly CachedValue<WorldArea> _CurrentWorldArea;
        private readonly CachedValue<long> _EntitiesCount;
        private readonly CachedValue<Entity> _LocalPlayer;
        private readonly Dictionary<GameStat, int> _MapStats = new Dictionary<GameStat, int>();
        private EntityList _EntityList { get; set; }
        private NativePtrArray _CacheStats { get; set; }

        public IngameData()
        {
            _IngameData = new AreaCache<IngameDataOffsets>(() => M.Read<IngameDataOffsets>(Address));
            _LocalPlayer = new AreaCache<Entity>(() => GetObject<Entity>(_IngameData.Value.LocalPlayer));
            _CurrentArea = new AreaCache<AreaTemplate>(() => GetObject<AreaTemplate>(_IngameData.Value.CurrentArea));
            _CurrentWorldArea = new AreaCache<WorldArea>(() => TheGame.Files.WorldAreas.GetByAddress(CurrentArea.Address));
            var offset = Extensions.GetOffset<IngameDataOffsets>(nameof(IngameDataOffsets.EntitiesCount));
            _EntitiesCount = new FrameCache<long>(() => M.Read<long>(Address + offset));
        }

        public IngameDataOffsets DataStruct => _IngameData.Value;
        public long EntitiesCount => _EntitiesCount.Value;
        public AreaTemplate CurrentArea => _CurrentArea.Value;
        public WorldArea CurrentWorldArea => _CurrentWorldArea.Value;
        public int CurrentAreaLevel => _IngameData.Value.CurrentAreaLevel;
        public uint CurrentAreaHash => _IngameData.Value.CurrentAreaHash;
        public Entity LocalPlayer => _LocalPlayer.Value;
        public long EntitiesTest => DataStruct.EntityList;
        public EntityList EntityList => _EntityList ?? (_EntityList = GetObject<EntityList>(DataStruct.EntityList));
        private long LabDataPtr => _IngameData.Value.LabDataPtr;
        public LabyrinthData LabyrinthData => LabDataPtr == 0 ? null : GetObject<LabyrinthData>(LabDataPtr);
        public TerrainData Terrain => _IngameData.Value.Terrain;

        public Dictionary<GameStat, int> MapStats
        {
            get
            {
                if (_CacheStats.Equals(_IngameData.Value.MapStats)) return _MapStats;
                _MapStats.Clear();
                var statPtrStart = _IngameData.Value.MapStats.First;
                var statPtrEnd = _IngameData.Value.MapStats.Last;
                var totalStats = (int) (statPtrEnd - statPtrStart);

                if (totalStats / 8 > 200)
                    return null;

                var bytes = M.ReadMem(statPtrStart, totalStats);

                for (var i = 0; i < bytes.Length; i += 8)
                {
                    var key = BitConverter.ToInt32(bytes, i);
                    var value = BitConverter.ToInt32(bytes, i + 0x04);
                    _MapStats[(GameStat) key] = value;
                }

                _CacheStats = _IngameData.Value.MapStats;
                return _MapStats;
            }
        }

        public IList<PortalObject> TownPortals
        {
            get
            {
                var statPtrStart = M.Read<long>(Address + 0x4B4);
                var statPtrEnd = M.Read<long>(Address + 0x4BC);

                return M.ReadStructsArray<PortalObject>(statPtrStart, statPtrEnd, PortalObject.StructSize, TheGame);
            }
        }

        public class PortalObject : RemoteMemoryObject
        {
            public const int StructSize = 0x38;
            public string PlayerOwner => NativeStringReader.ReadString(Address + 0x08, M);
            public WorldArea Area => TheGame.Files.WorldAreas.GetAreaByAreaId(M.Read<int>(Address + 0x50));

            public override string ToString()
            {
                return $"{PlayerOwner} => {Area.Name}";
            }
        }
    }
}
