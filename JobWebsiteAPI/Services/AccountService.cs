using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Exceptions;
using JobWebsiteAPI.Models.AccountModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobWebsiteAPI.Services
{
    public interface IAccountService
    {
         Task RegisterPersonalAccount(RegisterPersonalAccountDto dto);
         Task RegisterCompanyAccount(RegisterCompanyAccountDto dto);
         Task<string> GenerateJwt(LoginDto dto);
    }
    public class AccountService :IAccountService
    {
        private readonly JobWebsiteDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Account> _passwordHasher;
        private readonly JwtSettings _jwtSettings;
        public AccountService(JobWebsiteDbContext dbContext,  IMapper mapper, IPasswordHasher<Account> passwordHasher, JwtSettings jwtSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtSettings = jwtSettings;
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


        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var account = await _dbContext.Accounts.Include(a => a.AccountType).FirstOrDefaultAsync(a => a.Email == dto.Email);
            if(account == null)
            {
                throw new BadRequestException("Incorrect Email or Password");
            }
            var passwordVeryficationResult = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, dto.Password);
            if(passwordVeryficationResult == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Incorrect Email or Password");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Role, account.AccountType.Name.ToString()),
                new Claim(ClaimTypes.Email, account.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_jwtSettings.JwtExpireMins);

            var token = new JwtSecurityToken(_jwtSettings.JwtIssuer,_jwtSettings.JwtAudience,claims,expires:expires, signingCredentials:cred);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
