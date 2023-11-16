using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoviApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Infraestructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D2D14637C892FA0E");

            builder.Property(e => e.IdUser).HasColumnName("id_user");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");

            builder.Property(e => e.UserLastName1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_lastName1");

            builder.Property(e => e.UserLastName2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_lastName2");

            builder.Property(e => e.UserName1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name1");

            builder.Property(e => e.UserName2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name2");

            builder.Property(e => e.UserPassword)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("user_password");
        }
    }
}
