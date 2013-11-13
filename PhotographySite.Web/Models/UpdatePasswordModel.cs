namespace PhotographySite.Models
{
    public class UpdatePasswordModel
    {
        public string OldPassword { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}