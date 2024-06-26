using System.Collections;

namespace HotChocolateGraphQL.Mobile;

public static class EnumerableExtensions
{
	public static bool IsNullOrEmpty(this IEnumerable? enumerable)
	{
		if (enumerable is null)
			return true;

		var enumerator = enumerable.GetEnumerator();

		try
		{
			return !enumerator.MoveNext();
		}
		finally
		{
			((IDisposable)enumerator).Dispose();
		}
	}
}