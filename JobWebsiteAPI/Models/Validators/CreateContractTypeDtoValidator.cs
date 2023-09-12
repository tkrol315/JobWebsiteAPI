using FluentValidation;
using JobWebsiteAPI.Models.ContractTypeModels;

namespace JobWebsiteAPI.Models.Validators
{
    public class CreateContractTypeDtoValidator : AbstractValidator<CreateContractTypeDto>
    {
        public CreateContractTypeDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
