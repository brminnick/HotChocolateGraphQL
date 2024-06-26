using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HotChocolateGraphQL.Mobile;

partial class BooksViewModel : BaseViewModel
{
	readonly LibraryGraphQLClient _client;

	[ObservableProperty]
	bool _isRefreshing;

	public BooksViewModel(GraphQLService graphQLService, IDispatcher dispatcher) : base(dispatcher)
	{
		_client = client;
	}

	public ObservableCollection<IGetBooksQuery_Books> Books { get; } = new();

	[RelayCommand]
	async Task RefreshBooks(CancellationToken token)
	{

		try
		{
			await foreach (var book in _graphQLService.GetBooks(token).ConfigureAwait(false))
			{
				Dispatcher.Dispatch(() => Books.Add(book));
			}
		}
		finally
		{
			IsRefreshing = false;
		}
	}
}