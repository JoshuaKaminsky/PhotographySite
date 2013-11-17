using System;

namespace PhotographySite.Models
{
    public class ResetPasswordModel
    {
        public int UserId { get; set; }

        public Guid Token { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}