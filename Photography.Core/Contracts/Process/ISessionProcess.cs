using System;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface ISessionProcess : IProcess
    {
        Session CreateSession(int userId);

        Session GetSession(int userId, Guid sessionKey);
    }
}
