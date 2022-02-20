using Monbsoft.Feeader.Pages;

namespace Monbsoft.Feeader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}