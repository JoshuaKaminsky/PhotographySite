using Photography.Core.Contracts.Service;
using WebMatrix.WebData;

namespace PhotographySite.Authorization
{
    public class CustomMembershipProvider : SimpleMembershipProvider
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;

        public CustomMembershipProvider(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        public override bool ValidateUser(string username, string password)
        {
            return _userService.ValidateUser(username, password);
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            //return base.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
            status = System.Web.Security.MembershipCreateStatus.Success;
            return null;
        }

    }
}