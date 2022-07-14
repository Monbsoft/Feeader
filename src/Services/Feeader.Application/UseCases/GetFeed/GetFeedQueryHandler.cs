using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.GetFeed
{
    public class GetFeedQueryHandler : IRequestHandler<GetFeedRequest, Feed?>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IFeedClient _feedClient;

        public GetFeedQueryHandler(IApplicationDbContext dbContext, IFeedClient feedClient)
        {
            _dbContext = dbContext;
            _feedClient = feedClient;
        }

        public async Task<Feed?> Handle(GetFeedRequest request, CancellationToken cancellationToken)
        {
            var feed = await _dbContext.Feeds.FirstOrDefaultAsync(feed => feed.Id == request.Id);
            var test = await _feedClient.GetChannelAsync(feed!, cancellationToken);
            return feed;
        }
    }
}
