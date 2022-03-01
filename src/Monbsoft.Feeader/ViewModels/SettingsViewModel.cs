using Monbsoft.Feeader.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Monbsoft.Feeader.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly SettingsService _settingsService;       
        private string _newFeedUrl;

        public SettingsViewModel(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public static string AppVersion { get => AppInfo.VersionString; }

        public ICommand AddFeedCommand => new AsyncCommand(AddFeedCommandExecute);

        public string NewFeedUrl
        {
            get { return _newFeedUrl; }   
            set { SetProperty(ref _newFeedUrl, value); }  
        }

        internal async Task InitializeAsync()
        {
            var test = await _settingsService.ReadFeedsAsync();
        }

        public async Task AddFeedCommandExecute()
        {
            await _settingsService.SaveAsync(NewFeedUrl);
        }
    }
}
