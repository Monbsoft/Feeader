using Monbsoft.Feeader.SharedKernel;

namespace Monbsoft.Feeader.Domain
{
    public class Feed : EntityBase
    {
        public Feed() {}
        public Feed(string name, string  url)
        {
            Name = name;
            Url = url;
        }

        public Feed(Guid id, string name, string url)
        {
            Id = id;
            Name= name;
            Url= url;
        }

        public string Name { get; private set; }
        public string Url { get; private set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public DateTime Updated { get; private set; } = DateTime.Now;
        public ICollection<Article> Articles { get; private set; } = new List<Article>();
    }
}
