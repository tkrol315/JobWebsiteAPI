namespace JobWebsiteAPI.Models
{
    public class CreateJobOfferDto
    {
        public decimal GrossSalary { get; set; }
        public int HoursPerMonth { get; set; }
        public string Description { get; set; }
        public HashSet<int> ContractTypes { get; set; } 
    }
}
