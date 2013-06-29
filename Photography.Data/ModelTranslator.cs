using System.Linq;
using BaseMvc.Model;

namespace BaseMvc.Data.Extension
{
    internal static class ModelTranslator
    {
        public static Session ToModel(this Entity.Session dataModel)
        {
            if (dataModel == null)
                return null;

            return new Session(dataModel.Id,
                dataModel.SessionId,
                dataModel.User.ToModel());
        }

        public static User ToModel(this Entity.User dataModel)
        {
            if (dataModel == null)
                return null;

            return new User(dataModel.Id,
                dataModel.UserName,
                dataModel.FirstName,
                dataModel.LastName,
                dataModel.IsActive,
                dataModel.Roles.Select(ToModel));
        }

        public static Role ToModel(this Entity.Role dataModel)
        {
            if (dataModel == null)
                return null;

            return new Role(dataModel.Id,
                dataModel.Name,
                dataModel.Permissions.Select(ToModel));
        }

        public static Permission ToModel(this Entity.Permission dataModel)
        {
            if (dataModel == null)
                return null;

            return new Permission(dataModel.Id,
                dataModel.Name);
        }

        public static Entity.User ToDataModel(this User model)
        {
            if (model == null)
                return null;

            return new Entity.User()
            {
                Id = model.Id,
                IsActive = model.IsActive,
                UserName = model.UserName
            };
        }
        
    }
}
