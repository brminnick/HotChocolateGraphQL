using System.Collections;

namespace HotChocolateGraphQL.Mobile;

public static class EnumerableExtensions
{
	public static bool IsEnumerableNullOrEmpty(this IEnumerable? enumerable) => enumerable is not null && !enumerable.GetEnumerator().MoveNext();
}

