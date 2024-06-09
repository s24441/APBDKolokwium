using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKolokwium.Models.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment), Schema.Name);
            builder.HasKey(e => e.IdPayment);
            builder.Property(e => e.IdPayment).UseIdentityColumn();

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.Value).HasColumnType("Money").IsRequired();

            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(e => e.Subscription)
                .WithMany(e => e.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
