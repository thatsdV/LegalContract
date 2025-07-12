using Microsoft.EntityFrameworkCore;

namespace LegalContract.Persistence
{
    public class LegalContractDbContext: DbContext
    {
        public virtual DbSet<Domain.Entities.LegalContract> LegalContracts { get; set; }

        public LegalContractDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.LegalContract>().HasKey(m => m.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
