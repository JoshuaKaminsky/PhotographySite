using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface IUserProcess
    {
        User CreateUser(string emailAddress, string password);

        bool DeleteUser(int id);

        User UpdateUser(User user);

        bool UpdatePassword(int id, string oldPassword, string newPassword);
    }
}