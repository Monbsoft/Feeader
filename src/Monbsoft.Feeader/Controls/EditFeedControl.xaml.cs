using Monbsoft.Feeader.Models;
using System.Collections.ObjectModel;
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

	public static readonly BindableProperty DeleteCommandProperty =
	BindableProperty.Create(
		nameof(DeleteCommand),
		typeof(ICommand),
		typeof(EditFeedControl),
		null);

	public static readonly BindableProperty FeedUrlProperty =
		BindableProperty.Create(
			nameof(FeedUrl),
			typeof(string),
			typeof(EditFeedControl),
			string.Empty);

	public static readonly BindableProperty FeedsProperty =
		BindableProperty.Create(
			nameof(Feeds),
			typeof(ObservableCollection<Feed>),
			typeof(EditFeedControl),
			null);


	public ICommand AddCommand
	{
		get => (ICommand)GetValue(AddCommandProperty);
		set => SetValue(AddCommandProperty, value);
	}

	public ICommand DeleteCommand
	{
		get => (ICommand)GetValue(DeleteCommandProperty);
		set => SetValue(DeleteCommandProperty, value);
	}



	public ObservableCollection<Feed> Feeds
    {
		get { return (ObservableCollection<Feed>)GetValue(FeedsProperty); }
		set { SetValue(FeedsProperty, value); }
    }


	public string FeedUrl
	{
		get { return (string)GetValue(FeedUrlProperty); }
		set { SetValue(FeedUrlProperty, value); }

	}

}