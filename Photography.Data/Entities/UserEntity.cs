namespace Photography.Data.Entities
{
    internal class UserEntity : BaseEntity
    {
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
