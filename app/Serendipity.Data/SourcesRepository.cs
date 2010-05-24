using System.Linq;
using NHibernate.Linq;
using Serendipity.Core;
using SharpArch.Data.NHibernate;

namespace Serendipity.Data
{
    public class SourcesRepository : Repository<Source>
    {
        public Source GetOrCreate(string name)
        {
            var source =  Session.Linq<Source>().SingleOrDefault(s => string.Compare(s.Name, name, true) == 0);
        
            if(null == source)
            {
                source = new Source {Name = name};

                Session.SaveOrUpdate(source);
                Session.Flush();
            }

            return source;
        }
    }
}
