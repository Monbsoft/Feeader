using Monbsoft.Feeader.Models;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Monbsoft.Feeader.Services
{
    public class FeedService
    {
        private const string localFileName = "settings.json";
        private readonly string _localPath;

        public FeedService()
        {
            _localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);
        }

        public Task<Feed> GetFeedDataAsync(string url)
        {
            using (var reader = XmlReader.Create(url))
            {
                var data = SyndicationFeed.Load(reader);
                return Task.FromResult(new Feed(data.Title?.Text, url));
            }
        }


        public async Task<IEnumerable<Article>> GetArticlesAsync(Feed feed)
        {
            return await Task.Run(() =>
            {
                var articles = new List<Article>();
                using (var reader = XmlReader.Create(feed.Link))
                {
                    var data = SyndicationFeed.Load(reader);
                    foreach (var item in data.Items)
                    {
                        var article = new Article(item.Id, item.Title.Text, item.PublishDate.DateTime, item.Links.First().Uri.AbsoluteUri)
                            .WithDescription(item.Summary?.Text);
                        articles.Add(article);
                    }
                };
                return articles;
            });
        }
    }
}