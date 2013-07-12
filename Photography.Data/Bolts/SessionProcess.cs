using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Data.Extensions;

namespace Photography.Data.Bolts
{
    public class SessionProcess : ISessionProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Models.Session CreateSession(int userId)
        {
            try
            {
                var newSession = new SessionEntity
                {
                    CreatedOn = DateTime.Now,
                    UserId = userId,
                    SessionKey = Guid.NewGuid()
                };

                newSession = _unitOfWork.Sessions.Add(newSession);
                _unitOfWork.Commit();

                return newSession.ToModel();
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
                return null;
            }
        }

        public Core.Models.Session GetSession(int userId, Guid sessionKey)
        {
            try
            {
                return _unitOfWork.Sessions.Get(x => x.SessionKey == sessionKey && x.UserId == userId).ToModel();
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
