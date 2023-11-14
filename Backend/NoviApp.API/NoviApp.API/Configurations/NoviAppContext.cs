using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NoviApp.API.Configurations
{
    public partial class NoviAppContext : DbContext
    {
        public NoviAppContext()
        {
        }

        public NoviAppContext(DbContextOptions<NoviAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=NoviApp;Integrated Security=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D2D14637C892FA0E");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.UserLastName1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_lastName1");

                entity.Property(e => e.UserLastName2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_lastName2");

                entity.Property(e => e.UserName1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name1");

                entity.Property(e => e.UserName2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name2");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
