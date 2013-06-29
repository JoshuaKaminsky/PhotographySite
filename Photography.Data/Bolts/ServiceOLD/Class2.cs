using System;
using System.Diagnostics;
using BaseMvc.Data.Contract;
using BaseMvc.Data.Extension;

namespace BaseMvc.Data.Bolts.Service
{
    internal class SessionService : ISessionService
    {
        private const int SessionTimeoutInMinutes = 60;

        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Model.Session Login(int userId)
        {
            var session = _unitOfWork.Sessions.Get(s => s.UserId == userId);
            if (session == null)
            {
                session = new Entity.Session()
                {
                    CreatedOn = DateTime.UtcNow,
                    SessionId = Guid.NewGuid(),
                    UserId = userId
                };

                _unitOfWork.Sessions.Add(session);
            }
            else
            {
                session.SessionId = Guid.NewGuid();
                session.CreatedOn = DateTime.UtcNow;

                _unitOfWork.Sessions.Update(session);
            }

            _unitOfWork.Commit();

            return session.ToModel();
        }

        public bool Logout(int userId)
        {
            var session = _unitOfWork.Sessions.Get(s => s.UserId == userId);
            if (session == null)
                return true;

            var result = _unitOfWork.Sessions.Delete(session);
            _unitOfWork.Commit();

            return result;
        }

        public bool IsValid(int userId, Guid sessionId)
        {
            try
            {
                var session = _unitOfWork.Sessions.Get(s => s.UserId == userId && s.SessionId == sessionId);
                if (session == null)
                    return false;

                if (session.CreatedOn < DateTime.UtcNow.AddMinutes(-1 * SessionTimeoutInMinutes))
                {
                    Logout(userId);
                    return false;
                }

                session.CreatedOn = DateTime.UtcNow;

                _unitOfWork.Sessions.Update(session);

                return true;
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not validate authorization for userId {0} and session {1}. {2}", userId, sessionId, exception.Message);
                Trace.TraceError(exception.ToString());

                return false;
            }
        }
    }
}
