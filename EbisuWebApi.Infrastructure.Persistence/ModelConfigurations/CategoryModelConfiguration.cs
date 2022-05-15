using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Persistence.ModelConfigurations
{
    public class CategoryModelConfiguration : IEntityTypeConfiguration<CategoryDataModel>
    {
        public void Configure(EntityTypeBuilder<CategoryDataModel> builder)
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

            SeedDefaultCategories(builder);
        }

        private void SeedDefaultCategories(EntityTypeBuilder<CategoryDataModel> builder)
        {
            builder.HasData(
                new CategoryDataModel
                {
                    CategoryId = 1,
                    Name = "Comida",
                    ImageUrl = "asd",
                    Description = "Comida",
                    IsDefault = true,
                    Type = CategoryType.Gasto
                },
                new CategoryDataModel
                {
                    CategoryId = 2,
                    Name = "Transporte",
                    ImageUrl = "asd",
                    Description = "Transporte",
                    IsDefault = true,
                    Type = CategoryType.Gasto
                },
                new CategoryDataModel
                {
                    CategoryId = 3,
                    Name = "Salario",
                    ImageUrl = "asd",
                    Description = "Salario",
                    IsDefault = true,
                    Type = CategoryType.Ingreso
                }
                );
        }
    }
}
