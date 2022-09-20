using System.Net;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Polly;

namespace HotChocolateGraphQL.Mobile;

public static partial class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var graphQLUri = new Uri("http://localhost:5100/graphql");

		var builder = MauiApp.CreateBuilder()
						.UseMauiApp<App>()
						.UseMauiCommunityToolkit()
						.UseMauiCommunityToolkitMarkup()
						.ConfigureFonts(fonts =>
						{
							fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
							fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
						});

		// Add Shell
		builder.Services.AddTransient<AppShell>();

		// Add Pages + ViewModels
		builder.Services.AddTransientWithShellRoute<BooksPage, BooksViewModel>();

		// Add Services
		builder.Services.AddSingleton<GraphQLService>();

		builder.Services.AddLibraryGraphQLClient()
						.ConfigureHttpClient(client => client.BaseAddress = GetGraphQLUri(graphQLUri),
												clientBuilder => clientBuilder.ConfigurePrimaryHttpMessageHandler(GetHttpMessageHandler)
																				.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(3, sleepDurationProvider)))
						.ConfigureWebSocketClient(client => client.Uri = GetGraphQLStreamingUri(graphQLUri));

		return builder.Build();

		static TimeSpan sleepDurationProvider(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber));
	}

	static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection services) where TPage : BasePage<TViewModel>
																												where TViewModel : BaseViewModel
	{
		return services.AddTransientWithShellRoute<TPage, TViewModel>(AppShell.GetRoute<TPage, TViewModel>());
	}

	static DecompressionMethods GetDecompressionMethods() => DecompressionMethods.Deflate | DecompressionMethods.GZip;

	private static partial Uri GetGraphQLUri(in Uri uri);
	private static partial Uri GetGraphQLStreamingUri(in Uri uri);
	private static partial HttpMessageHandler GetHttpMessageHandler();
}