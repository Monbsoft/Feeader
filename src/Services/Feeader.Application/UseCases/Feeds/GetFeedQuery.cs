using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Feeds;

public class GetFeedQuery : IRequest<Feed>
{
    public GetFeedQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}

public class GetFeedQueryHandler : IRequestHandler<GetFeedQuery, Feed?>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IFeedClient _feedClient;

    public GetFeedQueryHandler(IApplicationDbContext dbContext, IFeedClient feedClient)
    {
        _dbContext = dbContext;
        _feedClient = feedClient;
    }

    public async Task<Feed?> Handle(GetFeedQuery request, CancellationToken cancellationToken)
    {
        var feed = await _dbContext.Feeds
            .Include(f => f.Articles.OrderByDescending(a => a.Date))
            .FirstOrDefaultAsync(feed => feed.Id == request.Id);
        return feed;
    }
}
