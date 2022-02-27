using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Models
{
    public  class Feed
    {
        public Feed(string name, string link)
        {          
            Articles = new List<Article>();
            Name = name;
            Link = link;
        }

        public List<Article> Articles { get; }

        public string Description { get; set; }
        public string Link { get; }
        public string Name { get; }

        public void AddArticles(IEnumerable<Article> articles)
        {
            Articles.Clear();
            Articles.AddRange(articles);
        }
        public override string ToString()
        {
            return $"{Name} with {Articles.Count} article(s)";
        }
    }
}
