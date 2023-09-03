using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobWebsiteAPI.Entities.Configuration
{
    public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            builder.HasMany(j => j.ContractTypes).WithMany(c => c.JobOffers);
            builder.HasMany(j => j.Tags).WithMany(t => t.JobOffers);
            builder.Property(j => j.GrossSalary).HasPrecision(18, 2).IsRequired();
            builder.Property(j => j.HoursPerMonth).IsRequired();
            builder.Property(j => j.Description).IsRequired();

        }
    }
}
