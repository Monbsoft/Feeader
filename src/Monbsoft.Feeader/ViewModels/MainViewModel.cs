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
        private List<FeedViewModel> _feeds;
        private FeedViewModel _selectedFeed;

        public MainViewModel(FeedService feedService)
        {
            _feedService = feedService;
        }

        public List<FeedViewModel> Feeds
        {
            get { return _feeds; }
            set { SetProperty(ref _feeds, value); }
        }

        public FeedViewModel SelectedFeed
        {
            get { return _selectedFeed; }
            set { SetProperty(ref _selectedFeed, value); }
        }

        public ICommand SelectFeedCommand => new AsyncCommand<FeedViewModel>(SelectFeedCommandExecute);

        public async Task InitializeAsync()
        {
            var feeds = await _feedService.GetAllFeeds();
            Feeds = feeds?.Select(f => new FeedViewModel(f, _feedService)).ToList();
        }

        private async Task SelectFeedCommandExecute(FeedViewModel feed)
        {
            SelectedFeed = feed;
            await SelectedFeed?.InitializeAsync();
        }
    }
}
