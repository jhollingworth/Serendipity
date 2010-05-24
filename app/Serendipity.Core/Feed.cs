using System.Collections.Generic;
using Serendipity.Core;
using SharpArch.Core.DomainModel;

namespace Serendipity.Core
{
    public class Feed : Entity
    {
        public virtual string Url { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Link> Links { get; set; }
    }
}
