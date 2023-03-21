using CommunityToolkit.Maui.Markup;

namespace HotChocolateGraphQL.Mobile;

class BooksPage : BasePage<BooksViewModel>
{
	public BooksPage(BooksViewModel libraryViewModel) : base(libraryViewModel, "Books")
	{
		BackgroundColor = Color.FromArgb("F8E28B");

		Content = new RefreshView
		{
			RefreshColor = Colors.Black,
			Content = new CollectionView()
						.ItemTemplate(new BooksTemplate())
						.Bind(CollectionView.ItemsSourceProperty, static (BooksViewModel vm) => vm.Books, mode: BindingMode.OneTime)

		}.Bind(RefreshView.IsRefreshingProperty, static (BooksViewModel vm) => vm.IsRefreshing)
		 .Bind(RefreshView.CommandProperty, static (BooksViewModel vm) => vm.RefreshBooksCommand, mode: BindingMode.OneTime);
	}

	protected override void OnAppearing()
	{
		var refreshView = (RefreshView)Content;
		var collectionView = (CollectionView)refreshView.Content;

		if (collectionView.ItemsSource.IsNullOrEmpty())
		{
			refreshView.IsRefreshing = true;
		}
	}
}