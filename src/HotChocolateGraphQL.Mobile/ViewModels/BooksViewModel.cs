using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace HotChocolateGraphQL.Mobile;

partial class BooksViewModel : BaseViewModel
{
	readonly LibraryGraphQLClient _client;

	public BooksViewModel(LibraryGraphQLClient client, IDispatcher dispatcher) : base(dispatcher)
	{
		_client = client;
	}

	public ObservableCollection<IGetBooksQuery_Books> Books { get; } = new();

	[RelayCommand]
	async Task RefreshBooks(CancellationToken token)
	{

	}
}