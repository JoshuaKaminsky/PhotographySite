using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    public interface IUserService
    {
        User CreateUser(string emailAddress, string password);

        bool DeleteUser(int userId);

        User UpdateUser(User user);

        bool UpdatePassword(int userId, string oldPassword, string newPassword);
    }
}
