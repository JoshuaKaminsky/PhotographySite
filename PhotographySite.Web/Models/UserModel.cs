using System.Collections.Generic;
using Photography.Core.Models;

namespace PhotographySite.Models
{
    public class UserModel
    {
        public UserModel()
        {
            User = new User();
            UserRoleIds = new List<int>();
            AvailableRoles = new List<Role>();
        }

        public User User { get; set; }

        public List<int> UserRoleIds { get; set; }

        public List<Role> AvailableRoles { get; set; }
    }
}