using Nest;

namespace HotelManager.Infrastructure.Elastic.Client
{
    /// <inheritdoc cref="IReadRepository" />
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient _elasticClient;

        public ElasticSearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexDocumentAsync<T>(T document, string indexName) where T : class
        {
            var response = await _elasticClient.IndexAsync(document, idx => idx.Index(indexName));
            if (!response.IsValid)
            {
                throw new Exception($"Failed to index document: {response.ServerError?.Error}");
            }
        }

        public async Task UpdateDocumentAsync<T>(string id, T document, string indexName) where T : class
        {
            var response = await _elasticClient.UpdateAsync<T>(id, u => u.Index(indexName).Doc(document));
            if (!response.IsValid)
            {
                throw new Exception($"Failed to update document: {response.ServerError?.Error}");
            }
        }

        public async Task DeleteDocumentAsync(string id, string indexName)
        {
            var response = await _elasticClient.DeleteAsync(new DeleteRequest(indexName, id));
            if (!response.IsValid)
            {
                throw new Exception($"Failed to delete document: {response.ServerError?.Error}");
            }
        }

        public async Task<ISearchResponse<T>> SearchDocumentsAsync<T>(
            Func<SearchDescriptor<T>, ISearchRequest> searchDescriptor) where T : class
        {
            var response = await _elasticClient.SearchAsync(searchDescriptor);
            if (!response.IsValid)
            {
                throw new Exception($"Search failed: {response.ServerError?.Error}");
            }

            return response;
        }
    }
}
