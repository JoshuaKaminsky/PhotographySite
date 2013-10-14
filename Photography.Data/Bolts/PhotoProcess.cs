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

        public Photo GetPhoto(int photoId)
        {
            return UnitOfWork.Photos.GetById(photoId).ToModel();
        }

        public IEnumerable<Photo> GetAlbumPhotos(int albumId)
        {
            return UnitOfWork.Photos.GetAll(photo => photo.Albums.Any(album => album.Id == albumId)).Select(photo => photo.ToModel());
        }

        public IEnumerable<Photo> GetPhotos(SearchCriteria searchCriteria)
        {
            var startsWith = UnitOfWork.Photos.GetAll(x => x.Name.StartsWith(searchCriteria.NameFilter, true, null));
            var contains = UnitOfWork.Photos.GetAll(x => x.Name.ToLower().Contains(searchCriteria.NameFilter.ToLower()));

            return startsWith.Union(contains, new EntityComparer<PhotoEntity>()).Select(photo => photo.ToModel());
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
            var entity = UnitOfWork.Photos.GetById(photo.Id);
            if (entity == null)
            {
                throw new DataException(string.Format("Photo with id {0} does not exist.", photo.Id));
            }

            entity.Description = photo.Description;
            entity.IsPublic = photo.IsPublic;
            entity.Name = photo.Name;
            entity.Source = photo.Source;
            entity.ThumbnailSource = photo.ThumbnailSource;
            entity.Tags = photo.Tags.Select(tag => tag.ToEntity()).ToList();

            return UnitOfWork.Photos.Update(entity).ToModel();
        }

        public bool RemovePhotoFromAlbum(int albumId, int photoId)
        {
            var album = UnitOfWork.Albums.GetById(albumId);
            if (album == null)
            {
                throw new DataException(string.Format("Album with id {0} does not exist.", albumId));
            }

            var photo = UnitOfWork.Photos.GetById(photoId);
            if (photo == null)
            {
                throw new DataException(string.Format("Photo with id {0} does not exist.", albumId));
            }

            return photo.Albums.Remove(album);

        }

        public bool DeletePhoto(int photoId)
        {
            return UnitOfWork.Photos.Delete(photoId);
        }
    }
}
