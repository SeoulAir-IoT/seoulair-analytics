using System.Collections.Generic;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Domain.Services
{
    public class CacheService<TDto> : ICacheService<TDto> where TDto : class
    {
        private readonly Queue<TDto> _dtoCache;
        private readonly int _capacity;
        private const ushort DefaultCapacity = 5;

        public CacheService()
        {
            _dtoCache = new Queue<TDto>(DefaultCapacity);
            _capacity = DefaultCapacity;
        }

        public CacheService(int capacity)
        {
            _dtoCache = new Queue<TDto>(capacity);
            _capacity = capacity;
        }

        public void AddNewRecord(TDto record)
        {
            _dtoCache.Enqueue(record);
            
            if (_dtoCache.Count > _capacity)
                _dtoCache.Dequeue();
        }

        public TDto[] GetCache()
        {
            return _dtoCache.ToArray();
        }

        public TDto OldestRecord => _dtoCache.Peek();
    }
}