using Microsoft.EntityFrameworkCore;

namespace LegalContract.Persistence
{
    public class LegalContractDbContext: DbContext
    {
        public virtual DbSet<Domain.Entities.Contract> Contract { get; set; }

        public LegalContractDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Domain.Entities.Contract && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    ((Domain.Entities.Contract)entityEntry.Entity).UpdateDate = DateTime.Now;
                }

                if (entityEntry.State == EntityState.Added)
                {
                    ((Domain.Entities.Contract)entityEntry.Entity).CreationDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Contract>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
