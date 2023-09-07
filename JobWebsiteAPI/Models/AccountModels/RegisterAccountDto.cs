using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace JobWebsiteAPI.Models.AccountModels
{
    public class RegisterAccountDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
