using EbisuWebApi.Crosscutting.Utils;
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
    public class RoleModelConfiguration : IEntityTypeConfiguration<RoleDataModel>
    {
        public void Configure(EntityTypeBuilder<RoleDataModel> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(role => role.RoleId);
            builder.Property(role => role.RoleId).UseMySqlIdentityColumn();
            builder.Property(user => user.RoleType).IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));

            SeedDefaultCategories(builder);
        }

        private void SeedDefaultCategories(EntityTypeBuilder<RoleDataModel> builder)
        {
            builder.HasData(
                new RoleDataModel
                {
                    RoleId = 1,
                    RoleType = Role.Admin
                },
                 new RoleDataModel
                 {
                     RoleId = 2,
                     RoleType = Role.User
                 }
                );
        }

    }
    
}
