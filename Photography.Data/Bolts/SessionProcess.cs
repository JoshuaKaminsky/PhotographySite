using Photography.Core.Contracts.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Bolts
{
    public class SessionProcess : ISessionProcess
    {
        public Core.Models.Session CreateSession(int userId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateSession(int userId, Guid sessionKey)
        {
            throw new NotImplementedException();
        }
    }
}
