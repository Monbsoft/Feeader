using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Models
{
    public class Article
    {

        public Article(string id, string title, DateTime date)
        {
            Id= id;
            Date = date;
            Title= title;
        }
        public string Id { get; }
        public DateTime Date { get; }
        public string Title { get; }

        public override string ToString()
        {
            return Title;
        }
    }
}
