using FluentValidation;
using FluentValidation.AspNetCore;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models.AccountModels;
using Microsoft.EntityFrameworkCore;

namespace JobWebsiteAPI.Models.Validators
{
    public class RegisterCompanyAccountDtoValidator : RegisterAccountDtoValidator<RegisterCompanyAccountDto>
    {
        public RegisterCompanyAccountDtoValidator(JobWebsiteDbContext dbContext) : base(dbContext)
        {
            RuleFor(a => a.CompanyName).MinimumLength(2);
        }
    }
}
