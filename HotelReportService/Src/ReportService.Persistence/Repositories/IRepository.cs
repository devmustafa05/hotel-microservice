using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Persistence.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(ObjectId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task UpdateAsync(ObjectId id, T entity);
        Task DeleteAsync(ObjectId id);
    }
}
