using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    /// <summary>
    /// Interface definition for interaction with Roles
    /// </summary>
    public interface IRoleService : IService
    {
        /// <summary>
        /// Retrieve a list of all roles
        /// </summary>
        /// <returns>List of all roles</returns>
        IEnumerable<Role> GetRoles();

        /// <summary>
        /// Retrieve a list of roles that a user belongs to
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>A list of roles that the user belongs to</returns>
        IEnumerable<Role> GetUseRoles(int userId);
        
        /// <summary>
        /// Create a role
        /// </summary>
        /// <param name="roleName">The name of the role to create</param>
        /// <returns>The created role</returns>
        Role CreateRole(string roleName);

        /// <summary>
        /// Add a user to a role
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="roleId">The id of the role</param>
        /// <returns>The user with roles collection populated</returns>
        User AddUserToRole(int userId, int roleId);
    }
}