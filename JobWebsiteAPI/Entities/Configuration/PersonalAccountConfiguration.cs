using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobWebsiteAPI.Entities.Configuration
{
    public class PersonalAccountConfiguration : IEntityTypeConfiguration<PersonalAccount>
    {
        public void Configure(EntityTypeBuilder<PersonalAccount> builder)
        {
            builder.HasMany(p => p.AppliedJobOffers).WithMany(j => j.AccountsThatAplied);

        }
    }
}
