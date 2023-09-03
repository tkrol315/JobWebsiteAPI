namespace JobWebsiteAPI.Entities
{
    public class CompanyAccount:Account
    {
        public string CompanyName { get; set; }
        public List<JobOffer> CreatedJobOffers { get; set; } = new List<JobOffer>();

    }
}
