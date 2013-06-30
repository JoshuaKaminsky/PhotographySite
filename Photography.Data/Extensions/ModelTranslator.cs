using System;
using Photography.Core.Models;
using Photography.Data.Entities;

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

        public static UserEntity ToDataModel(this User model)
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
