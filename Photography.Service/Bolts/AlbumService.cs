using System.Collections.Generic;
using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class AlbumService : BaseService<IAlbumProcess>, IAlbumService
    {
        public AlbumService(IAlbumProcess process) :
            base(process)
        {
        }

        public IEnumerable<Album> GetAlbums()
        {
            return Process.GetAlbums();
        }

        public IEnumerable<Album> SearchAlbums(AlbumSearchCriteria searchCriteria)
        {
            return Process.SearchAlbums(searchCriteria);
        }

        public Album GetAlbum(int albumId)
        {
            return Process.GetAlbumById(albumId);
        }

        public Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags)
        {
            return Process.CreateAlbum(name, description, isPublic, tags);
        }

        public Album UpdateAlbum(int albumId, string name, string description, bool isPublic, IEnumerable<Tag> tags)
        {
            return Process.UpdateAlbum(albumId, name, description, isPublic, tags);
        }

        public Album UpdateAlbumCover(int albumId, int albumCoverId)
        {
            return Process.UpdateAlbumCover(albumId, albumCoverId);
        }

        public Album UpdateAlbumCategory(int albumId, int categoryId)
        {
            return Process.UpdateAlbumCategory(albumId, categoryId);
        }

        public bool DeleteAlbum(int albumId)
        {
            return Process.DeleteAlbum(albumId);
        }
    }
}
