using System;
using System.Collections.Generic;
using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using Photography.Core.Models;

namespace Photography.Service.Bolts
{
    internal class UserService : BaseService<IUserProcess>, IUserService
    {
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public UserService(IUserProcess process, IMailService mailService, IConfiguration configuration)
            : base(process)
        {
            _mailService = mailService;
            _configuration = configuration;
        }

        public IEnumerable<User> GetUsers()
        {
            return Process.GetUsers();
        }

        public User GetUser(int userId)
        {
            return Process.GetUserById(userId);
        }

        public User GetUserByEmailAddress(string emailAddress)
        {
            return Process.GetUserByEmail(emailAddress);
        }

        public bool ValidateUser(string emailAddress, string password)
        {
            return Process.ValidateUser(emailAddress, password);
        }

        public User CreateUser(string name, string emailAddress, decimal? discount, string password)
        {
            return Process.CreateUser(name, emailAddress, discount, password);
        }

        public User CreateUser(string name, string emailAddress, decimal? discount)
        {
            var user = Process.CreateUser(name, emailAddress, discount, Guid.NewGuid().ToString());

            ResetPasswordRequest(user.Id);

            return user;
        }

        public bool DeleteUser(int userId)
        {
            return Process.DeleteUser(userId);
        }

        public User UpdateUser(User user)
        {
            return Process.UpdateUser(user);
        }

        public bool UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            return Process.UpdatePassword(userId, oldPassword, newPassword);
        }

        public bool ResetPassword(int userId, string newPassword)
        {
            return Process.UpdatePassword(userId, newPassword);
        }

        public bool ResetPasswordRequest(int userId)
        {
            var request = Process.ResetPassword(userId);

            //send the email for resetting a password
            var @from = "me";
            var subject = "Password Reset Request";
            var url = string.Format("Account/ResetPassword/?userId={0}&token={1}", request.User.Id, request.Token);
            var body = string.Format("Dear {0}, \nplease use the following link to sign in and change your password.  \n{1}", request.User.Name, url);
            
            return _mailService.SendEmail(@from, request.User.EmailAddress, subject, body);
        }

        public bool ValidatePasswordReset(int userId, Guid token)
        {
            var request = Process.GetPasswordResetRequest(userId, token);

            if (DateTime.UtcNow - request.CreatedOn <= TimeSpan.FromMinutes(_configuration.PasswordResetRequestTimeoutInMinutes))
            {
                return Process.ExpirePasswordResetRequest(request);
            }

            return false;
        }
    }
}
