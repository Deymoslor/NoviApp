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
            builder.HasKey(e => e.Id_user)
                    .HasName("PK__Users__D2D14637C892FA0E");

            builder.ToTable("User");

            builder.Property(e => e.Id_user).HasColumnName("id_user");

            builder.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.phoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");

            builder.Property(e => e.user_lastName1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_lastName1");

            builder.Property(e => e.user_lastName2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_lastName2");

            builder.Property(e => e.user_name1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name1");

            builder.Property(e => e.user_name2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name2");

            builder.Property(e => e.user_password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("user_password");
        }
    }
}
