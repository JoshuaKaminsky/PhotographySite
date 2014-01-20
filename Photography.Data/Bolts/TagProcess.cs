using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using Photography.Data.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Photography.Data.Bolts
{
    internal class TagProcess : BaseProcess, ITagProcess
    {
        public TagProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Tag CreateTag(string name, string description)
        {
            var tag = UnitOfWork.Tags.Get(t => t.Name == name);
            if (tag != null) return tag.ToModel();

            return UnitOfWork.Tags.Add(new TagEntity { Description = description, Name = name }).ToModel();
        }

        public IEnumerable<Tag> GetTags()
        {
            return UnitOfWork.Tags.GetAllQueryable().Select(tag => tag.ToModel());
        }

        public Tag GetTag(int tagId)
        {
            return UnitOfWork.Tags.GetById(tagId).ToModel();
        }

        public Tag UpdateTag(Tag tag)
        {
            var oldTag = UnitOfWork.Tags.GetById(tag.Id);
            if (oldTag == null)
            {
                throw new DataException(string.Format("Tag {0} does not exist.", tag.Name));
            }

            oldTag.Name = tag.Name;
            oldTag.Description = tag.Description;

            return UnitOfWork.Tags.Update(oldTag).ToModel();
        }

        public bool DeleteTag(int tagId)
        {
            return UnitOfWork.Tags.Delete(tagId);
        }
    }
}