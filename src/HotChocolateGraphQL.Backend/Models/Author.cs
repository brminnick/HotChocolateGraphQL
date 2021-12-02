using System;

namespace HotChocolateGraphQL.Backend;

public record Author
{
	public Author(string name, DateOnly birthday) =>
		(Name, BirthDay) = (name, birthday.ToDateTime(TimeOnly.MinValue));

	public string Name { get; init; }
	public DateTimeOffset BirthDay { get; init; }
}