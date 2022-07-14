using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;
using System.Xml.Serialization;

namespace Monbsoft.Feeader.Infrastructure.Http.Feeds
{
    public class FeedClient : IFeedClient
    {
        private static readonly XmlSerializer XmlSerializer = new(typeof(Rss));
        private readonly HttpClient _httpClient;
        private readonly ILogger<FeedClient> _logger;


        public FeedClient(HttpClient httpClient, ILogger<FeedClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Rss> GetChannelAsync(Feed feed, CancellationToken cancellationToken)
        {
            await using var feedContent = await _httpClient.GetStreamAsync(feed.Url, cancellationToken);
            var rss = (Rss)XmlSerializer.Deserialize(feedContent)!;

            return rss;
        }
    }
}
