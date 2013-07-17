using System;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    /// <summary>
    /// Interface definition for interactions with Sessions
    /// </summary>
    public interface ISessionService : IService
    {
        /// <summary>
        /// Create a new session
        /// </summary>
        /// <param name="userId">The id of the user to create a session for</param>
        /// <returns>The created session</returns>
        Session CreateSession(int userId);

        /// <summary>
        /// Validate if a session is currently active
        /// </summary>
        /// <param name="userId">The user id for this session</param>
        /// <param name="sessionKey">The key for this session</param>
        /// <returns>True if the session is valid, otherwise false</returns>
        bool ValidateSession(int userId, Guid sessionKey);

        /// <summary>
        /// Invalidate a session if active
        /// </summary>
        /// <param name="userId">The user id for this session</param>
        /// <param name="sessionKey">The key for this session</param>
        /// <returns>True if the session was invalidated, otherwise false</returns>
        bool InvalidateSession(int userId, Guid sessionKey);
    }
}
