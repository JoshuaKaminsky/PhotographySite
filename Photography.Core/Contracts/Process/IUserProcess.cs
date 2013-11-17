using System;
using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface IUserProcess : IProcess
    {
        bool ValidateUser(string emailAddress, string password);

        IEnumerable<User> GetUsers();

        User GetUserById(int userId);

        User GetUserByEmail(string emailAddress);

        User CreateUser(string name, string emailAddress, decimal? discount, string password);

        bool DeleteUser(int userId);

        User UpdateUser(User user);

        bool UpdatePassword(int userId, string oldPassword, string newPassword);
        
        bool UpdatePassword(int userId, string newPassword);

        ResetPasswordRequest ResetPassword(int userId);

        ResetPasswordRequest GetPasswordResetRequest(int userId, Guid token);

        bool ExpirePasswordResetRequest(ResetPasswordRequest request);
    }
}