using System.Runtime.CompilerServices;
using StrawberryShake;

namespace HotChocolateGraphQL.Mobile;

class GraphQLService
{
	readonly LibraryGraphQLClient _client;

	public GraphQLService(LibraryGraphQLClient client)
	{
		_client = client;
	}

	public async IAsyncEnumerable<IGetBooksQuery_Books> GetBooks([EnumeratorCancellation] CancellationToken token)
	{
		var result = await _client.GetBooksQuery.ExecuteAsync(token).ConfigureAwait(false);
		result.EnsureNoErrors();

		foreach (var book in result.Data?.Books ?? [])
			yield return book;
	}
}