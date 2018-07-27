using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPI.ElasticServices
{   
    public class ElasticCommand : IElasticCommand
    {       
        private readonly IElasticClient _client;

        public ElasticCommand(IElasticClient client)
        {
            _client = client ?? throw new ArgumentNullException("client", "client invalid!");
        }       
        public IEnumerable<T> Search<T>(Func<SearchDescriptor<T>, ISearchRequest> query) where T : class
        {
            var response = _client.Search<T>(query);
            ValidateResponse(response);
            return response.Documents;
        }
        public async Task<IEnumerable<T>> SearchAsync<T>(Func<SearchDescriptor<T>, ISearchRequest> query) where T : class
        {
            var response = await _client.SearchAsync<T>(query);
            ValidateResponse(response);
            return response.Documents;
        }       
        public T GetById<T>(int id) where T : class
        {
            var response = _client.Get<T>(id);
            ValidateResponse(response);
            return response.Source;
        }
        public void Delete<T>(string chave) where T : class
        {
            var response = _client.Delete<T>(chave);
            ValidateResponse(response);
        }
        public void DeleteBulk<T>(IEnumerable<T> doc) where T : class
        {
            var bulkResponse = _client.Bulk(new BulkRequest
            {
                Operations = doc.Select(x => new BulkDeleteOperation<T>(x)).Cast<IBulkOperation>().ToList()
            });

        }        
        private void ValidateResponse(IResponse response)
        {
            if (response.OriginalException != null)
                throw response.OriginalException;
        }
    }
}