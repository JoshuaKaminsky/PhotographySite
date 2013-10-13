using Photography.Core.Models;
using System.Collections.Generic;

namespace Photography.Core.Contracts.Process
{
    public interface IAlbumProcess : IProcess
    {
        Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbum(int id, string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbum(int id, Photo albumCover);

        Album UpdateAlbum(int id, Category category);

        bool DeleteAlbum(int id);
    }
}
