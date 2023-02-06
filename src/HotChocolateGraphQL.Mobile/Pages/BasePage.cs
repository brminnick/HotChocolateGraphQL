using System.Diagnostics;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace HotChocolateGraphQL.Mobile;

abstract class BasePage<TViewModel> : BasePage where TViewModel : BaseViewModel
{
	protected BasePage(in TViewModel viewModel, in string? title = null, in bool shouldUseSafeArea = true) : base(viewModel, title)
	{
		On<iOS>().SetUseSafeArea(shouldUseSafeArea);
		On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
	}

	public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

abstract partial class BasePage : ContentPage
{
	protected BasePage(in object? viewModel = null, in string? title = null)
	{
		BindingContext = viewModel;
		Title = title;
		Padding = 12;

		if (string.IsNullOrWhiteSpace(Title))
		{
			Title = GetType().Name;
		}
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		Debug.WriteLine($"OnAppearing: {Title}");
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		Debug.WriteLine($"OnDisappearing: {Title}");
	}
}