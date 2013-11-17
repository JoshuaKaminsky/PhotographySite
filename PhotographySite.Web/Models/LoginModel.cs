namespace PhotographySite.Models
{
    public class LoginModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}