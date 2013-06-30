﻿using Photography.Core.Models;
namespace Photography.Core.Contracts.Process
{
    public interface IUserProcess
    {
        User CreateUser(string emailAddress, string password);

        bool DeleteUser(int Id);

        User UpdateUser(User user);

        bool UpdatePassword(int Id, string oldPassword, string newPassword);
    }
}