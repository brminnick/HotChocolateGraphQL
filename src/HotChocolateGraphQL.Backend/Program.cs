using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
				.AddQueryType<Query>();

var app = builder.Build();
app.UseRouting()
	.UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();


public record Author(string Name);

public record Book(string Title, Author Author);

public class Query
{
	public Book GetBook() => new("C# In Depth", new("Jon Skeet"));
}