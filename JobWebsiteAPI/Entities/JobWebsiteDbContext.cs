using Microsoft.EntityFrameworkCore;

namespace JobWebsiteAPI.Entities
{
    public class JobWebsiteDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CompanyAccount> CompanyAccounts { get; set; }
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public JobWebsiteDbContext(DbContextOptions<JobWebsiteDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
