namespace JobWebsiteAPI.Entities
{
    public abstract class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public int AccountTypeId { get; set; }
       

    }
}
