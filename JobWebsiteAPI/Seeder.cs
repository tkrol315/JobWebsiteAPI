using JobWebsiteAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobWebsiteAPI
{
    public class Seeder 
    {
        private readonly JobWebsiteDbContext _dbContext;
        public Seeder(JobWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
            if(!await _dbContext.ContractTypes.AnyAsync())
            {
                var contractTypes = GetContractTypes();
                _dbContext.ContractTypes.AddRange(contractTypes);
                await _dbContext.SaveChangesAsync();
            }
           if(!await _dbContext.AccountTypes.AnyAsync())
            {
                var accountTypes = GetAccountTypes();
                _dbContext.AccountTypes.AddRange(accountTypes);
                await _dbContext.SaveChangesAsync();
            }
        }

        private List<ContractType> GetContractTypes()
        {
            return new List<ContractType>()
            {
                new ContractType()
                {
                    Name = "Mandate contract"
                },
                new ContractType()
                {
                    Name = "Contract of employment"
                },
                new ContractType()
                {
                    Name = "B2B"
                }
            };
        }
        private List<AccountType> GetAccountTypes()
        {
            return new List<AccountType>() {
                new AccountType()
                { 
                    Name="PersonalAccount"
                },
                new AccountType()
                {
                    Name="CompanyAccount"
                }
            };
        }
    }
}
