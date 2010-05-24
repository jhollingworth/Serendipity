using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serendipity.Core;
using Serendipity.Data;
using SharpArch.Core.PersistenceSupport;


namespace Serendipity.Miner.Indexers
{
    public class DeliciousTagIndexer : IIndexer
    {
        private readonly IRepository<Link> _links;
        private readonly IRepository<TagText> _tagTexts;
        private readonly IRepository<Tag> _tags;
        private Source _source;

        public DeliciousTagIndexer(IRepository<Link> links, IRepository<TagText> tagTexts,IRepository<Tag> tags, SourcesRepository sources)
        {
            _links = links;
            _tagTexts = tagTexts;
            _tags = tags;
            _source = sources.GetOrCreate("Delicious");
        }

        public void Index(Link link)
        {
            var tags = new string[] {"foo", "bar"}
                .Select(c => c.Trim().ToLower())
                .Distinct()
                .Where(d => link.Tags.Any(t => string.Compare(d, t.Text.Text, true) == 0));

            if(tags.Count() < 1)
                return;

            var texts = _tagTexts.GetAll();

            foreach(var deliciousTag in tags)
            {
                var text = texts.SingleOrDefault(t => string.Compare(deliciousTag.Trim(), t.Text, true) == 0) ??
                           new TagText {Text = deliciousTag.Trim()};


               
                var tag = new Tag
                              {
                                  Text = text,
                                  Source = _source
                              };

                _tags.SaveOrUpdate(tag);
                link.Tags.Add(tag);
            }

            _links.SaveOrUpdate(link);
        }
    }
}
