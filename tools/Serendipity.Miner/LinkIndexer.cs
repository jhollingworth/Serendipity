using System;
using System.Collections.Generic;
using System.Threading;
using Serendipity.Core;

using Serendipity.Miner.Indexers;

namespace Serendipity.Miner
{
    public class LinkIndexer
    {
        public event EventHandler<LinkEventArgs> LinkIndexed = delegate { };

        private readonly List<Indexer> Indexers = new List<Indexer>
        {
            new DeliciousTagIndexer(),
            new PostRankIndexer(),
            new SemanticTagIndexer(),
            new SolrIndexer()
        };

        public void Index(Link link)
        {
            foreach (var indexer in Indexers)
                ThreadPool.QueueUserWorkItem(w => indexer.Index(link));
        }
    }
}
