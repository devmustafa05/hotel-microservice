using MongoDB.Bson;
using MongoDB.Driver;
using ReportService.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MongoDbContext _dbContext;
        private readonly IMongoCollection<T> _collection;

        public Repository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
            _collection = _dbContext.GetCollection<T>(); 
        }

        // ID ile veri getirme
        public async Task<T> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id); // Id'yi dinamik olarak alıyoruz
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        // Tüm verileri getirme
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        // Yeni veri ekleme
        public async Task<bool> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);

            var id = entity.GetType().GetProperty("Id")?.GetValue(entity);
            if (id != null)
            {
                var filter = Builders<T>.Filter.Eq("Id", id);
                var exists = await _collection.Find(filter).FirstOrDefaultAsync();
                return exists != null;
            }
            return false;
        }

        // Veriyi güncelleme
        public async Task UpdateAsync(ObjectId id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        // Veriyi silme
        public async Task DeleteAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
