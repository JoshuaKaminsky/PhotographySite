using Photography.Core.Models;
using System.Collections.Generic;

namespace Photography.Core.Contracts.Process
{
    public interface IAlbumProcess : IProcess
    {
        IEnumerable<Album> GetAlbums();

        IEnumerable<Album> SearchAlbums(AlbumSearchCriteria searchCriteria);
        
        Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbum(int id, string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbumCover(int id, int albumCoverId);

        Album UpdateAlbumCategory(int id, int categoryId);

        bool DeleteAlbum(int id);
    }
}
