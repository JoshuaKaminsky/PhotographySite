using Photography.Core.Contracts.Process;
using Photography.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Bolts
{
    public class RoleProcess : IRoleProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsInRole(int userId, string roleName)
        {
            try
            {
                var userEntity = _unitOfWork.Users.Get(user => user.Id == userId, new List<string> { "Roles" });
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
