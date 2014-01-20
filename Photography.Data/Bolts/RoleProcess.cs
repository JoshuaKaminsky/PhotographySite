using System.Linq;
using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Photography.Data.Entities;
using Photography.Data.Extensions;

namespace Photography.Data.Bolts
{
    internal class RoleProcess : BaseProcess, IRoleProcess
    {
        public RoleProcess(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public Role GetRole(int roleId)
        {
            return UnitOfWork.Roles.GetById(roleId).ToModel();
        }

        public IEnumerable<Role> GetRoles()
        {
            return UnitOfWork.Roles.GetAll().ToList().Select(role => role.ToModel());
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            try
            {
                var userEntity = UnitOfWork.Users.Get(user => user.Id == userId, new[] { "Roles" });
                if (userEntity == null)
                    throw new Exception(string.Format("Could not find user with {0}.", userId));

                return userEntity.Roles.Select(role => role.ToModel());
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not retrieve role names for user with id {0}. {1}", userId, exception.Message);
                Trace.TraceError(exception.ToString());

                return null;
            }
        }

        public Role CreateRole(string name)
        {
            var roleEntity = UnitOfWork.Roles.Get(role => role.Name == name);
            if (roleEntity == null)
            {
                roleEntity = new RoleEntity()
                    {
                        Name = name
                    };

                UnitOfWork.Roles.Add(roleEntity);
                UnitOfWork.Commit();
            }

            return roleEntity.ToModel();
        }

        public bool AddUserToRole(int userId, int roleId)
        {
            var user = UnitOfWork.Users.GetById(userId);
            var role = UnitOfWork.Roles.GetById(roleId);

            user.Roles.Add(role);

            UnitOfWork.Users.Update(user);

            UnitOfWork.Commit();

            return true;
        }

        public bool RemoveUserFromRole(int userId, int roleId)
        {
            var user = UnitOfWork.Users.GetById(userId);
            var role = UnitOfWork.Roles.GetById(roleId);

            user.Roles.Remove(role);

            UnitOfWork.Users.Update(user);

            UnitOfWork.Commit();

            return true;
        }

        public bool IsInRole(int userId, string roleName)
        {
            try
            {
                var userEntity = UnitOfWork.Users.Get(user => user.Id == userId, new [] { "Roles" });
                if (userEntity == null)
                    throw new Exception(string.Format("Could not find user with {0}.", userId));

                return userEntity.Roles.Any(role => role.Name.Equals(roleName));
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not retrieve role name {0} for user with id {1}. {2}", roleName, userId, exception.Message);
                Trace.TraceError(exception.ToString());

                return false;
            }
        }
    }
}
