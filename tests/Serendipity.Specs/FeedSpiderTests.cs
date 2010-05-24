using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using RssToolkit.Rss;
using Serendipity.Core;
using Serendipity.Miner;
using SharpArch.Core.PersistenceSupport;
using It = Machine.Specifications.It;

namespace Serendipity.Specs
{
    public class When_I_spider_an_rss_feed
    {
        Establish context = ()=>
        {
            LinkFoundRaised = 0;
            Downloader = new Mock<FeedDownloader>();
            Links = new Mock<IRepository<Link>>();
            Feed = new Feed { Links = new List<Link> { new Link { UId = "tag:google.com,2005:reader/item/85e7fb44c701bbca" } } };
            Downloader.Setup(d => d.Download(Moq.It.IsAny<string>()))
                .Returns(RssDocument.Load(File.ReadAllText("rss.xml")));

            Spider = new FeedSpider(Feed, Downloader.Object, Links.Object);
            Spider.LinkFound += (s, e) => LinkFoundRaised++;
        };

        protected static Feed Feed;
        protected static FeedSpider Spider;
        protected static Mock<FeedDownloader> Downloader;
        protected static Mock<IRepository<Link>> Links;
        protected static int LinkFoundRaised;

        Because we_spidered_the_file = () => Spider.Spider();

        It should_save_all_the_new_links = () =>
            Links.Verify(l => l.SaveOrUpdate(Moq.It.IsAny<Link>()), Times.Exactly(19));

        It should_raise_the_link_found_event = () =>
            LinkFoundRaised.ShouldEqual(19);
    }
}
