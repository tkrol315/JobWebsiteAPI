using FluentValidation;
using JobWebsiteAPI.Entities;

namespace JobWebsiteAPI.Models.Validators
{
    public class RegisterAccountDtoValidator<TDto> : AbstractValidator<TDto> where TDto : RegisterAccountDto
    {
        public RegisterAccountDtoValidator(JobWebsiteDbContext dbContext)
        {
            RuleFor(a => a.Email).EmailAddress().MinimumLength(5);
            RuleFor(a => a.Password).MinimumLength(6);
            RuleFor(a => a.ConfirmPassword).Equal(a => a.Password);
            RuleFor(a => a.Email).Custom((value, context) =>
            {
                if (dbContext.Accounts.Any(a => a.Email == value))
                {
                    context.AddFailure("Email", "Email taken");
                }
            });
        }
    }
}
