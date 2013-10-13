using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Data.Extensions;

namespace Photography.Data.Bolts
{       
    internal class AlbumProcess : BaseProcess, IAlbumProcess
    {
        public AlbumProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Album CreateAlbum(string name, string description, bool isPublic, IEnumerable<Tag> tags)
        {
            var oldAlbum = UnitOfWork.Albums.Get(album => album.Name.Equals(name));
            if (oldAlbum != null)
                throw new DataException("Album name already exists.");

            var newAlbum = new AlbumEntity
            {
                Name = name,
                Description = description,
                IsPublic = isPublic,
                Tags = tags.Select(tag => new TagEntity { Id = tag.Id }).ToList()
            };

            newAlbum = UnitOfWork.Albums.Add(newAlbum);
            UnitOfWork.Commit();

            return newAlbum.ToModel();
        }

        public Album UpdateAlbum(int id, string name, string description, bool isPublic, IEnumerable<Tag> tags)
        {
            var oldAlbum = UnitOfWork.Albums.GetById(id);
            if (oldAlbum == null)
                throw new DataException("Album could not be retrieved.");

            var newAlbum = new AlbumEntity
            {
                Name = name,
                Description = description,
                IsPublic = isPublic,
                Tags = tags.Select(tag => new TagEntity { Id = tag.Id }).ToList()
            };

            newAlbum = UnitOfWork.Albums.Update(newAlbum);
            UnitOfWork.Commit();

            return newAlbum.ToModel();
        }

        public Album UpdateAlbum(int id, Photo albumCover)
        {
            var oldAlbum = UnitOfWork.Albums.GetById(id);
            if (oldAlbum == null)
                throw new DataException("Album could not be retrieved.");

            var newAlbum = new AlbumEntity
            {
                AlbumCoverId = albumCover.Id   
            };

            newAlbum = UnitOfWork.Albums.Update(newAlbum);
            UnitOfWork.Commit();

            return newAlbum.ToModel();
        }

        public Album UpdateAlbum(int id, Category category)
        {
            var oldAlbum = UnitOfWork.Albums.GetById(id);
            if (oldAlbum == null)
                throw new DataException("Album could not be retrieved.");

            var newAlbum = new AlbumEntity
            {
                CategoryId = category.Id
            };

            newAlbum = UnitOfWork.Albums.Update(newAlbum);
            UnitOfWork.Commit();

            return newAlbum.ToModel();
        }

        public bool DeleteAlbum(int id)
        {
            return UnitOfWork.Albums.GetById(id) == null || UnitOfWork.Albums.Delete(id);
        }
    }
}
