﻿namespace JobWebsiteAPI.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobOffer> JobOffers { get; set; }
    }
}
