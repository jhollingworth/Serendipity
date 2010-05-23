using System;
using System.Threading;
using Serendipity.Core;

namespace Serendipity.Miner
{
    public class FeedSpider : IDisposable
    {
        private readonly Feed _feed;
        private readonly Thread _spiderThread;
        public event EventHandler<LinkEventArgs> LinkFound = delegate { };

        public FeedSpider(Feed feed)
        {
            _feed = feed;
            
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
                var url = "http://www.google.com/reader/atom/feed/" + _feed.Url;


                LinkFound(this, new LinkEventArgs(new Link()));

                Thread.Sleep(new TimeSpan(0, 1, 0));
            }
        }

        public void Dispose()
        {
            _spiderThread.Abort();
        }
    }
}
