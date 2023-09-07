using FluentValidation;
using JobWebsiteAPI.Models.TagModels;

namespace JobWebsiteAPI.Models.Validators
{
    public class CreateTagValidator : AbstractValidator<CreateTagDto>
    {
        public CreateTagValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(12);
        }
    }
}
