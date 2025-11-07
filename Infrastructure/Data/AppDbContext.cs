using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : Audit.EntityFramework.AuditDbContext
    {

        //private readonly DbContextHelper _helper = new DbContextHelper();
        //private readonly IAuditDbContext? _auditContext;

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //_auditContext = new DefaultAuditContext(this);
            //_helper.SetConfig(_auditContext);
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Automatically apply all IEntityTypeConfiguration classes
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    return _helper.SaveChanges(_auditContext, () => base.SaveChanges(acceptAllChangesOnSuccess));
        //}

        //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return await _helper.SaveChangesAsync(_auditContext, () => base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken));
        //}
    }
}
