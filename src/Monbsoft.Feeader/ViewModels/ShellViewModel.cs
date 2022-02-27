using Monbsoft.Feeader.Models;
using Monbsoft.Feeader.Resources.Strings;
using MvvmHelpers;

namespace Monbsoft.Feeader.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public ShellViewModel()
        {
            Feeds = new AppSection() { Title = StringResources.Feeds };
            Settings = new AppSection() { Title = StringResources.Settings };
        }

        public AppSection Feeds { get; set; }
        public AppSection Settings { get; set; }
    }
}