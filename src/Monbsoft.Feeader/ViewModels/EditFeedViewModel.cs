using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Monbsoft.Feeader.ViewModels
{
    public class EditFeedViewModel : BaseViewModel
    {

        private readonly FeedService _feedService;  
        private readonly SettingsService _settingsService;
        private ObservableCollection<Feed> _feeds;
        private string _feedUrl;

        public EditFeedViewModel(FeedService feedService, SettingsService settingsService)
        {
            _feedService = feedService;
            _settingsService = settingsService;
            Feeds = new ObservableCollection<Feed>();
        }


        public ICommand AddFeedCommand => new AsyncCommand(AddFeedCommandExecute);

        public ICommand DeleteFeedCommand => new AsyncCommand<Feed>(DeleteFeedCommandExecute);

        public ObservableCollection<Feed> Feeds
        {
            get => _feeds;
            set => SetProperty(ref _feeds, value);
        }

        public string FeedUrl
        {
            get => _feedUrl;
            set => SetProperty(ref _feedUrl, value);
        }


        public async Task AddFeedCommandExecute()
        {
            var newFeed = await _feedService.GetFeedDataAsync(FeedUrl);
            newFeed.CreationDate = DateTime.Now;
            Feeds.Add(newFeed);
            await _settingsService.SaveAsync(Feeds.ToList());
        }

        public async Task DeleteFeedCommandExecute(Feed feed)
        {
            var newFeed = await _feedService.GetFeedDataAsync(FeedUrl);
            newFeed.CreationDate = DateTime.Now;
            Feeds.Add(newFeed);
            await _settingsService.SaveAsync(Feeds.ToList());
        }

        internal async Task InitializeAsync()
        {
            var feeds = await _settingsService.ReadFeedsAsync();
            Feeds.Clear();
            foreach (var feed in feeds)
            {
                Feeds.Add(feed);
            }
        }

    }
}
