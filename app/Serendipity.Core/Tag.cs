using SharpArch.Core.DomainModel;

namespace Serendipity.Core
{
    public class Tag : Entity
    {
        public virtual TagText Text { get; set; }
        public virtual Source Source { get; set; }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
