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
        public static string AppVersion { get => AppInfo.VersionString; }

    }
}
