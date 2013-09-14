using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface IUserProcess : IProcess
    {
        bool ValidateUser(string emailAddress, string password);

        User GetUserById(int userId);

        User GetUserByEmail(string emailAddress);

        User CreateUser(string name, string emailAddress, string password);

        bool DeleteUser(int userId);

        User UpdateUser(User user);

        bool UpdatePassword(int userId, string oldPassword, string newPassword);
    }
}