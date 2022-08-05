using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Article> Articles { get; }
        DbSet<Category> Categories { get; }
        DbSet<Feed> Feeds { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

