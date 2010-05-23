using SharpArch.Core.DomainModel;

namespace Serendipity.Core
{
    public class TagText : Entity
    {
        public virtual string Text { get; set; }

        public override string ToString()
        {
            return "#"  + Text;
        }
    }
}
