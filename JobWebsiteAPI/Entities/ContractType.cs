namespace JobWebsiteAPI.Entities
{
    public class ContractType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}
