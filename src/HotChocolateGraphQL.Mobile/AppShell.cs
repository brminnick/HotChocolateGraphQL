namespace HotChocolateGraphQL.Mobile;

class AppShell : Shell
{
	public AppShell()
	{
		Items.Add(new ShellContent { ContentTemplate = new DataTemplate(typeof(LibraryPage)) });
	}

	public static string GetRoute<TPage, TViewModel>() where TPage : BasePage<TViewModel>
														where TViewModel : BaseViewModel
	{
		return typeof(TPage).Name switch
		{
			nameof(LibraryPage) => $"//{nameof(LibraryPage)}",
			_ => throw new NotSupportedException($"No Route Added for {typeof(TPage).Name}")
		};
	}
}