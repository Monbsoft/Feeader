using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Xml;

namespace Monbsoft.Feeader.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private readonly Feed _feed;
        private readonly FeedService _feedService;
        private ObservableCollection<Article> _articles;

        public FeedViewModel(Feed feed, FeedService feedService)
        {
            _articles = new ObservableCollection<Article>();
            _feed = feed;
            _feedService = feedService;
            Title = feed.Name;
        }

        public ObservableCollection<Article> Articles
        {
            get { return _articles; }
            set { SetProperty(ref _articles, value); }
        }

        internal async Task InitializeAsync()
        {
            try
            {
                IsBusy = true;
                _articles.Clear();
                var articles = await _feedService.GetArticlesAsync(_feed);
                _feed.AddArticles(articles.OrderByDescending(a => a.Date));
                foreach (var article in articles)
                {
                    _articles.Add(article);
                }                
            }
            catch(XmlException)
            {
                Articles.Clear();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}