using System;
using System.Data;
using System.Linq;
using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using System.Collections.Generic;
using Photography.Data.Entities;
using Photography.Data.Extensions;

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
            return UnitOfWork.Photos.GetAll(photo => photo.Albums.Any(album => album.Id == albumId)).Select(photo => photo.ToModel());
        }

        public Photo GetPhoto(int photoId)
        {
            return UnitOfWork.Photos.GetById(photoId).ToModel();
        }

        public Photo AddPhoto(string name, string description, bool isPublic, string source, string thumbnail, IEnumerable<Tag> tags, int albumId)
        {
            var album = UnitOfWork.Albums.GetById(albumId);
            if(album == null)
            {
                throw new DataException(string.Format("Album with id {0} does not exist.", albumId));
            }

            var tagEntities = new List<TagEntity>();

            var entity = new PhotoEntity()
                {
                    Albums = new List<AlbumEntity>(new[] {album}),
                    CreatedOn = DateTime.UtcNow,
                    Description = description,
                    IsPublic = isPublic,
                    Name = name,
                    Source = source,
                    ThumbnailSource = thumbnail,
                    Tags = tagEntities
                };

            return UnitOfWork.Photos.Add(entity).ToModel();
        }

        public Photo UpdatePhoto(Photo photo)
        {
            
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
