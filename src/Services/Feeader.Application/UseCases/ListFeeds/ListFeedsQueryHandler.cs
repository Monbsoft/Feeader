using MediatR;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.ListFeeds
{
    public class ListFeedsQueryHandler : IStreamRequestHandler<ListFeedsRequest, Feed>
    {
        private readonly IApplicationDbContext _dbContext;

        public ListFeedsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncEnumerable<Feed> Handle(ListFeedsRequest request, CancellationToken cancellationToken)
        {
            var feeds = _dbContext.Feeds.AsAsyncEnumerable();
            return feeds;
        }
    }
}
