using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Infrastructure.Data;

public class FeeaderDbContext : DbContext, IApplicationDbContext
{
    public FeeaderDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Feed> Feeds => Set<Feed>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feed>().HasData(ContextSeed.Feeds);
        // Category
        modelBuilder.Entity<Category>()
            .Property(c => c.Created)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Category>()
            .Property(c => c.Updated)
            .HasDefaultValueSql("getdate()")
            .ValueGeneratedOnAddOrUpdate();

        //Feed
        modelBuilder.Entity<Feed>()
            .Property(f => f.Created)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Feed>()
            .Property(b => b.Updated)
            .HasDefaultValueSql("getdate()")
            .ValueGeneratedOnAddOrUpdate();

        base.OnModelCreating(modelBuilder);
    }
}
