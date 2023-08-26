namespace JobWebsiteAPI.Entities
{
    public class JobOffer
    {
        public int Id { get; set; }
        public List<ContractType> ContractTypes { get; set; } = new List<ContractType>();
        public decimal GrossSalary { get; set; }
        public int HoursPerMonth { get; set; }
        public string Description { get; set; }
        public CompanyAccount Creator { get; set; }
        public int CreatorId { get; set; }
        public List<PersonalAccount> AccountsThatAplied { get; set; }
        public List<Tag> Tags = new List<Tag>();
        
    }
}
