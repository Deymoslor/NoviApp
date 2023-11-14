using Microsoft.EntityFrameworkCore;
using NoviApp.Application.Interfaces;
using NoviApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Infraestructure.Persistence.DbContexts
{
    public partial class NoviAppContext : DbContext, IApplicationDbContext
    {
        public NoviAppContext() { }
        public NoviAppContext(DbContextOptions<NoviAppContext> options)
        : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
