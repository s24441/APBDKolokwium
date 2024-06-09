using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKolokwium.Models.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable(nameof(Subscription), Schema.Name);
            builder.HasKey(e => e.IdSubscription);
            builder.Property(e => e.IdSubscription).UseIdentityColumn();

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.RenewalPeriod).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();
            builder.Property(e => e.Price).HasColumnType("Money").IsRequired();

            builder
                .HasMany(e => e.Sales)
                .WithOne(e => e.Subscription)
                .HasForeignKey(e => e.IdSubscription);

            builder
                .HasMany(e => e.Payments)
                .WithOne(e => e.Subscription)
                .HasForeignKey(e => e.IdSubscription);
        }
    }
}
