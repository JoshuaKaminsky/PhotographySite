using System.Collections.Generic;
using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class TagService : BaseService<ITagProcess>, ITagService
    {
        public TagService(ITagProcess process) 
            : base(process)
        {
        }

        public Tag CreateTag(string name, string description)
        {
            return Process.CreateTag(name, description);
        }

        public IEnumerable<Tag> GetTags()
        {
            return Process.GetTags();
        }

        public Tag GetTag(int tagId)
        {
            return Process.GetTag(tagId);
        }

        public Tag UpdateTag(Tag tag)
        {
            return Process.UpdateTag(tag);
        }

        public bool DeleteTag(int tagId)
        {
            return Process.DeleteTag(tagId);
        }
    }
}
