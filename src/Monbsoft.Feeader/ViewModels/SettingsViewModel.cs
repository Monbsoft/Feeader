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
        private readonly EditFeedViewModel _editFeedViewModel;  

        public SettingsViewModel(FeedService feedService, SettingsService settingsService)
        {
            _feedService = feedService;
            _settingsService = settingsService;         
            _editFeedViewModel = new EditFeedViewModel(feedService, settingsService);
        }

        public static string AppVersion { get => AppInfo.VersionString; }

        public EditFeedViewModel EditFeedViewModel
        {
            get => _editFeedViewModel;
        }


        internal async Task InitializeAsync()
        {
            await _editFeedViewModel.InitializeAsync();
           
        }




    }
}
