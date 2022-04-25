namespace HotChocolateGraphQL.Backend;

public record Author
{
	public Author(string name, DateOnly birthday) =>
		(Name, BirthDay) = (name, birthday);

	public string Name { get; init; }
	public DateOnly BirthDay { get; init; }
}