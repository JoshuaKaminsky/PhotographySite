using System.Collections.Generic;
using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class TagService : BaseService<ITagProcess>, ITagService
    {
        public TagService(ITagProcess process) : base(process)
        {
        }

        public Tag CreateTag(string name, string description)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Tag> GetTags()
        {
            throw new System.NotImplementedException();
        }

        public Tag GetTag(int tagId)
        {
            throw new System.NotImplementedException();
        }

        public Tag UpdateTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTag(int tagId)
        {
            throw new System.NotImplementedException();
        }
    }
}
