using System;
using Photography.Core.Contracts.Service;

namespace Photography.Service
{
    internal class UserService : IUserService
    {
        public UserService()
        {

        }

        public Core.Models.User CreateUser(string username, string password, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Core.Models.User UpdateUser(Core.Models.User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(int Id, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
