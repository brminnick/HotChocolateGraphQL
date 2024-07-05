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
						.Bind(CollectionView.ItemsSourceProperty, 
							getter: static (BooksViewModel vm) => vm.Books, 
							mode: BindingMode.OneTime)

		}.Bind(RefreshView.IsRefreshingProperty, 
				getter: static (BooksViewModel vm) => vm.IsRefreshing,
				setter: static (BooksViewModel vm, bool isRefreshing) => vm.IsRefreshing = isRefreshing)
		 .Bind(RefreshView.CommandProperty, 
			 getter: static (BooksViewModel vm) => vm.RefreshBooksCommand, mode: BindingMode.OneTime);
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