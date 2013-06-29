using PhotographySite.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Service
{
    public class UserService : IUserService
    {
        public Core.Models.User CreateUser(string username, string password, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int ID)
        {
            throw new NotImplementedException();
        }

        public Core.Models.User UpdateUser(Core.Models.User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(int ID, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
