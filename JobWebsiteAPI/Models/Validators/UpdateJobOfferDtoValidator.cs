using FluentValidation;

namespace JobWebsiteAPI.Models.Validators
{
    public class UpdateJobOfferDtoValidator : AbstractValidator<UpdateJobOfferDto>
    {
        public UpdateJobOfferDtoValidator()
        {
            RuleFor(c => c.GrossSalary).GreaterThan(0);
            RuleFor(c => c.HoursPerMonth).GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
