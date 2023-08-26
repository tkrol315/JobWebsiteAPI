namespace JobWebsiteAPI.Entities
{
    public class CompanyAccount:Account
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<JobOffer> CreatedJobOffers { get; set; }

    }
}
