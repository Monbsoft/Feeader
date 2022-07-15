using Monbsoft.Feeader.SharedKernel;

namespace Monbsoft.Feeader.Domain
{
    public class Article : EntityBase
    {

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
