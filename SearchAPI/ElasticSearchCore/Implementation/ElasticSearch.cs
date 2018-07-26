
using SearchAPI.ElasticCommand;
using SearchAPI.Model;
using System;

namespace SearchAPI.ElasticSearchCore.Implementation
{
    public class ElasticSearch : IElasticSearch
    {

        private readonly IElasticCommand _command;

        public ElasticSearch(IElasticCommand command)
        {
            _command = command ?? throw new ArgumentNullException("Core command", "Core ElasticCommand não iniciado.");
        }
        
        public void Get(int id)
        {
            _command.Search<SearchParameter>(s => s.From(0).Size(10));
        }
    }
}
