using System;
using System.Linq;
using System.Threading;
using Serendipity.Core;
using RssToolkit.Rss;

namespace Serendipity.Miner
{
    public class FeedSpider : IDisposable
    {
        private readonly Feed _feed;
        private readonly FeedDownloader _downloader;
        private readonly Thread _spiderThread;
        public event EventHandler<LinkEventArgs> LinkFound = delegate { };

        public FeedSpider(Feed feed, FeedDownloader downloader)
        {
            _feed = feed;
            _downloader = downloader;

            _spiderThread = new Thread(Spider);
        }

        public void Start()
        {
            _spiderThread.Start();
        }

        private void Spider()
        {
            while(true)
            {
                //var items = from o in _downloader.Download(_feed.Url).SelectItems()
                //            let i = (RssItem)o




                //foreach (var item in items)
                //{
                    
                //}

                


                

                Thread.Sleep(new TimeSpan(0, 1, 0));
            }
        }

        public void Dispose()
        {
            _spiderThread.Abort();
        }
    }
}
