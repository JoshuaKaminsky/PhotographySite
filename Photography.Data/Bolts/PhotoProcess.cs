using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using System.Collections.Generic;

namespace Photography.Data.Bolts
{
    internal class PhotoProcess : BaseProcess, IPhotoProcess
    {
        public PhotoProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Photo> GetAlbumPhotos(int albumId)
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
