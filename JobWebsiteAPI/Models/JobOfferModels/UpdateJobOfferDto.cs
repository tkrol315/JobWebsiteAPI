﻿namespace JobWebsiteAPI.Models.JobOffer
{
    public class UpdateJobOfferDto
    {
        public decimal GrossSalary { get; set; }
        public int HoursPerMonth { get; set; }
        public string Description { get; set; }
    }
}
