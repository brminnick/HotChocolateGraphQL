using HotChocolateGraphQL.Backend.Models;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
				.AddQueryType<Query>();

var app = builder.Build();
app.UseRouting()
	.UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();

namespace HotChocolateGraphQL.Backend.Models
{
	public class Author
	{
		public string Name { get; init; } = string.Empty;
	}

	public class Book
	{
		public string Title { get; init; } = string.Empty;
		public Author? Author { get; init; }
	}

	public class Query
	{
		public Book GetBook() => new()
		{
			Title = "C# In Depth",
			Author = new()
			{
				Name = "Jon Skeet"
			}
		};
	}
}