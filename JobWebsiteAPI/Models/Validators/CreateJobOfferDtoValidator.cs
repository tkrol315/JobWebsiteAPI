using FluentValidation;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models.JobOffer;
using Microsoft.EntityFrameworkCore;

namespace JobWebsiteAPI.Models.Validators
{
    public class CreateJobOfferDtoValidator : AbstractValidator<CreateJobOfferDto>
    {
        public CreateJobOfferDtoValidator()
        {
            RuleFor(c => c.GrossSalary).GreaterThan(0);
            RuleFor(c => c.HoursPerMonth).GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
