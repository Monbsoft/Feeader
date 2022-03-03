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
            Name = name;
            Link = link;
        }

        public string Link { get; }
        public string Name { get; }

        public override string ToString()
        {
            return $"Feed {Name}";
        }
    }
}
