using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Api.Models
{
    public record ArticleDto
    {
        public ArticleDto(Article article)
        {
            Id = article.Id;
            Title = article.Title;
            Description = article.Description;
            Date = article.Date;
            Url = article.Url;
            Picture = article.Picture;
            FeedName = article?.Feed?.Name;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public string Url { get; }
        public string Picture { get; }
        public string? FeedName { get; }
    }
}
