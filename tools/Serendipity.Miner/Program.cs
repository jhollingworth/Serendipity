using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Serendipity.Core;
using Serendipity.Web.CastleWindsor;
using SharpArch.Core.PersistenceSupport;

namespace Serendipity.Miner
{
    class Program
    {
        private static IWindsorContainer _container;
        static void Main(string[] args)
        {
            _container = new WindsorContainer();
            ComponentRegistrar.AddComponentsTo(_container);

            _container.Register(
                Component.For<LinkRanker>(),
                Component.For<LinkIndexer>(),
                Component.For<Miner>(),
                Component.For<FeedSpider>());

            var feeds = _container.Resolve<IRepository<Feed>>();

            feeds.SaveOrUpdate(new Feed {Name = "YCombinator", Url = "http://news.ycombinator.com/rss"});
            feeds.DbContext.CommitChanges();

            var miner = _container.Resolve<Miner>(new
            {
                getFeedSpider = new Func<Feed, FeedSpider>(GetFeedSpider)
            });

            miner.Start();
        }

        private static FeedSpider GetFeedSpider(Feed feed)
        {
            return _container.Resolve<FeedSpider>(new {feed});
        }
    }
}
