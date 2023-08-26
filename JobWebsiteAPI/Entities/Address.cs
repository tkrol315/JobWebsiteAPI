namespace JobWebsiteAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }

    }
}
