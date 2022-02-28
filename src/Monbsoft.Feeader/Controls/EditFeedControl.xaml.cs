using System.Windows.Input;

namespace Monbsoft.Feeader.Controls;

public partial class EditFeedControl : ContentView
{

	public EditFeedControl()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty AddCommandProperty =
		BindableProperty.Create(
			nameof(AddCommand),
			typeof(ICommand),
			typeof(EditFeedControl),
			null);

	public static readonly BindableProperty FeedUrlProperty =
		BindableProperty.Create(
			nameof(FeedUrl),
			typeof(string),
			typeof(EditFeedControl),
			string.Empty);


	public ICommand AddCommand
    {
		get { return (ICommand)GetValue(AddCommandProperty); }
		set { SetValue(AddCommandProperty, value); }
    }

	public string FeedUrl
	{
		get { return (string)GetValue(FeedUrlProperty); }
		set { SetValue(FeedUrlProperty, value); }

	}
}