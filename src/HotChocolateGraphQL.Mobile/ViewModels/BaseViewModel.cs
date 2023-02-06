using System.Collections;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HotChocolateGraphQL.Mobile;

abstract class BaseViewModel : ObservableObject
{
	public BaseViewModel(IDispatcher dispatcher) => Dispatcher = dispatcher;

	protected IDispatcher Dispatcher { get; }
}

static class ViewModelExtensions
{
	public static bool IsNullOrEmpty(this IEnumerable? enumerable) => !enumerable?.GetEnumerator().MoveNext() ?? true;
}