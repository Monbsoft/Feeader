using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Pages;

public partial class DesktopShell
{
	public DesktopShell(ShellViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}