using MediatR;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Categories;

public class CreateCategoryCommand : IRequest<Guid>
{
    public CreateCategoryCommand(string genre)
    {
        Genre = genre;
    }

    public string Genre { get; }
}

public class CreateFeedHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateFeedHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Genre);
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
