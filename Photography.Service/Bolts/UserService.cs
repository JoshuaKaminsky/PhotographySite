using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;

namespace Photography.Service.Bolts
{
    internal class UserService : IUserService
    {
        private readonly IUserProcess _userProcess;

        public UserService(IUserProcess userProcess)
        {
            _userProcess = userProcess;
        }

        public Core.Models.User CreateUser(string emailAddress, string password)
        {
            return _userProcess.CreateUser(emailAddress, password);
        }

        public bool DeleteUser(int userId)
        {
            return _userProcess.DeleteUser(userId);
        }

        public Core.Models.User UpdateUser(Core.Models.User user)
        {
            return _userProcess.UpdateUser(user);
        }

        public bool UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            return _userProcess.UpdatePassword(userId, oldPassword, newPassword);
        }
    }
}
