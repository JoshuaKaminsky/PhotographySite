using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class RoleService : BaseService<IRoleProcess>, IRoleService
    {
        public RoleService(IRoleProcess roleProcess)
            : base(roleProcess)
        {
        }

        public IEnumerable<Role> GetRoles()
        {
            return Process.GetRoles();
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return Process.GetUserRoles(userId);
        }

        public Role CreateRole(string roleName)
        {
            return Process.CreateRole(roleName);
        }

        public User AddUserToRole(int userId, int roleId)
        {
            return Process.AddUserToRole(userId, roleId);
        }
    }
}
