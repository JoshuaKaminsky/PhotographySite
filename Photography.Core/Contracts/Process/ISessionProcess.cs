using System;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface ISessionProcess : IProcess
    {
        /// <summary>
        /// Create or update a new session
        /// </summary>
        /// <param name="userId"> The id of the user to create a session for </param>
        /// <returns> The created session </returns>
        Session ResolveSession(int userId);

        /// <summary>
        /// Retrieve the session for the given user
        /// </summary>
        /// <param name="userId"> The user to retrieve the session for </param>
        /// <param name="sessionKey"> The session key </param>
        /// <returns> The user session if found, otherwise null </returns>
        Session GetSession(int userId, Guid sessionKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"> The user to invalidate the session for </param>
        /// <param name="sessionKey"> The session key </param>
        /// <returns></returns>
        bool InvalidateSession(int userId, Guid sessionKey);
    }
}
