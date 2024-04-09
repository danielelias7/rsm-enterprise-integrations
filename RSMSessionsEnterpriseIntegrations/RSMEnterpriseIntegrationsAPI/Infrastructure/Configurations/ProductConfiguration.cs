namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "Production");

            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductId).HasColumnName("ProductID");

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ProductNumber).IsRequired().HasMaxLength(50);

            builder.Property(e => e.MakeFlag).IsRequired();
            builder.Property(e => e.FinishedGoodsFlag).IsRequired();
            builder.Property(e => e.SafetyStockLevel).IsRequired();
            builder.Property(e => e.ReorderPoint).IsRequired();
            builder.Property(e => e.StandardCost).IsRequired();
            builder.Property(e => e.ListPrice).IsRequired();
            builder.Property(e => e.DaysToManufacture).IsRequired();
            builder.Property(e => e.ProductLine).IsRequired();
            builder.Property(e => e.Class).IsRequired();
            builder.Property(e => e.Style).IsRequired();
        }
    }
}
