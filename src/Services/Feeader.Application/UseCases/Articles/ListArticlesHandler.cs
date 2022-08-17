using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Articles;


public class ListArticlesQuery : IRequest<List<Article>>
{
    public Guid? CategoryId { get; set; }
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
        var articlesQuery = _dbContext.Articles.Include(a => a.Feed).OrderByDescending(a => a.Date).AsQueryable();
        if (request.CategoryId is not null)
            articlesQuery = articlesQuery.Where(a => request.CategoryId.Equals(a.Feed!.CategoryId));
        if (request.FeedId is not null)
            articlesQuery = articlesQuery.Where(a => request.FeedId.Equals(a.FeedId));
        if (request.Limit is not null)
            articlesQuery = articlesQuery.Take(request.Limit.Value);
        var articles = await articlesQuery.ToListAsync(cancellationToken);
        return articles;
    }
}
