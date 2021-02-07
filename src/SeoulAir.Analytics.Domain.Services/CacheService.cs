using System.Collections.Generic;
using System.Linq;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Domain.Services
{
    public class CacheService<TDto> : ICacheService<TDto> where TDto : class
    {
        private readonly Dictionary<ushort,Queue<TDto>> _dtoCache;
        private readonly int _capacity;
        private static readonly ushort[] _stationCodes = {101, 102, 103, 104, 105};
        private const ushort DefaultCapacity = 5;

        public CacheService()
        {
            _dtoCache = new Dictionary<ushort, Queue<TDto>>(_stationCodes.Length);
            foreach (var stationCode in _stationCodes)
                _dtoCache.Add(stationCode, new Queue<TDto>(DefaultCapacity));
            
            _capacity = DefaultCapacity;
        }

        public CacheService(int capacity)
        {
            _dtoCache = new Dictionary<ushort, Queue<TDto>>(_stationCodes.Length);
            foreach (var stationCode in _stationCodes)
                _dtoCache.Add(stationCode, new Queue<TDto>(capacity));
            
            _capacity = capacity;
        }

        public void AddNewRecord(ushort stationCode, TDto record)
        {
            _dtoCache[stationCode].Enqueue(record);
            
            if (_dtoCache.Count > _capacity)
                _dtoCache[stationCode].Dequeue();
        }

        public TDto[] GetCache(ushort stationCode)
        {
            return _dtoCache[stationCode].ToArray();
        }

        public TDto GetOldestRecord(ushort stationCode)
        {
            return _dtoCache[stationCode].Peek();
        }
    }
}