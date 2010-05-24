using System;
using System.Collections.Generic;
using System.Linq;
using Serendipity.Core;
using SharpArch.Core.PersistenceSupport;

namespace Serendipity.Miner
{
    public class FeedSpider 
    {
        private readonly Feed _feed;
        private readonly FeedDownloader _downloader;
        private readonly IRepository<Link> _links;
        public event EventHandler<LinkEventArgs> LinkFound = delegate { };

        public FeedSpider(Feed feed, FeedDownloader downloader, IRepository<Link> links)
        {
            _feed = feed;
            _downloader = downloader;
            _links = links;
        }

        public void Spider()
        {
            var items = from i in _downloader.Download(_feed.Url).Channel.Items
                        where _feed.Links.Any(l => l.UId == i.Guid.Text.Trim()) == false
                        select i;

            var links = new List<Link>();

            foreach (var item in items)
            {
                var link = new Link
                {
                    Feed = _feed,
                    UId = item.Link,
                    Title = item.Title,
                    DatePublished = item.PubDateParsed
                };

                _links.SaveOrUpdate(link);
                links.Add(link);
            }

        
            links.ForEach(l => LinkFound(this, new LinkEventArgs(l)));
        }
    }
}
