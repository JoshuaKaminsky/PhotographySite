namespace Photography.Core.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public decimal Discount { get; set; }
    }
}
