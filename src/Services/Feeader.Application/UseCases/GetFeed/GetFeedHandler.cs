using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.GetFeed
{
    public class GetFeedHandler : IRequestHandler<GetFeedQuery, Feed?>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IFeedClient _feedClient;

        public GetFeedHandler(IApplicationDbContext dbContext, IFeedClient feedClient)
        {
            _dbContext = dbContext;
            _feedClient = feedClient;
        }

        public async Task<Feed?> Handle(GetFeedQuery request, CancellationToken cancellationToken)
        {
            var feed = await _dbContext.Feeds.FirstOrDefaultAsync(feed => feed.Id == request.Id);
            return feed;
        }
    }
}
