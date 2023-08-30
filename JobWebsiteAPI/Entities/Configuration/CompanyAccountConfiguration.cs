using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobWebsiteAPI.Entities.Configuration
{
    public class CompanyAccountConfiguration : IEntityTypeConfiguration<CompanyAccount>
    {
        public void Configure(EntityTypeBuilder<CompanyAccount> builder)
        {
            builder.HasMany(c=>c.CreatedJobOffers).WithOne(j=>j.Creator).HasForeignKey(c=>c.CreatorId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
