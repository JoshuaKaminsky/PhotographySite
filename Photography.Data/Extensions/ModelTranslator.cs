﻿using System.Linq;
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
                    Name = dataModel.Name
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

        public static ResetPasswordRequest ToModel(this ResetPasswordRequestEntity dataModel)
        {
            if (dataModel == null)
                return null;

            return new ResetPasswordRequest
            {
                CreatedOn = dataModel.CreatedOn,
                Id = dataModel.Id,
                Token = dataModel.Token,
                UsedOn = dataModel.UsedOn,
                User = dataModel.User.ToModel()
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

        public static AlbumEntity ToEntity(this Album model)
        {
            if (model == null)
                return null;

            return new AlbumEntity()
                {
                    AlbumCoverId = (model.AlbumCover != null) ? model.AlbumCover.Id : 0,
                    CategoryId = (model.Category != null) ? model.Category.Id : 0,
                    CreatedOn = model.CreatedOn,
                    Description = model.Description,
                    Id = model.Id,
                    IsPublic = model.IsPublic,
                    Name = model.Name,
                };
        }

        public static PhotoEntity ToEntity(this Photo model)
        {
            if (model == null)
                return null;

            return new PhotoEntity()
                {
                    CreatedOn = model.CreatedOn,
                    Description = model.Description,
                    Id = model.Id,
                    IsPublic = model.IsPublic,
                    Name = model.Name,
                    Source = model.Source,
                    ThumbnailSource = model.ThumbnailSource,
                    Tags = (model.Tags != null) ? model.Tags.Select(ToEntity).ToList() : null
                };
        }

        public static TagEntity ToEntity(this Tag model)
        {
            if (model == null)
                return null;

            return new TagEntity
                {
                    Description = model.Description,
                    Id = model.Id,
                    Name = model.Name
                };
        }
    }
}
