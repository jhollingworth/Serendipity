using System;
using System.Collections.Generic;
using Serendipity.Core;
using SharpArch.Core.DomainModel;

namespace Serendipity.Core
{
    public class Link : Entity
    {
        public virtual Feed Feed { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Source Source { get; set; }
        public virtual Source Refferer { get; set; }
        public virtual double PostRank { get; set; }
        public virtual string Url { get; set; }
        public virtual string UId { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime DatePublished { get; set; }
    }
}
