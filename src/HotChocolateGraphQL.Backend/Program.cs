using HotChocolateGraphQL.Backend;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
				.AddQueryType<Query>();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();
app.UseRouting()
	.UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();