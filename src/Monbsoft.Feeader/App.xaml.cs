using Monbsoft.Feeader.Pages;
using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader
{
    public partial class App : Application
    {
        public App(ShellViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new DesktopShell(viewModel);
        }
    }
}