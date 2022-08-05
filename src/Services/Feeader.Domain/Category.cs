using Monbsoft.Feeader.SharedKernel;

namespace Monbsoft.Feeader.Domain
{
    public class Category : EntityBase
    {
        public Category(Guid id, string genre)
        {
            Id = id;
            Genre = genre;
        }

        public string Genre { get; private set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public DateTime Updated { get; private set; } = DateTime.Now;
        public ICollection<Feed> Feeds { get; private set; } = new List<Feed>();
    }
}
