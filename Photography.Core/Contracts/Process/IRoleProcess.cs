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

        User AddUserToRole(int userId, int roleId);

        bool IsInRole(int userId, string roleName);
    }
}