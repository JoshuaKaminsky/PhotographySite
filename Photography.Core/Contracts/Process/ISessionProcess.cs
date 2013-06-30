using System;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface ISessionProcess
    {
        Session CreateSession(int userId);

        Session GetSession(int userId, Guid sessionKey);
    }
}
