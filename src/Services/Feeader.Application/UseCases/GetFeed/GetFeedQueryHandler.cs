using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.GetFeed
{
    public class GetFeedQueryHandler : IRequestHandler<GetFeedRequest, Feed?>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetFeedQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Feed?> Handle(GetFeedRequest request, CancellationToken cancellationToken)
        {
            var feed = _dbContext.Feeds.FirstOrDefaultAsync(feed => feed.Id == request.Id);
            return feed;
        }
    }
}
