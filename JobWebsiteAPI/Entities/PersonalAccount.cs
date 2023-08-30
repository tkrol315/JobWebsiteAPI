namespace JobWebsiteAPI.Entities
{
    public class PersonalAccount : Account
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<JobOffer> AppliedJobOffers { get; set; }= new List<JobOffer>();

    }
}
