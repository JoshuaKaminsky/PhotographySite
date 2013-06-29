using Photography.Core.Models;

namespace Photography.Core.Contracts
{
    public interface IUserService
    {
        User CreateUser(string username, string password, string emailAddress);

        bool DeleteUser(int Id);

        User UpdateUser(User user);

        bool UpdatePassword(int Id, string oldPassword, string newPassword);
    }
}
