using System.Linq;
using Photography.Core.Models;
using Photography.Data.Entities;
using System.Linq;

namespace Photography.Data.Extensions
{
    internal static class ModelTranslator
    {
        public static Session ToModel(this SessionEntity dataModel)
        {
            if (dataModel == null)
                return null;

            return new Session
                {
                    CreatedOn = dataModel.CreatedOn,
                    Id = dataModel.Id,
                    SessionKey = dataModel.SessionKey,
                    User = dataModel.User.ToModel()
                };
        }

        public static User ToModel(this UserEntity dataModel)
        {
            if (dataModel == null)
                return null;

            return new User
                {
                    Discount = dataModel.Discount,
                    EmailAddress = dataModel.EmailAddress,
                    Id = dataModel.Id,
                };
        }

        public static Role ToModel(this RoleEntity dataModel)
        {
            if (dataModel == null)
                return null;

            return new Role
                {
                    Id = dataModel.Id,
                    Name = dataModel.Name
                };
        }

        public static Photo ToModel(this PhotoEntity dataModel)
        {
            if (dataModel == null) 
                return null;

            return new Photo()
                       {
                           CreatedOn = dataModel.CreatedOn,
                           Description = dataModel.Description,
                           Id = dataModel.Id,
                           IsPublic = dataModel.IsPublic,
                           Name = dataModel.Name,
                           Source = dataModel.Source,
                           Tags = dataModel.Tags.Select(ToModel),
                           ThumbnailSource = dataModel.ThumbnailSource
                       };
        }

        public static Tag ToModel(this TagEntity dataModel)
        {
            if (dataModel == null) 
                return null;

            return new Tag { Description = dataModel.Description, Id = dataModel.Id, Name = dataModel.Name };
        }
        
        public static Album ToModel(this AlbumEntity dataModel)
        {
            if (dataModel == null)
                return null;

            return new Album 
                {   AlbumCover = dataModel.AlbumCover.ToModel(), 
                    Category = dataModel.Category.ToModel(), 
                    CreatedOn = dataModel.CreatedOn, 
                    Description = dataModel.Description, 
                    Id = dataModel.Id, 
                    IsPublic = dataModel.IsPublic, 
                    Name = dataModel.Name 
                };
        } 

        public static Category ToModel(this CategoryEntity dataModel)
        {
            if (dataModel == null)
                return null;

            return new Category
                {
                    Id = dataModel.Id,
                    Name = dataModel.Name
                };
        }

        public static UserEntity ToEntity(this User model)
        {
            if (model == null)
                return null;

            return new UserEntity
            {
                Discount = model.Discount,
                EmailAddress = model.EmailAddress,
                Id = model.Id
            };
        }
    }
}
