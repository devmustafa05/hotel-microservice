using MongoDB.Bson;
using ReportService.Domain.Common;
using System.Linq.Expressions;

namespace ReportService.Persistence.Repositories
{
    public interface IRepository<T> where T : class, IBaseDocument
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(ObjectId id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T?> CreateAsync(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(ObjectId id, T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(ObjectId id);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="keySelector"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SortAsync<TKey>(Expression<Func<T, TKey>> keySelector, bool ascending = true);

    }
}
