using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Articles;


public class ListArticlesQuery : IRequest<List<Article>>
{
    public Guid? FeedId { get; set; }
    public int? Limit { get; set; }
}

internal class ListArticlesHandler : IRequestHandler<ListArticlesQuery, List<Article>>
{
    private readonly IApplicationDbContext _dbContext;

    public ListArticlesHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task<List<Article>> Handle(ListArticlesQuery request, CancellationToken cancellationToken)
    {
        var articlesQuery = _dbContext.Articles.AsQueryable();
        if (request.FeedId is not null)
            articlesQuery = articlesQuery.Where(a => request.FeedId.Equals(a.FeedId));
        if (request.Limit is not null)
            articlesQuery = articlesQuery.Take(request.Limit.Value);
        var articles = await articlesQuery.OrderByDescending(a => a.Date).ToListAsync(cancellationToken);
        return articles;
    }
}
