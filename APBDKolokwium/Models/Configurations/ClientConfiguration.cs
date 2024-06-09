using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBDKolokwium.Models.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client), Schema.Name);

            builder.HasKey(e => e.IdClient);
            builder.Property(e => e.IdClient).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(100);


            builder
                .HasMany(e => e.Discounts)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.IdClient);

            builder
                .HasMany(e => e.Sales)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.IdClient);

            builder
                .HasMany(e => e.Payments)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.IdClient);
        }
    }
}
