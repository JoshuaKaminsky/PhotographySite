using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;

namespace Photography.Service.Bolts
{
    internal class UserService : BaseService<IUserProcess>, IUserService
    {
        public UserService(IUserProcess process)
            : base(process)
        {
        }

        public Core.Models.User CreateUser(string emailAddress, string password)
        {
            return Process.CreateUser(emailAddress, password);
        }

        public bool DeleteUser(int userId)
        {
            return Process.DeleteUser(userId);
        }

        public Core.Models.User UpdateUser(Core.Models.User user)
        {
            return Process.UpdateUser(user);
        }

        public bool UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            return Process.UpdatePassword(userId, oldPassword, newPassword);
        }

        public string ResetPassword(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
