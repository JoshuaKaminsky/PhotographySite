using System;
using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    /// <summary>
    /// Interface definition for interaction with Users
    /// </summary>
    public interface IUserService : IService
    {
        /// <summary>
        /// Retrieve a list of all users
        /// </summary>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Retrieve a user by id
        /// </summary>
        /// <param name="userId">The users email address</param>
        User GetUser(int userId);

        /// <summary>
        /// Retrieve a user
        /// </summary>
        /// <param name="emailAddress">The users email address</param>
        /// <returns>A user if found, otherwise null</returns>
        User GetUserByEmailAddress(string emailAddress);

        /// <summary>
        /// Validate a user
        /// </summary>
        /// <param name="emailAddress">The users email address</param>
        /// <param name="password">The users password</param>
        /// <returns>True if the email address and password match</returns>
        bool ValidateUser(string emailAddress, string password);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="name">The users name</param>
        /// <param name="emailAddress">The users email address</param>
        /// <param name="discount"> The discount for the user</param>
        /// <param name="password">The users password</param>
        /// <returns>The created user</returns>
        User CreateUser(string name, string emailAddress, decimal? discount, string password);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="name">The users name</param>
        /// <param name="emailAddress">The users email address</param>
        /// <param name="discount">The user discount</param>
        /// <returns>The created user</returns>
        /// <remarks> Will create a default password and email the user </remarks>
        User CreateUser(string name, string emailAddress, decimal? discount);

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
        /// <returns>True if successful </returns>
        bool UpdatePassword(int userId, string oldPassword, string newPassword);

        /// <summary>
        /// Reset a users password to something new
        /// </summary>
        /// <param name="userId"> The id of the user </param>
        /// <param name="newPassword"> The new password </param>
        /// <returns> True if successful </returns>
        bool ResetPassword(int userId, string newPassword);

        /// <summary>
        /// Reset a users password
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>The new password</returns>
        /// <remarks>This is for internal/admin user only</remarks>
        bool ResetPasswordRequest(int userId);

        /// <summary>
        /// Validate a password reset request
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <param name="token"> The password reset token </param>
        /// <returns> True if valid </returns>
        bool ValidatePasswordReset(int userId, Guid token);
    }
}
