using MediatR;
using Microsoft.Extensions.Logging;
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

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;

    public CreateCategoryCommandHandler(IApplicationDbContext dbContext, ILogger<CreateCategoryCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(Guid.NewGuid(), request.Genre);
        await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Category {Id} created", category.Id);
        return category.Id;
    }
}
