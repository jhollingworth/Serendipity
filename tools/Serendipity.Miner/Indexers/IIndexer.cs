using Serendipity.Core;

namespace Serendipity.Miner.Indexers
{
    public interface IIndexer
    {
        void Index(Link link);
    }
}