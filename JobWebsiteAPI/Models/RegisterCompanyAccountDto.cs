﻿namespace JobWebsiteAPI.Models
{
    public class RegisterCompanyAccountDto : RegisterAccountDto
    {
        public string CompanyName { get; set; }
        public int AccountTypeId { get; set; } = 1;
    }
}