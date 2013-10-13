using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    public interface ITagService : IService
    {
        /// <summary>
        /// Create a new tag
        /// </summary>
        /// <param name="name">The name of the tag</param>
        /// <param name="description">A description of the tag</param>
        /// <returns>The newly created tag</returns>
        Tag CreateTag(string name, string description);

        /// <summary>
        /// Retrieve a list of all tags
        /// </summary>
        /// <returns>A list of tags</returns>
        IEnumerable<Tag> GetTags();

        /// <summary>
        /// Retrieve a tag by id
        /// </summary>
        /// <param name="tagId">The tag id</param>
        /// <returns>The tag with the specified id</returns>
        Tag GetTag(int tagId);

        /// <summary>
        /// Update a tag
        /// </summary>
        /// <param name="tag">The updated tag</param>
        /// <returns>The updated tag</returns>
        Tag UpdateTag(Tag tag);

        /// <summary>
        /// Delete a tag
        /// </summary>
        /// <param name="tagId">The id of the tag</param>
        /// <returns>True if successful, otherwise false</returns>
        bool DeleteTag(int tagId);
    }
}