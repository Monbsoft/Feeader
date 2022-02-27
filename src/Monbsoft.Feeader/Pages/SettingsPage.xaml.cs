using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	public SettingsViewModel ViewModel => BindingContext as SettingsViewModel;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await ViewModel.InitializeAsync();

	}
}