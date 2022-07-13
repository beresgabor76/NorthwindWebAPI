// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NwOrdersAPI.Entities;

namespace NwOrdersAPI
{
    // Products
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");
            builder.HasKey(x => new { x.ProductId, x.ProductName });

            builder.Property(x => x.ProductId).HasColumnName(@"ProductID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40).ValueGeneratedNever();
            builder.Property(x => x.SupplierId).HasColumnName(@"SupplierID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CategoryId).HasColumnName(@"CategoryID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.QuantityPerUnit).HasColumnName(@"QuantityPerUnit").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType("money").IsRequired(false);
            builder.Property(x => x.UnitsInStock).HasColumnName(@"UnitsInStock").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.UnitsOnOrder).HasColumnName(@"UnitsOnOrder").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.ReorderLevel).HasColumnName(@"ReorderLevel").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.Discontinued).HasColumnName(@"Discontinued").HasColumnType("bit").IsRequired(false).ValueGeneratedNever();
        }
    }

}
// </auto-generated>
