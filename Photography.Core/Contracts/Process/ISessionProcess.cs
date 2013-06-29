using System;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface ISessionProcess
    {
        Session CreateSession(int userId);

        bool ValidateSession(int userId, Guid sessionKey);
    }
}
