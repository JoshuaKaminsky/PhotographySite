using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
