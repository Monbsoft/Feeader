using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Categories;


public class ListCategoriesQuery : IRequest<List<Category>>
{
    public int? Limit { get; set; }
}

internal class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, List<Category>>
{
    private readonly IApplicationDbContext _dbContext;

    public ListCategoriesQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task<List<Category>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesQuery = _dbContext.Categories.OrderBy(c => c.Genre).AsQueryable();
        if (request.Limit is not null)
            categoriesQuery = categoriesQuery.Take(request.Limit.Value);
        var categories = await categoriesQuery.ToListAsync(cancellationToken);
        return categories;
    }
}
