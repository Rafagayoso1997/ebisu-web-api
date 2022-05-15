using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingCF.Infrastructure.Repositories.Configurations
{
    public class UserModelConfiguration : IEntityTypeConfiguration<UserDataModel>
    {
        public void Configure(EntityTypeBuilder<UserDataModel> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.UserId);
            builder.Property(user => user.UserId).UseMySqlIdentityColumn();
            builder.Property(user => user.UserName).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(255);
        }
    }
}
