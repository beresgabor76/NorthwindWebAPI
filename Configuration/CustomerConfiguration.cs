// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NwOrdersAPI.Entities;

namespace NwOrdersAPI
{
    // Customers
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "dbo");
            builder.HasKey(x => new { x.CustomerId, x.CompanyName });

            builder.Property(x => x.CustomerId).HasColumnName(@"CustomerID").HasColumnType("nchar(5)").IsRequired().IsFixedLength().HasMaxLength(5).ValueGeneratedNever();
            builder.Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40).ValueGeneratedNever();
            builder.Property(x => x.ContactName).HasColumnName(@"ContactName").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.ContactTitle).HasColumnName(@"ContactTitle").HasColumnType("nvarchar(30)").IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(60)").IsRequired(false).HasMaxLength(60);
            builder.Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
            builder.Property(x => x.Fax).HasColumnName(@"Fax").HasColumnType("nvarchar(24)").IsRequired(false).HasMaxLength(24);
        }
    }

}
// </auto-generated>
