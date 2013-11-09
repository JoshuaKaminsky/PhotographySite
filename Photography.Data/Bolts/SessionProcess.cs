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

        public Session CreateSession(int userId)
        {
            try
            {
                var newSession = new SessionEntity
                {
                    CreatedOn = DateTime.Now,
                    UserId = userId,
                    SessionKey = Guid.NewGuid()
                };

                newSession = UnitOfWork.Sessions.Add(newSession);
                UnitOfWork.Commit();

                return newSession.ToModel();
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
    }
}
