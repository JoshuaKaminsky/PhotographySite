using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Photography.Core.Contracts;
using Photography.Core.Contracts.Service;
using WebMatrix.WebData;

namespace PhotographySite.Authorization
{
    public class CustomMembershipProvider : SimpleMembershipProvider
    {
        public CustomMembershipProvider(IUserService userService)
        {
            
        }
        
        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            //return base.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
            status = System.Web.Security.MembershipCreateStatus.Success;
            return null;
        }

    }
}