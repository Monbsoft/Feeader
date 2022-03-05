using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Pages;

public partial class FeedListPage : ContentPage
{
    public FeedListPage(FeedListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    public FeedListViewModel ViewModel => BindingContext as FeedListViewModel;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.InitializeAsync();
    }

}
