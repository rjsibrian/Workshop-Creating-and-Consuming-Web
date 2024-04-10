using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable(nameof(SalesOrderHeader), "Sales");

            builder.HasKey(e => e.SalesOrderID); 
            builder.Property(e => e.SalesOrderID).ValueGeneratedOnAdd();
            builder.Property(e => e.RevisionNumber).HasDefaultValue((byte)0);
            builder.Property(e => e.OrderDate).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.Status).HasDefaultValue((byte)1);
            builder.Property(e => e.OnlineOrderFlag).HasDefaultValue(true);
            builder.Property(e => e.SalesOrderNumber).HasComputedColumnSql("ISNULL(N'SO' + CONVERT(nvarchar(23),[SalesOrderID]),N'*** ERROR ***')").HasMaxLength(25);
            builder.Property(e => e.SubTotal).HasDefaultValue(0.00m);
            builder.Property(e => e.TaxAmt).HasDefaultValue(0.00m);
            builder.Property(e => e.Freight).HasDefaultValue(0.00m);
            builder.Property(e => e.TotalDue).HasComputedColumnSql("ISNULL(([SubTotal] + [TaxAmt]) + [Freight],(0))");
            builder.Property(e => e.DueDate).IsRequired();
            builder.Property(e => e.PurchaseOrderNumber).HasMaxLength(25);
            builder.Property(e => e.AccountNumber).HasMaxLength(15);
            builder.Property(e => e.CreditCardApprovalCode).HasMaxLength(15);
            builder.Property(e => e.Comment).HasMaxLength(128);
        }
    }
}
