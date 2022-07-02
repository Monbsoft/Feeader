using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Infrastructure.Data
{
    public class FeeaderDbContext : DbContext, IApplicationDbContext
    {
        public FeeaderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Feed> Feeds => Set<Feed>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Feed
            modelBuilder.Entity<Feed>()
                .Property(f => f.Created)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Feed>()
                .Property(b => b.Updated)
                .ValueGeneratedOnAddOrUpdate();

            base.OnModelCreating(modelBuilder);
        }
    }
}
