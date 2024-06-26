using CommunityToolkit.Mvvm.ComponentModel;

namespace HotChocolateGraphQL.Mobile;

abstract partial class BaseViewModel(IDispatcher dispatcher) : ObservableObject
{
	protected IDispatcher Dispatcher { get; } = dispatcher;
}