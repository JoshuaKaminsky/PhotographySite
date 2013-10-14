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
            return Process.GetAlbumPhotos(albumId);
        }

        public IEnumerable<Photo> GetPhotos(SearchCriteria searchCriteria)
        {
            throw new System.NotImplementedException();
        }

        public Photo GetPhoto(int photoId)
        {
            return Process.GetPhoto(photoId);
        }

        public Photo AddPhoto(string name, string description, bool isPublic, byte[] data, IEnumerable<Tag> tags)
        {
            throw new System.NotImplementedException();
        }

        public Photo UpdatePhoto(Photo photo)
        {
            return Process.UpdatePhoto(photo);
        }

        public bool RemovePhotoFromAlbum(int albumId, int photoId)
        {
            return Process.RemovePhotoFromAlbum(albumId, photoId);
        }

        public bool DeletePhoto(int photoId)
        {
            return Process.DeletePhoto(photoId);
        }
    }
}
