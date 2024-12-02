using MongoDB.Driver;
using ReportService.Domain.Documents;

namespace ReportService.Persistence.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase database;

        public MongoDbContext(IMongoClient mongoClient, string databaseName)
        {   
            database = mongoClient.GetDatabase(databaseName);
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>(typeof(T).Name); 
            // Entity'nin adına göre koleksiyon adı alınıyor
        }

      //  public IMongoCollection<ReportDocument> Reports => database.GetCollection<ReportDocument>("ReportDocuments");
        
    }
}
