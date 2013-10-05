using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetTags()
        {
            throw new NotImplementedException();
        }

        public Tag GetTag(int tagId)
        {
            throw new NotImplementedException();
        }

        public Tag UpdateTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTag(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
