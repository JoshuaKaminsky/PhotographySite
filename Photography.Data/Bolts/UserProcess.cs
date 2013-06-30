using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    internal class UserProcess : IUserProcess
    {
        private static readonly RNGCryptoServiceProvider RngCryptoServiceProvider = new RNGCryptoServiceProvider();

        private readonly IUnitOfWork _unitOfWork;

        public UserProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(string emailAddress, string password)
        {
            var user = _unitOfWork.Users.Get(u => u.EmailAddress.Equals(emailAddress), new List<string> { "Roles" });
            if (user == null)
                throw new AuthenticationException("Invalid Username.");

            if (!IsPasswordValid(password, user.Salt, user.Password))
                throw new AuthenticationException("Invalid Password.");

            return user.ToModel();
        }

        public User GetUserById(int userId)
        {
            try
            {
                return _unitOfWork.Users.GetById(userId).ToModel();
            }
            catch (Exception exception)
            {
                Trace.TraceError("Could not retrieve user by id with id {0}. {1}", userId, exception.Message);
                Trace.TraceError(exception.ToString());

                return null;
            }
        }

        public User CreateUser(string emailAddress, string password)
        {
            var oldUser = _unitOfWork.Users.Get(user => user.EmailAddress.Equals(emailAddress));
            if (oldUser != null)
                throw new DataException("Email address already exists.");
            var assessorRole = _unitOfWork.Roles.Get(role => role.Name.Equals("guest", StringComparison.InvariantCultureIgnoreCase));

            var salt = CreateSalt();
            var passwordHash = GetPasswordHash(password, salt);

            var newUser = new UserEntity
            {
                Password = passwordHash,
                Salt = salt,
                EmailAddress = emailAddress
            };

            newUser.Roles.Add(assessorRole);

            newUser = _unitOfWork.Users.Add(newUser);
            _unitOfWork.Commit();

            return newUser.ToModel();
        }

        public bool DeleteUser(int userId)
        {
            var user = _unitOfWork.Users.GetById(userId);
            if (user == null)
                return true;

            return _unitOfWork.Users.Delete(userId);
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _unitOfWork.Users.GetById(userId);
            if (user == null)
                throw new DataException(String.Format("User with Id {0} does not exist", userId));

            if (!IsPasswordValid(oldPassword, user.Salt, user.Password))
                throw new DataException("Could not update password; Invalid old password");

            user.Salt = CreateSalt();
            user.Password = GetPasswordHash(newPassword, user.Salt);

            _unitOfWork.Users.Update(user);
            _unitOfWork.Commit();

            return true;
        }

        private bool IsPasswordValid(string password, string salt, string hash)
        {
            var passwordHash = GetPasswordHash(password, salt);

            return passwordHash.Equals(hash);
        }

        internal static string GetPasswordHash(string password, string salt)
        {
            return Encoding.UTF8.GetString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(password + salt)));
        }

        internal static string CreateSalt()
        {
            var data = new byte[4];

            RngCryptoServiceProvider.GetBytes(data);

            return BitConverter.ToInt32(data, 0).ToString();
        }

    }
}
