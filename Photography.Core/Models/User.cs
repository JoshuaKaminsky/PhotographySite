namespace Photography.Core.Models
{
    public class User : BaseModel
    {
        public User()
        {
            IsActive = true;
        }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public decimal? Discount { get; set; }

        public bool IsActive { get; set; }
    }
}
