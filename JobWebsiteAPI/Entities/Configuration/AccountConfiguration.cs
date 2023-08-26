using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobWebsiteAPI.Entities.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(a => a.Address).WithOne(a => a.Account).HasForeignKey<Account>(a=>a.AddressId);
        }
    }
}
