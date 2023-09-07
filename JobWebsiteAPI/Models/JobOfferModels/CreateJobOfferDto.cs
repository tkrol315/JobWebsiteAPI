using JobWebsiteAPI.Entities;

namespace JobWebsiteAPI.Models.JobOffer
{
    public class CreateJobOfferDto
    {
        public decimal GrossSalary { get; set; }
        public int HoursPerMonth { get; set; }
        public string Description { get; set; }
    }
}
