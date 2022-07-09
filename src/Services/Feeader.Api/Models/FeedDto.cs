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
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Url { get; }
    }
}
