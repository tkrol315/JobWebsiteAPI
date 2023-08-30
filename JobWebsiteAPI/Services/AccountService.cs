using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace JobWebsiteAPI.Services
{
    public interface IAccountService
    {
         Task RegisterPersonalAccount(RegisterPersonalAccountDto dto);
         Task RegisterCompanyAccount(RegisterCompanyAccountDto dto);
    }
    public class AccountService :IAccountService
    {
        private readonly JobWebsiteDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Account> _passwordHasher;
        public AccountService(JobWebsiteDbContext dbContext,  IMapper mapper, IPasswordHasher<Account> passwordHasher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task RegisterPersonalAccount(RegisterPersonalAccountDto dto)
        {
            var newPersonalAccount = _mapper.Map<PersonalAccount>(dto);
            await _dbContext.AddAsync(newPersonalAccount);
            newPersonalAccount.PasswordHash = _passwordHasher.HashPassword(newPersonalAccount,dto.Password);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RegisterCompanyAccount(RegisterCompanyAccountDto dto)
        {
            var newCompanyAccount = _mapper.Map<CompanyAccount>(dto);
            await _dbContext.AddAsync(newCompanyAccount);
            newCompanyAccount.PasswordHash = _passwordHasher.HashPassword(newCompanyAccount, dto.Password);
            await _dbContext.SaveChangesAsync();
        }
    }
}
