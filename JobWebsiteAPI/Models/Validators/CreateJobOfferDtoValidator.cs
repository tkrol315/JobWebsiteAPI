using FluentValidation;
using JobWebsiteAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobWebsiteAPI.Models.Validators
{
    public class CreateJobOfferDtoValidator : AbstractValidator<CreateJobOfferDto>
    {
        public CreateJobOfferDtoValidator(JobWebsiteDbContext dbContext)
        {
            RuleFor(c => c.ContractTypes).NotEmpty();
            RuleFor(c => c.GrossSalary).GreaterThan(0);
            RuleFor(c => c.HoursPerMonth).GreaterThan(0);
            RuleFor(c => c.ContractTypes).Custom((value, context) =>
            {
                var validTypes = dbContext.ContractTypes.Select(c => c.Id).ToList();
                var invalidTypes = value.Except(validTypes).ToList();
                if (invalidTypes.Any()) 
                {
                    context.AddFailure("ContractTypes", "Invalid contract id / ids. Valid contract ids are: 1 - Mandate contract, 2 - contract of employment, 3 - B2B");
                }
            });
        }
    }
}
