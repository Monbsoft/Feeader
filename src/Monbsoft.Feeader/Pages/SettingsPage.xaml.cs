using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}