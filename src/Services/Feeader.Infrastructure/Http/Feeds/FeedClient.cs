using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Monbsoft.Feeader.Domain;
using System.Xml.Serialization;

namespace Monbsoft.Feeader.Infrastructure.Http.Feeds
{
    public class FeedClient
    {
        private static readonly XmlSerializer XmlSerializer = new(typeof(Rss));
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<FeedClient> _logger;


        public FeedClient(HttpClient httpClient, IConfiguration configuration, ILogger<FeedClient> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
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
