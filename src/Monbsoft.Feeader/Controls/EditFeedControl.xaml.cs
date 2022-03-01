using System.Windows.Input;

namespace Monbsoft.Feeader.Controls;

public partial class EditFeedControl : ContentView
{

	public EditFeedControl()
	{
		InitializeComponent();

		//BindingContext = this;
	}

	public static readonly BindableProperty AddCommandProperty =
		BindableProperty.Create(
			nameof(AddCommand),
			typeof(ICommand),
			typeof(EditFeedControl),
			null);

	public static readonly BindableProperty NewFeedUrlProperty =
		BindableProperty.Create(
			nameof(NewFeedUrl),
			typeof(string),
			typeof(EditFeedControl),
			string.Empty);


	public ICommand AddCommand
	{
		get => (ICommand)GetValue(AddCommandProperty);
		set => SetValue(AddCommandProperty, value);
	}

	public string NewFeedUrl
	{
		get { return (string)GetValue(NewFeedUrlProperty); }
		set { SetValue(NewFeedUrlProperty, value); }

	}
}