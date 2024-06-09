using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKolokwium.Models.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable(nameof(Sale), Schema.Name);
            builder.HasKey(e => e.IdSale);
            builder.Property(e => e.IdSale).UseIdentityColumn();

            builder.Property(e => e.CreatedAt).IsRequired();

            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(e => e.Subscription)
                .WithMany(e => e.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
