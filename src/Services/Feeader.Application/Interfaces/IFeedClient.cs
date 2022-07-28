using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.Interfaces
{
    public interface IFeedClient
    {
        Task<Feed> GetFeedAsync(Feed feed, CancellationToken cancellationToken);
    }
}