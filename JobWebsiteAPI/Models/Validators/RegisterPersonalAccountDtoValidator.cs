﻿using FluentValidation;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models.AccountModels;

namespace JobWebsiteAPI.Models.Validators
{
    public class RegisterPersonalAccountDtoValidator : RegisterAccountDtoValidator<RegisterPersonalAccountDto>
    {
        public RegisterPersonalAccountDtoValidator(JobWebsiteDbContext dbContext) : base(dbContext)
        {
            RuleFor(a => a.Name).MinimumLength(3);
            RuleFor(a => a.Surname).MinimumLength(3);
        }
    }
}
