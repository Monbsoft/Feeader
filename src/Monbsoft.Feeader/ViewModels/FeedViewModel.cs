using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Article> _articles;
        private readonly FeedService _feedService;
        private readonly Feed _feed;
        private string _name;
        

        public FeedViewModel(Feed feed, FeedService feedService)
        {
            _articles = new ObservableCollection<Article>();
            _feed = feed;
            _feedService = feedService;
            
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        internal async Task InitializeAsync()
        {
            var articles = await _feedService.ReadArticlesAsync(_feed);
            _feed.AddArticles(articles);
        }



    }
}
