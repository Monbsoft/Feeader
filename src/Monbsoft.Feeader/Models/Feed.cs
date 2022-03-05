using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Models
{
    public class Feed : IEquatable<Feed>
    {
        public Feed(string name, string link)
        {          
            Name = name;
            Link = link;

        }

        public DateTime CreationDate { get; set; }

        public string Link { get; }
        public string Name { get; }


        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;   
            if(ReferenceEquals(this, obj)) return true; 
            if(obj.GetType() != typeof(Feed)) return false; 
            return Equals((Feed)obj);   
        }

        public bool Equals(Feed other)
        {
            if(ReferenceEquals (null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return Equals(Link,other.Link);
        }
        public override int GetHashCode() => Link.GetHashCode();
        public override string ToString()
        {
            return $"Feed {Name}";
        }
    }
}
