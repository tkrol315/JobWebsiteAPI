namespace JobWebsiteAPI.Models.JobOffer
{
    public class GetJobOfferDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public decimal GrossSalary { get; set; }
        public int HoursPerMonth { get; set; }
        public string Description { get; set; }
        public List<string> ContractTypeNames { get; set; }
        public List<string> TagNames { get; set; }
    }
}
