using CommunityToolkit.Maui.Markup;

namespace HotChocolateGraphQL.Mobile;

class BooksPage : BasePage<BooksViewModel>
{
	public BooksPage(BooksViewModel libraryViewModel, IDispatcher dispatcher) : base(libraryViewModel, dispatcher, "Books")
	{
		BackgroundColor = Color.FromArgb("F8E28B");

		Content = new CollectionView()
					.ItemTemplate(new BooksTemplate())
					.Bind(CollectionView.ItemsSourceProperty, nameof(BooksViewModel.Books));
	}

	protected override async void OnAppearing()
	{
		if (BindingContext.Books.IsNullOrEmpty())
		{
			var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
			await BindingContext.RefreshBooksCommand.ExecuteAsync(cts.Token);
		}
	}
}