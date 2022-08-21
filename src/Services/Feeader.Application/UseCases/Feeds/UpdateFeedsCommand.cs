using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.Feeds;

public class UpdateFeedsCommand : IRequest<int>
{
}

public class UpdateFeedsCommandHandler : IRequestHandler<UpdateFeedsCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IFeedClient _feedClient;
    private readonly ILogger<UpdateFeedsCommandHandler> _logger;

    public UpdateFeedsCommandHandler(IApplicationDbContext dbContext, IFeedClient feedClient, ILogger<UpdateFeedsCommandHandler> logger)
    {
        _dbContext = dbContext;
        _feedClient = feedClient;
        _logger = logger;
    }

    public async Task<int> Handle(UpdateFeedsCommand request, CancellationToken cancellationToken)
    {
        var feeds = await _dbContext.Feeds.Include(x => x.Articles).ToListAsync(cancellationToken);

        int count = 0;
        foreach (var feed in feeds)
        {
            _logger.LogDebug("Updating feed {url}...", feed.Url);
            try
            {
                var current = await _feedClient.GetFeedAsync(feed, cancellationToken);
                if (!current.Articles.Any())
                    continue;

                var newArticles = GetNewArticles(feed.Articles, current.Articles);
                newArticles.ToList().ForEach(article => feed.Articles.Add(article));
                count += await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update feed: {Error}", ex.Message);
            }
        }
        return count;
    }

    public static IEnumerable<Article> GetNewArticles(IEnumerable<Article> existingArticles, IEnumerable<Article> allArticles)
    {
        var newArticles = allArticles.Where(newArticle => existingArticles.All(existingArticle => existingArticle.Url != newArticle.Url));
        return newArticles;
    }
}