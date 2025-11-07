using Domain.Entities;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext()
        {
        }
        public AuditDbContext(DbContextOptions<AuditDbContext> options): base(options)
        {

        }

        private static IConfiguration _configuration;

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AuditProductEntity> AuditProducts { get; set; }

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("defaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditProductEntity>().HasKey(table => table.AuditId);
        }
    }
}
