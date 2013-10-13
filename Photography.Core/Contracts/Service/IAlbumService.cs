using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    public interface IAlbumService : IService
    {
        IEnumerable<Album> GetAlbums();

        IEnumerable<Album> SearchAlbums(AlbumSearchCriteria searchCriteria);
        
        Album GetAlbum(int albumId);

        Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbum(int albumId, string name, string description, bool isPublic, IEnumerable<Tag> tags);

        Album UpdateAlbumCover(int albumId, int albumCoverId);

        Album UpdateAlbumCategory(int albumId, int categoryId);

        bool DeleteAlbum(int albumId);
    }
}
