using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using Photography.Core.Contracts.Process;
using System;
using System.Text;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using Photography.Data.Extensions;

namespace Photography.Data.Bolts
{
    internal class UserProcess : BaseProcess, IUserProcess
    {
        private static readonly RNGCryptoServiceProvider RngCryptoServiceProvider = new RNGCryptoServiceProvider();

        public UserProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public bool ValidateUser(string emailAddress, string password)
        {
            var user = UnitOfWork.Users.Get(u => u.EmailAddress.Equals(emailAddress), new[] { "Roles" });
            if (user == null)
                throw new AuthenticationException("Invalid Username.");

            if (!IsPasswordValid(password, user.Salt, user.Password))
                throw new AuthenticationException("Invalid Password.");

            return user != null;
        }

        public IEnumerable<User> GetUsers()
        {
            return UnitOfWork.Users.GetAll().ToList().Select(user => user.ToModel());
        }

        public User GetUserById(int userId)
        {
            try
            {
                return UnitOfWork.Users.GetById(userId).ToModel();
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not retrieve user by id with id {0}. {1}", userId, exception.Message);
                Trace.TraceError(exception.ToString());

                return null;
            }
        }

        public User GetUserByEmail(string emailAddress)
        {
            try
            {
                return UnitOfWork.Users.Get(user => user.EmailAddress.Equals(emailAddress)).ToModel();
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not retrieve user by id with email address {0}. {1}", emailAddress, exception.Message);
                Trace.TraceError(exception.ToString());

                return null;
            }
        }

        public User CreateUser(string name, string emailAddress, decimal? discount, string password)
        {
            var oldUser = UnitOfWork.Users.Get(user => user.EmailAddress.Equals(emailAddress));
            if (oldUser != null)
                throw new DataException("Email address already exists.");
            var assessorRole = UnitOfWork.Roles.Get(role => role.Name.Equals("guest", StringComparison.InvariantCultureIgnoreCase));

            var salt = CreateSalt();
            var passwordHash = GetPasswordHash(password, salt);

            var newUser = new UserEntity
            {
                Discount = discount,
                EmailAddress = emailAddress,
                Name = name,
                Password = passwordHash,
                Salt = salt,
            };

            newUser.Roles.Add(assessorRole);

            newUser = UnitOfWork.Users.Add(newUser);
            UnitOfWork.Commit();

            return newUser.ToModel();
        }

        public bool DeleteUser(int userId)
        {
            var user = UnitOfWork.Users.GetById(userId);
            if (user == null)
                return true;

            UnitOfWork.Users.Delete(userId);
            UnitOfWork.Commit();

            return true;
        }

        public User UpdateUser(User user)
        {
            var entity = UnitOfWork.Users.GetById(user.Id);

            entity.Discount = user.Discount;
            entity.EmailAddress = user.EmailAddress;
            entity.Name = user.Name;

            UnitOfWork.Users.Update(entity);
            UnitOfWork.Commit();

            return user;
        }

        public bool UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            var user = UnitOfWork.Users.GetById(userId);
            if (user == null)
                throw new DataException(String.Format("User with Id {0} does not exist", userId));

            if (!IsPasswordValid(oldPassword, user.Salt, user.Password))
                throw new DataException("Could not update password; Invalid old password");

            user.Salt = CreateSalt();
            user.Password = GetPasswordHash(newPassword, user.Salt);

            UnitOfWork.Users.Update(user);
            UnitOfWork.Commit();

            return true;
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            var user = UnitOfWork.Users.GetById(userId);
            if (user == null)
                throw new DataException(String.Format("User with Id {0} does not exist", userId));

            user.Salt = CreateSalt();
            user.Password = GetPasswordHash(newPassword, user.Salt);

            UnitOfWork.Users.Update(user);
            UnitOfWork.Commit();

            return true;
        }

        public ResetPasswordRequest ResetPassword(int userId)
        {
            var user = UnitOfWork.Users.GetById(userId);

            var request = new ResetPasswordRequestEntity()
                {
                    CreatedOn = DateTime.UtcNow,
                    Token = Guid.NewGuid(),
                    User = user
                };

            UnitOfWork.ResetPasswordRequests.Add(request).ToModel();
            UnitOfWork.Commit();

            return request.ToModel();
        }

        public ResetPasswordRequest GetPasswordResetRequest(int userId, Guid token)
        {
            var request = UnitOfWork.ResetPasswordRequests.Get(r => r.Token == token && r.UserId == userId, new[] {"User"});
            if (request == null)
            {
                throw new DataException(string.Format("Could not find password reset request with token {0}.", token));
            }

            return request.ToModel();
        }

        public bool ExpirePasswordResetRequest(ResetPasswordRequest request)
        {
            request.UsedOn = DateTime.UtcNow;

            UnitOfWork.ResetPasswordRequests.Update(request.ToEntity());

            return true;
        }

        private static bool IsPasswordValid(string password, string salt, byte[] hash)
        {
            var passwordHash = GetPasswordHash(password, salt);

            return passwordHash.SequenceEqual(hash);
        }

        internal static byte[] GetPasswordHash(string password, string salt)
        {
            return new SHA256Managed().ComputeHash(Encoding.Unicode.GetBytes(password + salt));
        }

        internal static string CreateSalt()
        {
            var data = new byte[4];

            RngCryptoServiceProvider.GetBytes(data);

            return BitConverter.ToInt32(data, 0).ToString();
        }

    }
}
