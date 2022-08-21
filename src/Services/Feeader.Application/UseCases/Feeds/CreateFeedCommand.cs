using MediatR;
using Microsoft.Extensions.Logging;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Feeds;

public class CreateFeedCommand : IRequest<Guid>
{
    public CreateFeedCommand(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; }
    public string Url { get; }
}

public class CreateFeedCommandHandler : IRequestHandler<CreateFeedCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ILogger<CreateFeedCommandHandler> _logger;

    public CreateFeedCommandHandler(IApplicationDbContext dbContext, ILogger<CreateFeedCommandHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateFeedCommand request, CancellationToken cancellationToken)
    {
        var feed = new Feed(Guid.NewGuid(), request.Name, request.Url);
        await _dbContext.Feeds.AddAsync(feed, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Feed {Id} created", feed.Id);
        return feed.Id;
    }
}
