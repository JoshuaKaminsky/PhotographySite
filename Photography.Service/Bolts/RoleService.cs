using System.Linq;
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

        public bool UpdateUserRoles(int userId, List<int> roleIds)
        {
            var userRoleIds = Process.GetUserRoles(userId).Select(role => role.Id).ToList();

            var newRoles = roleIds.Except(userRoleIds);
            var rolesToRemove = userRoleIds.Except(roleIds);

            foreach (var roleId in newRoles)
            {
                Process.AddUserToRole(userId, roleId);
            }

            foreach (var roleId in rolesToRemove)
            {
                Process.RemoveUserFromRole(userId, roleId);
            }

            return true;
        }
    }
}
