namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface ICacheService<T> where T : class
    {
        void AddNewRecord(T record);
        T[] GetCache();
        T OldestRecord { get; }
    }
}