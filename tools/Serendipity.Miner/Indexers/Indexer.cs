using Serendipity.Core;

namespace Serendipity.Miner.Indexers
{
    public abstract class Indexer
    {
        public abstract void Index(Link link);
    }
}