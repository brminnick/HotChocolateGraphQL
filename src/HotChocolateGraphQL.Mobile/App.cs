using System;
using CommunityToolkit.Maui.Markup;

namespace HotChocolateGraphQL.Mobile;

class App : Application
{
	public App(AppShell appShell)
	{
		Resources = new()
		{
			new Style<NavigationPage>(
						(NavigationPage.BarTextColorProperty, Colors.Black),
						(NavigationPage.BarBackgroundColorProperty, Color.FromArgb("F1B340"))).ApplyToDerivedTypes(true),

			new Style<Shell>(
				(Shell.NavBarHasShadowProperty, true),
				(Shell.TitleColorProperty, Colors.Black),
				(Shell.DisabledColorProperty, Colors.Black),
				(Shell.UnselectedColorProperty, Colors.Black),
				(Shell.ForegroundColorProperty, Colors.Black),
				(Shell.BackgroundColorProperty, Color.FromArgb("F1B340"))).ApplyToDerivedTypes(true)
		};

		MainPage = appShell;
	}
}