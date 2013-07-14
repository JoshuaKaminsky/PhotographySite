using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using System;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetUseRoles(int userId)
        {
            throw new NotImplementedException();
        }

        public Role CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public User AddUserToRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
