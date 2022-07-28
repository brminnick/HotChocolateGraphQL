namespace HotChocolateGraphQL.Backend;

public class BookQuery
{
	readonly IReadOnlyList<Book> _books = GenerateBooks(10).ToList();

	[GraphQLDescription("Returns all Books")]
	public IEnumerable<Book> GetBooks() => _books;

	[GraphQLDescription("Returns the specified Book")]
	public Book GetBook([GraphQLDescription("Book Title")] string title) =>
		_books.First(x => x.Title == title);

	[GraphQLDescription("Returns the specified Author")]
	public Author GetAuthor([GraphQLDescription("Author Name")] string name) =>
		_books.First(x => x.Author.Name == name).Author;

	static IEnumerable<Book> GenerateBooks(int count)
	{
		for (int i = 0; i < count; i++)
		{
			yield return new Book(LoremIpsum.Generate(2, 10),
									new Author(LoremIpsum.Generate(1, 2), new DateOnly(1970, 1, 1)));
		}
	}
}