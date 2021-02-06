using MongoDB.Driver;

namespace SeoulAir.Analytics.Domain.Interfaces.Repositories
{
    public interface IMongoDbContext
    {
        IMongoCollection<TDocument> GetCollection<TDocument>();
    }
}