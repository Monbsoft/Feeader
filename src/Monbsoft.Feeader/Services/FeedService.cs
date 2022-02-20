using Monbsoft.Feeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Monbsoft.Feeader.Services
{
    public class FeedService
    {

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

        public async Task<IEnumerable<Article>> ReadArticlesAsync(Feed feed)
        {
            var articles = await Task.Run(() =>
            {
                var articles = new List<Article>();
                using (var reader = XmlReader.Create(feed.Uri))
                {
                    var data = SyndicationFeed.Load(reader);
                    foreach(var item in data.Items)
                    {
                        var article = new Article(item.Id, item.Title.Text);
                        articles.Add(article);

                    }
                };
                return articles;
            });
            return articles;
        }
    }
}
