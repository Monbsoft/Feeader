using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Feed> Feeds { get; }
    }
}
