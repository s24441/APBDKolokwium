using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKolokwium.Models.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable(nameof(Discount), Schema.Name);
            builder.HasKey(e => e.IdDiscount);
            builder.Property(e => e.IdDiscount).UseIdentityColumn();

            builder.Property(e => e.Value).IsRequired();
            builder.Property(e => e.DateFrom).IsRequired();
            builder.Property(e => e.DateTo).IsRequired();

            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Discounts);
        }
    }
}
