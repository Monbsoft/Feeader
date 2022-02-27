using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Monbsoft.Feeader.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private readonly Feed _feed;
        private readonly FeedService _feedService;
        private ObservableCollection<Article> _articles;
        private string _name;

        public FeedViewModel(Feed feed, FeedService feedService)
        {
            _articles = new ObservableCollection<Article>();
            _feed = feed;
            _feedService = feedService;
            Name = feed.Name;
        }

        public ObservableCollection<Article> Articles
        {
            get { return _articles; }
            set { SetProperty(ref _articles, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        internal async Task InitializeAsync()
        {
            var articles = await _feedService.GetArticlesAsync(_feed);
            await Task.Delay(TimeSpan.FromSeconds(5));
            _feed.AddArticles(articles.OrderByDescending(a => a.Date));
            _articles.Clear();
            foreach(var article in articles)
            {
                _articles.Add(article);
            }
        }
    }
}