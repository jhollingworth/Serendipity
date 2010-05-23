using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Machine.Specifications;
using RssToolkit.Rss;
using Serendipity.Miner;

namespace Serendipity.Specs
{
    public class FeedSpiderContext
    {
    }

    public class When
    {
        private static RssDocument Document;
        Because we_downloaded_a_feed = () =>
            Document = RssDocument.Load(File.ReadAllText("rss.xml"));

        private It should_have_some_items = () =>
                                                {
                                                    var items = Document.SelectItems();
                                                };
    }
}
