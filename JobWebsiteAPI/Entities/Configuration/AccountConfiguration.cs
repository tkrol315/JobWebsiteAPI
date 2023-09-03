using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobWebsiteAPI.Entities.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(a => a.Address).WithOne(a => a.Account).HasForeignKey<Account>(a=>a.AddressId);
            builder.HasOne(a => a.AccountType).WithMany(a => a.Accounts).HasForeignKey(a=>a.AccountTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.PhoneNumber).IsRequired();
            builder.Property(a => a.PasswordHash).IsRequired();
        }
    }
}
