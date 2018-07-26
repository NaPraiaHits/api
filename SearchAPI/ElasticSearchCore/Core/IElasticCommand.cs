using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchAPI.ElasticCommand
{
    public interface IElasticCommand
    {     
        IEnumerable<T> Search<T>(Func<SearchDescriptor<T>, ISearchRequest> query) where T : class;

        Task<IEnumerable<T>> SearchAsync<T>(Func<SearchDescriptor<T>, ISearchRequest> query) where T : class;       

        T GetById<T>(int id) where T : class;

        void CreateBulk<T>(List<T> documento) where T : class;

        void Delete<T>(string chave) where T : class;

        void DeleteBulk<T>(IEnumerable<T> documento) where T : class;

    }
}