using System;
using System.Linq;
using Serendipity.Core;

using Serendipity.Miner.Indexers;

namespace Serendipity.Miner
{
    public class LinkIndexer
    {
        private readonly IParallelisedWork _parallelisedWork;
        private readonly IIndexer[] _indexers;
        public event EventHandler<LinkEventArgs> LinkIndexed = delegate { };

        public LinkIndexer(IParallelisedWork parallelisedWork, IIndexer[] indexers)
        {
            _parallelisedWork = parallelisedWork;
            _indexers = indexers;
        }

        public void Index(Link link)
        {
            _parallelisedWork.DoWork(
                _indexers.Select(i => new Action(() => i.Index(link))).ToArray());

            LinkIndexed(this, new LinkEventArgs(link));
        }
    }
}
