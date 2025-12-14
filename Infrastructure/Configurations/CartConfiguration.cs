using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Cart)
                .HasForeignKey(x => x.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cart => cart.Customer)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
