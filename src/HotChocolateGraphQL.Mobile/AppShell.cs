namespace HotChocolateGraphQL.Mobile;

partial class AppShell : Shell
{
	public AppShell(BooksPage booksPage)
	{
		Items.Add(booksPage);
	}

	public static string GetRoute<TPage, TViewModel>() where TPage : BasePage<TViewModel>
														where TViewModel : BaseViewModel
	{
		return typeof(TPage).Name switch
		{
			nameof(BooksPage) => $"//{nameof(BooksPage)}",
			_ => throw new NotSupportedException($"No Route Added for {typeof(TPage).Name}")
		};
	}
}