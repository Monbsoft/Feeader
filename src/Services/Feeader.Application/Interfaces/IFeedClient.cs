using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.Interfaces
{
    public interface IFeedClient
    {
        Task<Rss> GetChannelAsync(Feed feed, CancellationToken cancellationToken);
    }
}