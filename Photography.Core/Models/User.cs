using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Core.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public decimal Discount { get; set; }
    }
}
