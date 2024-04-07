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

            builder.Property(e => e.MakeFlag).HasColumnName("MakeFlag");
            builder.Property(e => e.FinishedGoodsFlag).HasColumnName("FinishedGoodsFlag");
            builder.Property(e => e.SafetyStockLevel).HasColumnName("SafetyStockLevel");
            builder.Property(e => e.ReorderPoint).HasColumnName("ReorderPoint");
            builder.Property(e => e.StandardCost).HasColumnName("StandardCost");
            builder.Property(e => e.ListPrice).HasColumnName("ListPrice");
            builder.Property(e => e.DaysToManufacture).HasColumnName("DaysToManufacture");
            builder.Property(e => e.ProductLine).HasColumnName("ProductLine");
            builder.Property(e => e.Class).HasColumnName("Class");
            builder.Property(e => e.Style).HasColumnName("Style");
        }
    }
}
