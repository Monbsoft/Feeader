using MediatR;
using Microsoft.EntityFrameworkCore;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Application.UseCases.Categories;

public class GetCategoryQuery : IRequest<Category>
{
    public GetCategoryQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}
public class GetCategoryHandlerQuery : IRequestHandler<GetCategoryQuery, Category?>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IFeedClient _feedClient;

    public GetCategoryHandlerQuery(IApplicationDbContext dbContext, IFeedClient feedClient)
    {
        _dbContext = dbContext;
        _feedClient = feedClient;
    }

    public async Task<Category?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);
        return category;
    }
}
