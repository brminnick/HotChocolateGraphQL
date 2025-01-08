using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HotChocolateGraphQL.Mobile;

partial class BooksViewModel(GraphQLService graphQLService, IDispatcher dispatcher) : BaseViewModel(dispatcher)
{
	readonly GraphQLService _graphQLService = graphQLService;

	[ObservableProperty]
	public partial bool IsRefreshing { get; set; }

	public ObservableCollection<IGetBooksQuery_Books> Books { get; } = [];

	[RelayCommand]
	async Task RefreshBooks(CancellationToken token)
	{
		Books.Clear();

		var minimumRefreshTimeTask = Task.Delay(TimeSpan.FromSeconds(2), token);

		try
		{
			await foreach (var book in _graphQLService.GetBooks(token).ConfigureAwait(false))
			{
				Dispatcher.Dispatch(() => Books.Add(book));
			}
		}
		finally
		{
			await minimumRefreshTimeTask.ConfigureAwait(false);
			IsRefreshing = false;
		}
	}
}