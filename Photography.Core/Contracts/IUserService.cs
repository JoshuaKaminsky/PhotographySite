using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotographySite.Core.Contracts
{
    public interface IUserService
    {
        User CreateUser(string username, string password, string emailAddress);

        bool DeleteUser(int ID);

        User UpdateUser(User user);

        bool UpdatePassword(int ID, string oldPassword, string newPassword);
    }
}
