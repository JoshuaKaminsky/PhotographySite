using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Process
{
    public interface IRoleProcess : IProcess
    {
        Role GetRole(int roleId);

        IEnumerable<Role> GetRoles();

        IEnumerable<Role> GetUserRoles(int userId);

        Role CreateRole(string name);

        bool AddUserToRole(int userId, int roleId);

        bool RemoveUserFromRole(int userId, int roleId);

        bool IsInRole(int userId, string roleName);
    }
}