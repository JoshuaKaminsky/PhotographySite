using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    /// <summary>
    /// Interface definition for interaction with Users
    /// </summary>
    public interface IUserService : IService
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="emailAddress">The users email address</param>
        /// <param name="password">The users password</param>
        /// <returns>The created user</returns>
        User CreateUser(string emailAddress, string password);

        /// <summary>
        /// Delete a user from the system
        /// </summary>
        /// <param name="userId">The id of the user to delete</param>
        /// <returns>True if the user was deleted, otherwise false</returns>
        bool DeleteUser(int userId);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">The user information to update</param>
        /// <returns>The updated user</returns>
        User UpdateUser(User user);

        /// <summary>
        /// Update a users password
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="oldPassword">The users old password</param>
        /// <param name="newPassword">The users new password</param>
        /// <returns></returns>
        bool UpdatePassword(int userId, string oldPassword, string newPassword);

        /// <summary>
        /// Reset a users password
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>The new password</returns>
        /// <remarks>This is for internal/admin user only</remarks>
        string ResetPassword(int userId);
    }
}
