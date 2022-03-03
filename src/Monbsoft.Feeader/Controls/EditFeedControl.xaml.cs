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

	public static readonly BindableProperty NewFeedUrlProperty =
		BindableProperty.Create(
			nameof(NewFeedUrl),
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


	public ObservableCollection<Feed> Feeds
    {
		get { return (ObservableCollection<Feed>)GetValue(FeedsProperty); }
		set { SetValue(FeedsProperty, value); }
    }


	public string NewFeedUrl
	{
		get { return (string)GetValue(NewFeedUrlProperty); }
		set { SetValue(NewFeedUrlProperty, value); }

	}
}