using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace Serendipity.Core
{
    public class Source : Entity
    {
        public virtual string Url { get; set; }
        public virtual string Name { get; set; }
    }
}
