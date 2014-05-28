using Photography.Core.Models;
using System.Collections.Generic;

namespace Photography.Core.Contracts.Process
{
    public interface IAlbumProcess : IProcess
    {
        IEnumerable<Album> GetAlbums();

        Album GetAlbumById(int albumId);

        IEnumerable<Album> SearchAlbums(AlbumSearchCriteria searchCriteria);
        
        Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags, int categoryId);

        Album UpdateAlbum(int albumId, string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbumCover(int albumId, int albumCoverId);

        Album UpdateAlbumCategory(int albumId, int categoryId);

        bool DeleteAlbum(int albumId);
    }
}
