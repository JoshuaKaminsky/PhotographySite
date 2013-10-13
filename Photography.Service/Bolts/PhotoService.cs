using System.Collections.Generic;
using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class PhotoService : BaseService<IPhotoProcess>, IPhotoService
    {
        public PhotoService(IPhotoProcess process) : base(process)
        {
        }

        public IEnumerable<Photo> GetAlbumPhotos(int albumId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotos(SearchCriteria searchCriteria)
        {
            throw new System.NotImplementedException();
        }

        public Photo GetPhoto(int photoId)
        {
            throw new System.NotImplementedException();
        }

        public Photo AddPhoto(string name, string description, bool isPublic, byte[] data, IEnumerable<Tag> tags)
        {
            throw new System.NotImplementedException();
        }

        public Photo UpdatePhoto(Photo photo)
        {
            throw new System.NotImplementedException();
        }

        public bool RemovePhotoFromAlbum(int albumId, int photoId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePhoto(int photoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
