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

        public Task<IEnumerable<Feed>> GetAllFeeds()
        {
            var feeds = new List<Feed>()
            {
                new Feed("CNN", "http://rss.cnn.com/rss/cnn_topstories.rss"),
                new Feed("New York Times", "https://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml"),
                new Feed("Huffington Post", "https://www.huffpost.com/section/front-page/feed?x=1"),
                new Feed("Fox News", "https://moxie.foxnews.com/feedburner/latest.xml")
            };
            return Task.FromResult(feeds.AsEnumerable<Feed>());
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