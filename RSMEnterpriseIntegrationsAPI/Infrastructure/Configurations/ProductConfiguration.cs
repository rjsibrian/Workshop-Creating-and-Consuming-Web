using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "Production");

            builder.HasKey(e => e.ProductID);
            builder.Property(e => e.ProductID).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ProductNumber).HasMaxLength(25).IsRequired();
            builder.Property(e => e.MakeFlag).IsRequired();
            builder.Property(e => e.FinishedGoodsFlag).IsRequired();
            builder.Property(e => e.Color).HasMaxLength(15);
            builder.Property(e => e.SafetyStockLevel).IsRequired();
            builder.Property(e => e.ReorderPoint).IsRequired();
            builder.Property(e => e.StandardCost).IsRequired();
            builder.Property(e => e.ListPrice).IsRequired();
            builder.Property(e => e.Size).HasMaxLength(5);
            builder.Property(e => e.SizeUnitMeasureCode).HasMaxLength(3);
            builder.Property(e => e.WeightUnitMeasureCode).HasMaxLength(3);
            builder.Property(e => e.Weight).HasColumnType("decimal(8,2)");
            builder.Property(e => e.DaysToManufacture).IsRequired();
            builder.Property(e => e.ProductLine).HasMaxLength(2);
            builder.Property(e => e.Class).HasMaxLength(2);
            builder.Property(e => e.Style).HasMaxLength(2);
            builder.Property(e => e.ProductSubcategoryID);
            builder.Property(e => e.ProductModelID);
            builder.Property(e => e.SellStartDate).IsRequired();
            builder.Property(e => e.SellEndDate);
            builder.Property(e => e.DiscontinuedDate);
        }
    }
}

