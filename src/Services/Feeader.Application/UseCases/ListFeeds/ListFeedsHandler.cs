using MediatR;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.ListFeeds
{
    public class ListFeedsHandler : IStreamRequestHandler<ListFeedsQuery, Feed>
    {
        private readonly IApplicationDbContext _dbContext;

        public ListFeedsHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncEnumerable<Feed> Handle(ListFeedsQuery request, CancellationToken cancellationToken)
        {
            var feeds = _dbContext.Feeds.AsAsyncEnumerable();
            return feeds;
        }
    }
}
