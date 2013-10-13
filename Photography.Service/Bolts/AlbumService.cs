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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Album> SearchAlbums(AlbumSearchCriteria searchCriteria)
        {
            throw new System.NotImplementedException();
        }

        public Album GetAlbum(int albumId)
        {
            throw new System.NotImplementedException();
        }

        public Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags)
        {
            throw new System.NotImplementedException();
        }

        public Album UpdateAlbum(int albumId, string name, string description, bool isPublic, IEnumerable<Tag> tags)
        {
            throw new System.NotImplementedException();
        }

        public Album UpdateAlbumCover(int albumId, int albumCoverId)
        {
            throw new System.NotImplementedException();
        }

        public Album UpdateAlbumCategory(int albumId, int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Album DeleteAlbum(int albumId)
        {
            throw new System.NotImplementedException();
        }
    }
}
