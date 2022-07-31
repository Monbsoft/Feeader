using Monbsoft.Feeader.SharedKernel;

namespace Monbsoft.Feeader.Domain
{
    public class Article : EntityBase
    {

        public Article(Guid id, string title, DateTime date, string description, string url, string picture)
        {
            Id = id;
            Date = date;
            Description = description; 
            Title = title;
            Url = url;
            Picture = picture;
        }

        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public string Url { get; private set; }
        public string Picture { get; private set; }
        public Guid FeedId { get; private set; }
        public Feed? Feed { get; private set; } = null;
    }
}
