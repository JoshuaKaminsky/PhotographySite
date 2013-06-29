using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Entities
{
    internal class SessionEntity
    {
        public int Id { get; set; }

        public Guid SessionKey { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
