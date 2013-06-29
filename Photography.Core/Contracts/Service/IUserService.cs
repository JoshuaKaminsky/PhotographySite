using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    public interface IUserService
    {
        User CreateUser(string username, string password, string emailAddress);

        bool DeleteUser(int id);

        User UpdateUser(User user);

        bool UpdatePassword(int id, string oldPassword, string newPassword);
    }
}
