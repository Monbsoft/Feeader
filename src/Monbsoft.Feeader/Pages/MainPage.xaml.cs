using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Pages;

public partial class MainPage : ContentPage
{
    private MainViewModel _viewModel => BindingContext as MainViewModel;

    public MainPage(MainViewModel mainViewModel)
    {
        InitializeComponent();

        BindingContext = mainViewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

}
