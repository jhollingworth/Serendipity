using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RssToolkit.Rss;

namespace Serendipity.Miner
{
    public class FeedDownloader
    {
        public virtual RssDocument Download(string feedUrl)
        {
            return RssDocument.Load("http://www.google.com/reader/atom/feed/" + feedUrl);
        }
    }
}
