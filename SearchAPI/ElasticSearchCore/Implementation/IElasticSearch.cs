
using SearchAPI.Model;
using System.Collections.Generic;

namespace SearchAPI.ElasticSearchCore.Implementation
{
    public interface IElasticSearch
    {
        IEnumerable<Doc> Get(int id);
    }
}
