namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface ICacheService<T> where T : class
    {
        void AddNewRecord(ushort stationCode, T record);
        T[] GetCache(ushort stationCode);
        T GetOldestRecord(ushort stationCode);
    }
}