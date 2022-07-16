using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Api.Models
{
    public record ArticleDto
    {
        public ArticleDto(Article article)
        {
            Id = article.Id;
            Description = article.Description;
            Date = article.Date;
            Url = article.Url;
        }

        public Guid Id { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public string Url { get; }
    }
}
