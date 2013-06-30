using System.Data;
using System.Security.Authentication;
using System.Security.Cryptography;
using Photography.Core.Contracts.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;

namespace Photography.Data.Bolts
{
    public class UserProcess : IUserProcess
    {
        private static readonly RNGCryptoServiceProvider RngCryptoServiceProvider = new RNGCryptoServiceProvider();

        private readonly IUnitOfWork _unitOfWork;

        public UserProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public User GetUser(string userName, string password)
        //{
        //    var user = _unitOfWork.Users.Get(u => u.UserName.Equals(userName), new List<string> { "Roles" });
        //    if (user == null)
        //        throw new AuthenticationException("Invalid Username.");

        //    if (!GetPasswordHash(password, user.PasswordSalt).Equals(user.PasswordHash))
        //        throw new AuthenticationException("Invalid Password.");

        //    return user.ToModel();
        //}

        //public User GetUserById(int userId)
        //{
        //    try
        //    {
        //        return _unitOfWork.Users.GetById(userId).ToModel();
        //    }
        //    catch (Exception exception)
        //    {
        //        Trace.TraceError("Could not retrieve user by id with id {0}. {1}", userId, exception.Message);
        //        Trace.TraceError(exception.ToString());

        //        return null;
        //    }
        //}

        //public User CreateUser(string userName, string password, string firstName, string lastName)
        //{
        //    var oldUser = _unitOfWork.Users.Get(user => user.UserName.Equals(userName));
        //    if (oldUser != null)
        //        throw new DataException("Username already exists.");

        //    var assessorRole = _unitOfWork.Roles.Get(role => role.Name.Equals("guest", StringComparison.InvariantCultureIgnoreCase));

        //    var salt = CreateSalt();
        //    var passwordHash = GetPasswordHash(password, salt);

        //    var newUser = new Entity.User()
        //    {
        //        IsActive = true,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = salt,
        //        UserName = userName,
        //        FirstName = firstName,
        //        LastName = lastName
        //    };

        //    newUser.Roles.Add(assessorRole);

        //    newUser = _unitOfWork.Users.Add(newUser);
        //    _unitOfWork.Commit();

        //    return newUser.ToModel();
        //}

        //public bool ChangePassword(int userId, string newPassword)
        //{
        //    var user = _unitOfWork.Users.GetById(userId);
        //    if (user == null)
        //        throw new DataException(string.Format("User with id {0} does not exist.", userId));

        //    var salt = CreateSalt();
        //    var passwordHash = GetPasswordHash(newPassword, salt);

        //    user.PasswordSalt = salt;
        //    user.PasswordHash = passwordHash;

        //    _unitOfWork.Users.Update(user);
        //    _unitOfWork.Commit();

        //    return true;
        //}

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

        public bool DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(int Id, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        internal static string GetPasswordHash(string password, int salt)
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
