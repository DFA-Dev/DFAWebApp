using Microsoft.EntityFrameworkCore;
using DFAWebApp.Domain.Models;
using System.Linq;

namespace DFAWebApp.Infrastructure.Context
{
    public class DFAWebAppDbContext : DbContext
    {
        public DFAWebAppDbContext() { }

        public DFAWebAppDbContext(DbContextOptions<DFAWebAppDbContext> opts) : base(opts) { }

        // Defining DbSet
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DFAWebAppDbContext).Assembly);

            // disable the cascade deletion
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }
    }
}
