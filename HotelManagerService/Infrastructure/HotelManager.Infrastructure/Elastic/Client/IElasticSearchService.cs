using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Infrastructure.Elastic.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IElasticSearchService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="indexName"></param>
        /// <returns></returns>
        Task IndexDocumentAsync<T>(T document, string indexName) where T : class;
        Task UpdateDocumentAsync<T>(string id, T document, string indexName) where T : class;
        Task DeleteDocumentAsync(string id, string indexName);
        Task<ISearchResponse<T>> SearchDocumentsAsync<T>(
            Func<SearchDescriptor<T>, ISearchRequest> searchDescriptor) where T : class;
       
    }
}
