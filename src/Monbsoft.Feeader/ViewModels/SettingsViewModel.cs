using Monbsoft.Feeader.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly SettingsService _settingsService;
        public SettingsViewModel(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public static string AppVersion { get => AppInfo.VersionString; }

        internal async Task InitializeAsync()
        {
            var test = await _settingsService.GetFeedsAsync();
        }

    }
}
