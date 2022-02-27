﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Models
{
    public class Article
    {

        public Article(string id, string title, DateTime date, string link)
        {
            Id= id;
            Date = date;
            Title= title.Trim();
            Link = link;
        }
        public string Id { get; }
        public DateTime Date { get;  }
        public string Description { get; private set; }
        public string Title { get; }
        public string Link { get; }

        public override string ToString()
        {
            return Title;
        }

        public Article WithDescription(string description)
        {
            if (!string.IsNullOrEmpty(description))
                Description = description;

            return this;
        }
    }
}
