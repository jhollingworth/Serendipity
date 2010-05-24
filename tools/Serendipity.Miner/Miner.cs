using System;
using System.Collections.Generic;
using System.Linq;
using Serendipity.Core;
using SharpArch.Core.PersistenceSupport;

namespace Serendipity.Miner
{
    public class Miner : IDisposable
    {
        private readonly Func<Feed, FeedSpider> _getFeedSpider;
        private readonly IRepository<Feed> _feeds;
        private LinkRanker _linkRanker;
        private LinkIndexer _linkIndexer;
        private List<FeedSpider> _spiders = new List<FeedSpider>();

        public Miner(IRepository<Feed> feeds, LinkIndexer linkIndexer, LinkRanker linkRanker, Func<Feed, FeedSpider> getFeedSpider)
        {
            _feeds = feeds;
            _getFeedSpider = getFeedSpider;
            _linkIndexer = linkIndexer;
            _linkRanker = linkRanker;
            _linkIndexer.LinkIndexed += (s, e) => _linkRanker.Rank(e.Link);
        }

        public void Start()
        {
            _spiders.AddRange(_feeds.GetAll().Select(_getFeedSpider));
            
            foreach (var spider in _spiders)
            {
                spider.LinkFound += (s, e) => _linkIndexer.Index(e.Link);
                spider.Spider();
            }
        }

        public void Dispose()
        {
        }
    }
}
