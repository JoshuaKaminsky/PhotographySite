using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;

namespace Photography.Service.Bolts
{
    using Photography.Core.Models;

    internal class UserService : BaseService<IUserProcess>, IUserService
    {
        public UserService(IUserProcess process)
            : base(process)
        {
        }

        public User GetUserByEmailAddress(string emailAddress)
        {
            return Process.GetUserByEmail(emailAddress);
        }

        public bool ValidateUser(string emailAddress, string password)
        {
            return Process.ValidateUser(emailAddress, password);
        }

        public User CreateUser(string name, string emailAddress, string password)
        {
            return Process.CreateUser(name, emailAddress, password);
        }

        public bool DeleteUser(int userId)
        {
            return Process.DeleteUser(userId);
        }

        public User UpdateUser(User user)
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
