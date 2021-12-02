using System;

namespace HotChocolateGraphQL.Backend;

public class BookQuery
{
	readonly IReadOnlyList<Book> _books = GenerateBooks(10).ToList();

	public IEnumerable<Book> GetBooks() => _books;

	public Book GetBook(string title) => _books.First(x => x.Title == title);

	public Author GetAuthor(string name) => _books.First(x => x.Author.Name == name).Author;

	static IEnumerable<Book> GenerateBooks(int count)
	{
		for (int i = 0; i < count; i++)
		{
			yield return new Book(LoremIpsum.Generate(2, 10),
							new Author(LoremIpsum.Generate(1, 2), new DateOnly(1970, 1, 1)));
		}
	}
}