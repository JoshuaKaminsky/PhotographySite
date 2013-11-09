using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Photography.Data.Extensions;

namespace Photography.Data.Bolts
{       
    internal class AlbumProcess : BaseProcess, IAlbumProcess
    {
        public AlbumProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Album> GetAlbums()
        {
            var albums = UnitOfWork.Albums.GetAll().ToList();
            return albums.Select(x => x.ToModel());
        }

        public IEnumerable<Album> SearchAlbums(AlbumSearchCriteria searchCriteria)
        {
            var startsWith = UnitOfWork.Albums.GetAll(x => x.Name.StartsWith(searchCriteria.NameFilter, true, null));
            var contains = UnitOfWork.Albums.GetAll(x => x.Name.ToLower().Contains(searchCriteria.NameFilter.ToLower()));
            
            return startsWith.Union(contains, new EntityComparer<AlbumEntity>()).Select(album => album.ToModel());
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

        public Album UpdateAlbumCover(int id, int albumCoverId)
        {
            var oldAlbum = UnitOfWork.Albums.GetById(id);
            if (oldAlbum == null)
                throw new DataException("Album could not be retrieved.");

            var newAlbum = new AlbumEntity
            {
                AlbumCoverId = albumCoverId   
            };

            newAlbum = UnitOfWork.Albums.Update(newAlbum);
            UnitOfWork.Commit();

            return newAlbum.ToModel();
        }

        public Album UpdateAlbumCategory(int id, int categoryId)
        {
            var oldAlbum = UnitOfWork.Albums.GetById(id);
            if (oldAlbum == null)
                throw new DataException("Album could not be retrieved.");

            var newAlbum = new AlbumEntity
            {
                CategoryId = categoryId
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
