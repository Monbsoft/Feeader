using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Pages;

public partial class FeedListPage : ContentPage
{
    private FeedListViewModel _viewModel => BindingContext as FeedListViewModel;

    public FeedListPage(FeedListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

}
