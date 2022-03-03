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
    public class SettingsViewModel : BaseViewModel
    {
        private readonly FeedService _feedService; 
        private readonly SettingsService _settingsService;       
        private string _newFeedUrl;
        private ObservableCollection<Feed> _feeds;

        public SettingsViewModel(FeedService feedService, SettingsService settingsService)
        {
            _feeds = new ObservableCollection<Feed>();
            _feedService = feedService;
            _settingsService = settingsService;
        }

        public static string AppVersion { get => AppInfo.VersionString; }

        public ICommand AddFeedCommand => new AsyncCommand(AddFeedCommandExecute);

        public ObservableCollection<Feed> Feeds
        {
            get { return _feeds; }
            set { SetProperty(ref _feeds, value); }
        }

        public string NewFeedUrl
        {
            get { return _newFeedUrl; }   
            set { SetProperty(ref _newFeedUrl, value); }  
        }

        internal async Task InitializeAsync()
        {
            var feeds = await _settingsService.ReadFeedsAsync();
            feeds.ForEach(f => Feeds.Add(f));
           
        }

        public async Task AddFeedCommandExecute()
        {
            var newFeed = await _feedService.GetFeedDataAsync(NewFeedUrl);
            Feeds.Add(newFeed);
            await _settingsService.SaveAsync(Feeds.ToList());

        }
    }
}
