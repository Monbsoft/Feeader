using MediatR;
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

public class CreateFeedHandler : IRequestHandler<CreateFeedCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateFeedHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateFeedCommand request, CancellationToken cancellationToken)
    {
        var feed = new Feed(Guid.NewGuid(), request.Name, request.Url);
        await _dbContext.Feeds.AddAsync(feed, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return feed.Id;
    }
}
