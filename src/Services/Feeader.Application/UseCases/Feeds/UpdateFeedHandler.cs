using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monbsoft.Feeader.Application.Interfaces;

namespace Monbsoft.Feeader.Application.UseCases.Feeds;

public class UpdateFeedCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public Guid? CategoryId { get; set; }
}

public class UpdateFeedHandler : IRequestHandler<UpdateFeedCommand, Guid>
{
    private IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<UpdateFeedHandler> _logger;

    public UpdateFeedHandler(IServiceScopeFactory serviceScopeFactory, ILogger<UpdateFeedHandler> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    public async Task<Guid> Handle(UpdateFeedCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<IApplicationDbContext>()!;
                var feed = await dbContext.Feeds.FirstAsync(f => f.Id == request.Id);
                feed.UpdateDetails(request.Name, request.Url);
                feed.UpdateCategory(request.CategoryId);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to update feed: {Error}", ex.Message);
        }

        return request.Id;
    }
}