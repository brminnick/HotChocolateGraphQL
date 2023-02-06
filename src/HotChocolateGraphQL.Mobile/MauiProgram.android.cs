namespace HotChocolateGraphQL.Mobile;

public static partial class MauiProgram
{
	const string _androidDebugHost = "10.0.2.2";

	private static partial Uri GetGraphQLUri(in Uri uri)
	{
#if DEBUG
		return new UriBuilder(Uri.UriSchemeHttp, _androidDebugHost, uri.Port, uri.PathAndQuery).Uri;
#else
		return new UriBuilder(Uri.UriSchemeHttps, uri.Host, uri.Port, uri.PathAndQuery).Uri;
#endif
	}

	private static partial Uri GetGraphQLStreamingUri(in Uri uri)
	{
#if DEBUG
		return new UriBuilder(Uri.UriSchemeWs, _androidDebugHost, uri.Port, uri.PathAndQuery).Uri;
#else
		return new UriBuilder(Uri.UriSchemeWs, uri.Host, uri.Port, uri.PathAndQuery).Uri;
#endif
	}

	private static partial HttpMessageHandler GetHttpMessageHandler()
	{
#if DEBUG
		return new HttpClientHandler { AutomaticDecompression = GetDecompressionMethods() };
#else
		return new Xamarin.Android.Net.AndroidMessageHandler { AutomaticDecompression = GetDecompressionMethods() };
#endif
	}
}