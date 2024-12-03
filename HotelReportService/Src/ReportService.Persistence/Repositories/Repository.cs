using MongoDB.Bson;
using MongoDB.Driver;
using ReportService.Domain.Common;
using ReportService.Persistence.Context;
using System.Linq.Expressions;

namespace ReportService.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseDocument, new()
    {
        private readonly MongoDbContext _dbContext;
        private readonly IMongoCollection<T> _collection;
        private readonly int UserId;

        public Repository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<T>();
            this.UserId = 1;
        }
 
        public async Task<T> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id); 
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
       
        public async Task<T?> CreateAsync(T entity)
        {
            entity.AddByUserId = UserId;
            entity.CreatedDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            entity.IsActive = true;
            entity.IsDeleted = false;

            await _collection.InsertOneAsync(entity);

            var id = entity.GetType().GetProperty("Id")?.GetValue(entity);
            if (id != null)
            {
                var filter = Builders<T>.Filter.Eq("Id", id);
                var exists = await _collection.Find(filter).FirstOrDefaultAsync();
                return exists;
            }
            return null;
        }
        public async Task<bool> UpdateAsync(ObjectId id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, entity);
            return true;
        }
        public async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }
        public async Task<IEnumerable<T>> SortAsync<TKey>(
            Expression<Func<T, TKey>> keySelector, bool ascending = true)
        {
            var field = new StringFieldDefinition<T>(keySelector.Body.ToString().Split('.').Last());
            var sortDefinition = ascending
                ? Builders<T>.Sort.Ascending(field)
                : Builders<T>.Sort.Descending(field);

            return await _collection
                .Find(FilterDefinition<T>.Empty)
                .Sort(sortDefinition)
                .ToListAsync();
        }
    }
}
