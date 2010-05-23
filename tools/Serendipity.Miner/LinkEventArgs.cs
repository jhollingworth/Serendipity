using System;
using Serendipity.Core;

namespace Serendipity.Miner
{
    public class LinkEventArgs : EventArgs
    {
        public Link Link { get; set; }

        public LinkEventArgs(Link link)
        {
            Link = link;
        }
    }
}