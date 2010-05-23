using System;
using System.Collections.Generic;
using Serendipity.Core;
using SharpArch.Core.DomainModel;

namespace Serendipity.Core
{
    public class Link : Entity
    {
        public virtual List<Feed> Feeds { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Source Source { get; set; }
        public virtual Source Refferer { get; set; }
        public virtual double PostRank { get; set; }
        public virtual string Url { get; set; }
        public virtual Guid UId { get; set; }
    }
}
