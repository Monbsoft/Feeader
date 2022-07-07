using Monbsoft.Feeader.Domain;

namespace Feeader.Web.Services
{
    public interface IFeeaderService
    {
        Task<Feed> GetFeed(Guid id, CancellationToken cancellationToken);
        Task<Feed[]> ListFeeds(CancellationToken cancellationToken);
    }
}