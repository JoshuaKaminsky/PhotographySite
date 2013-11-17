using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using System;

namespace Photography.Service.Bolts
{
    internal class SessionService : BaseService<ISessionProcess>, ISessionService
    {
        private const int SessionTimeoutInMinutes = 30;

        public SessionService(ISessionProcess process) 
            : base(process)
        {
        }

        public Core.Models.Session CreateSession(int userId)
        {
            return Process.ResolveSession(userId);
        }

        public bool ValidateSession(int userId, Guid sessionKey)
        {
            var session = Process.GetSession(userId, sessionKey);
            if (session == null)
            {
                return false;
            }

            if (DateTime.UtcNow - session.CreatedOn <= TimeSpan.FromMinutes(SessionTimeoutInMinutes))
            {
                //update the current time on the session
                Process.ResolveSession(userId);

                return true;
            }
                
            return false;
        }

        public bool InvalidateSession(int userId, Guid sessionKey)
        {
            return Process.InvalidateSession(userId, sessionKey);
        }
    }
}
