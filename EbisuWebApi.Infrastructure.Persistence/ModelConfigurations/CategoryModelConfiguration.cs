using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Persistence.ModelConfigurations
{
    public class CategoryModelConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(category => category.CategoryId);
            builder.Property(category => category.CategoryId).UseMySqlIdentityColumn();
            builder.Property(category => category.Name).IsRequired().HasMaxLength(255);
            builder.Property(category => category.ImageUrl).IsRequired().HasMaxLength(255);
            builder.Property(category => category.Description).IsRequired().HasMaxLength(255);
            builder.Property(category => category.IsDefault).IsRequired();
            builder.Property(category => category.Type).IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (CategoryType)Enum.Parse(typeof(CategoryType), v));
        }
    }
}
