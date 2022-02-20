using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace Monbsoft.Feeader.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly FeedService _feedService;
        private List<Feed> _feeds;
        private FeedViewModel _selectedFeed;

        public MainViewModel(FeedService feedService)
        {
            _feedService = feedService;
        }

        public ICommand SelectFeedCommand => new AsyncCommand<Feed>(SelectFeedCommandExecute);

        public FeedViewModel SelectedFeed
        {
            get { return _selectedFeed; }
            set { SetProperty(ref _selectedFeed, value); }
        }

        public List<Feed> Feeds
        {
            get { return _feeds; }
            set { SetProperty(ref _feeds, value); }
        }

        public async Task InitializeAsync()
        {
            var feeds = await _feedService.GetAllFeeds();
            Feeds = feeds?.ToList();
        }

        private async Task SelectFeedCommandExecute(Feed feed)
        {
            _selectedFeed = new FeedViewModel(feed, _feedService);
            await _selectedFeed.InitializeAsync();
        }
    }
}
