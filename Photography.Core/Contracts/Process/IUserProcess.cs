using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface IUserProcess : IProcess
    {
        User GetUser(string emailAddress, string password);

        User GetUserById(int userId);

        User CreateUser(string emailAddress, string password);

        bool DeleteUser(int userId);

        User UpdateUser(User user);

        bool UpdatePassword(int userId, string oldPassword, string newPassword);
    }
}