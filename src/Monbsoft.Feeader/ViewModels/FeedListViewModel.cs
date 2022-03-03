using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace Monbsoft.Feeader.ViewModels
{
    public class FeedListViewModel : BaseViewModel
    {
        private readonly FeedService _feedService;
        private readonly SettingsService _settingsService;
        private List<FeedViewModel> _feeds;
        private ArticleViewModel _selectedArticle;
        private FeedViewModel _selectedFeed;

        public FeedListViewModel(FeedService feedService, SettingsService settingsService)
        {
            _feedService = feedService;
            _settingsService = settingsService;

        }

        public List<FeedViewModel> Feeds
        {
            get { return _feeds; }
            set { SetProperty(ref _feeds, value); }
        }

        public ArticleViewModel SelectedArticle
        {
            get { return _selectedArticle; }
            set { SetProperty(ref _selectedArticle, value); }
        }

        public FeedViewModel SelectedFeed
        {
            get { return _selectedFeed; }
            set { SetProperty(ref _selectedFeed, value); }
        }

        public ICommand SelectArticleCommand => new AsyncCommand<Article>(SelectArticleCommandExecute);

        public ICommand SelectFeedCommand => new AsyncCommand<FeedViewModel>(SelectFeedCommandExecute);

        public async Task InitializeAsync()
        {
            var feeds = await _settingsService.ReadFeedsAsync();
            Feeds = feeds?.Select(f => new FeedViewModel(f, _feedService)).ToList();
        }

        private async Task SelectFeedCommandExecute(FeedViewModel feed)
        {
            SelectedArticle = null;
            SelectedFeed = feed;
            await SelectedFeed?.InitializeAsync();
        }

        private async Task SelectArticleCommandExecute(Article article)
        {
            SelectedArticle = new ArticleViewModel(article.Title, article.Link);
            await SelectedArticle?.InitializeAsync();
        }
    }
}
