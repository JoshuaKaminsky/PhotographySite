using System;

namespace PhotographySite.Models
{
    public class SessionModel
    {
        public int UserId { get; set; }

        public Guid SessionKey { get; set; }
    }
}