using Monbsoft.Feeader.Pages;
using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader
{
    public partial class App : Application
    {
        public App(MainViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new MainPage(viewModel);
        }
    }
}