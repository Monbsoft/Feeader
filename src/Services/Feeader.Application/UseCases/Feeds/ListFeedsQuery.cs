using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Feeds;

public class ListFeedsQuery : IRequest<List<Feed>>
{
}

public class ListFeedsQueryHandler : IRequestHandler<ListFeedsQuery, List<Feed>>
{
    private readonly IApplicationDbContext _dbContext;

    public ListFeedsQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Feed>> Handle(ListFeedsQuery request, CancellationToken cancellationToken)
    {
        var feeds = await _dbContext.Feeds.OrderBy(f => f.Name).ToListAsync(cancellationToken);
        return feeds;
    }
}