using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using System;

namespace Photography.Service.Bolts
{
    internal class SessionService : BaseService<ISessionProcess>, ISessionService
    {
        public SessionService(ISessionProcess process) 
            : base(process)
        {
        }

        public Core.Models.Session CreateSession(int userId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateSession(int userId, Guid sessionKey)
        {
            throw new NotImplementedException();
        }

        public bool InvalidateSession(int userId, Guid sessionKey)
        {
            throw new NotImplementedException();
        }
    }
}
