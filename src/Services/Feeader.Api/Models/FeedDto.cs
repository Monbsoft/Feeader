using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Api.Models
{
    public record FeedDto
    {
        public FeedDto(Feed feed)
        {
            Id = feed.Id;
            Name = feed.Name;
            Url = feed.Url;
            Updated = feed.Updated;
            Articles = feed.Articles.Select(a => new ArticleDto(a)).ToList();
        }

        public Guid Id { get; }
        public List<ArticleDto> Articles { get; }
        public string Name { get; }
        public string Url { get; }
        public DateTime Updated { get; }
    }
}
