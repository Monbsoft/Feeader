using Monbsoft.Feeader.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Infrastructure.Http.Feeds;

internal static class Mapper
{
    internal static Feed Map(Rss rss)
    {
        //var imageUrl = (rss.Channel.Image?.Url ?? rss.Channel.Image2?.Href) ?? throw new ArgumentNullException(nameof(Image.Url));
        var link = rss.Channel.Link?.Href ?? rss.Channel.Link2 ?? throw new ArgumentNullException(nameof(Link.Href));
        var articles = rss.Channel.Item.Select(Map).ToList();

        var feed = new Feed(Guid.Empty, rss.Channel.Title, link);
        articles.ForEach(article => feed.Articles.Add(article));
        return feed;
    }


    private static Article Map(Item item)
    {
        var title = item.Title ?? string.Empty;
        var description = item.Summary ?? item.Description ?? String.Empty;
        var url = item.Link ?? item.Enclosure?.Url ?? throw new ArgumentNullException(nameof(Item.Link));
        var pubDate = RssHelper.ConvertDateTime(item.PubDate).GetValueOrDefault();
        var picture = item.Enclosure?.Url ?? String.Empty;

        var article = new Article(Guid.Empty, title, pubDate, description, url, picture);
        return article;

    }


}
