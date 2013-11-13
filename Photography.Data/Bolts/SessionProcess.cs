using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using System;
using System.Diagnostics;
using Photography.Data.Extensions;

namespace Photography.Data.Bolts
{
    internal class SessionProcess : BaseProcess, ISessionProcess
    {
        public SessionProcess(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public Session ResolveSession(int userId)
        {
            try
            {
                var session = UnitOfWork.Sessions.Get(entity => entity.UserId == userId);
                if (session == null)
                {
                    session = new SessionEntity
                    {
                        CreatedOn = DateTime.UtcNow,
                        UserId = userId,
                        SessionKey = Guid.NewGuid()
                    };

                    UnitOfWork.Sessions.Add(session);
                }
                else
                {
                    session.CreatedOn = DateTime.UtcNow;

                    session = UnitOfWork.Sessions.Update(session);
                }
                
                UnitOfWork.Commit();

                return session.ToModel();
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
                return null;
            }
        }

        public Session GetSession(int userId, Guid sessionKey)
        {
            try
            {
                return UnitOfWork.Sessions.Get(x => x.SessionKey == sessionKey && x.UserId == userId).ToModel();
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not retrieve session for user with id {0} and session key {1}. {2}", userId, sessionKey, exception.Message);
                Trace.TraceError(exception.ToString());

                return null;
            }
        }

        public bool InvalidateSession(int userId, Guid sessionKey)
        {
            try
            {
                var session = UnitOfWork.Sessions.Get(entity => entity.UserId == userId && entity.SessionKey == sessionKey);

                return UnitOfWork.Sessions.Delete(session);
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not invalidate session for user with id {0} and session key {1}. {2}", userId, sessionKey, exception.Message);
                Trace.TraceError(exception.ToString());

                return false;
                throw;
            }
        }
    }
}
