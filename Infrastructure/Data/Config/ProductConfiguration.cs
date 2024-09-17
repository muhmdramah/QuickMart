using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prop => prop.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnType("nvarchar(128)")
                .HasDefaultValue("Unnamed Product")
                .IsUnicode(false);


            builder.Property(prop => prop.Description)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.Property(prop => prop.Price)
                .IsRequired()
                .HasPrecision(18, 2)
                .HasColumnType("decimal(18,2)");

            builder.Property(prop => prop.PictureUrl)
                .IsRequired()
                .HasMaxLength(2048)
                .HasColumnType("nvarchar(2048)")
                .IsUnicode(false);


            // Relationships 
            builder.HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(fk => fk.ProductTypeId);

            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(fk => fk.ProductBrandId);
        }
    }
}
