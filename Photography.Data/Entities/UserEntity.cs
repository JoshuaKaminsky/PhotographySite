using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Entities
{
    internal class UserEntity
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
