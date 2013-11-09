using System;
using System.Collections.Generic;
using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class UserService : BaseService<IUserProcess>, IUserService
    {
        public UserService(IUserProcess process)
            : base(process)
        {
        }

        public IEnumerable<User> GetUsers()
        {
            return Process.GetUsers();
        }

        public User GetUser(int userId)
        {
            return Process.GetUserById(userId);
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

        public User CreateUser(string name, string emailAddress)
        {
            var user = Process.CreateUser(name, emailAddress, Guid.NewGuid().ToString());

            this.ResetPasswordRequest(user.Id);

            return user;
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

        public bool ResetPasswordRequest(int userId)
        {
            var request = Process.ResetPassword(userId);

            //send the email for resetting a password

            return true;
        }

    }
}
