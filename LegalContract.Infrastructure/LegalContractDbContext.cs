using Microsoft.EntityFrameworkCore;

namespace LegalContract.Persistence
{
    public class LegalContractDbContext: DbContext
    {
        public virtual DbSet<Domain.Entities.Contract> Contract { get; set; }

        public LegalContractDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Contract>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreationDate).ValueGeneratedOnAdd();
                entity.Property(e => e.UpdateDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Domain.Entities.Contract>().HasData(
                new Domain.Entities.Contract
                {
                    Id = 1,
                    Author = "Tom John",
                    EntityName = "Bank",
                    Description = "This is the description for the first legal contract ever made",
                    CreationDate = DateTime.Now,
                    UpdateDate = null
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
