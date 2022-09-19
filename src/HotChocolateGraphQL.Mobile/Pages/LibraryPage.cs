using System;
namespace HotChocolateGraphQL.Mobile;

class LibraryPage : BasePage<LibraryViewModel>
{
	public LibraryPage(LibraryViewModel libraryViewModel, IDispatcher dispatcher) : base(libraryViewModel, dispatcher, "Library")
	{
	}
}

