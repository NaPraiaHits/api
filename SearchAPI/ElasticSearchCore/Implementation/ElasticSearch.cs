
using SearchAPI.ElasticServices;
using SearchAPI.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SearchAPI.ElasticSearchCore.Implementation
{
    public class ElasticSearch : IElasticSearch
    {
        private readonly IElasticCommand _command;
        private const string _elasticIndex = "searchdb";

        public ElasticSearch(IElasticCommand command)
        {
            _command = command ?? throw new ArgumentNullException("Core command", "Core ElasticCommand não iniciado.");

        }        
        public IEnumerable<Doc> Get(int id)
        {
            return _command.Search<Doc>(s => s.Index(_elasticIndex).MatchAll());
        }        
    }
}
