namespace HotChocolateGraphQL.Backend;

public class Query
{
	readonly IReadOnlyList<Book> _books = new List<Book>
	{
		new Book("C# In Depth", new Author("Jon Skeet", DateOnly.MinValue)),
		new Book("Head First C#", new Author("Andrew Stellman", DateOnly.MinValue)),
		new Book("Full Stack Serverless", new Author("Nader Dabit", DateOnly.MinValue)),
		new Book("Learn C# in One Day and Learn It Well", new Author("Jaime Chan", DateOnly.MinValue)),
		new Book("Code That Fits In Your Head", new Author("Mark Seemanm", DateOnly.MinValue)),
		new Book("Hands On Visual Studio", new Author("Miguel Angel Teheran Garcia", DateOnly.MinValue)),
		new Book("Learning C# by Developing Games with Unity", new Author("Harrison Ferrone", DateOnly.MinValue)),
		new Book("Serverless GraphQL APIs with Amazon's AWS AppSync", new Author("Matthias Biehl", DateOnly.MinValue)),
		new Book("Mastering Regular Expressions", new Author("Jeffrey E. F. Friedl", DateOnly.MinValue)),
		new Book("The Road to GraphQL", new Author("Robin Wieruch", DateOnly.MinValue)),
		new Book("Full Stack GraphQL Applications", new Author("William Lyon", DateOnly.MinValue)),
		new Book("Learning GraphQL", new Author("Eve Porcello", DateOnly.MinValue)),
		new Book("C# 10 and .NET 6", new Author("Mark J Price", DateOnly.MinValue)),
		new Book("GraphQL in Action", new Author("Samer Buna", DateOnly.MinValue)),
		new Book("Software Architecture with C# 10 and .NET 6", new Author("Francesco Abbruzzese", DateOnly.MinValue)),
	};

	[GraphQLDescription("Returns all Books")]
	public IEnumerable<Book> GetBooks() => _books;

	[GraphQLDescription("Returns the specified Book")]
	public Book GetBook([GraphQLDescription("Book Title")] string title) =>
		_books.First(x => x.Title == title);

	[GraphQLDescription("Returns the specified Author")]
	public Author GetAuthor([GraphQLDescription("Author Name")] string name) =>
		_books.First(x => x.Author.Name == name).Author;
}