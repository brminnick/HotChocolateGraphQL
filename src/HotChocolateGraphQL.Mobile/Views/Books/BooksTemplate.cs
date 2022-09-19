using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace HotChocolateGraphQL.Mobile;

class BooksTemplate : DataTemplate
{
	public BooksTemplate() : base(CreateBooksTemplate)
	{

	}

	static Grid CreateBooksTemplate() => new()
	{
		RowSpacing = 1,

		RowDefinitions = Rows.Define(
			(Row.Title, 20),
			(Row.Author, 20),
			(Row.Separator, 1)),

		Children =
		{
			new BlackTextLabel(16).CenterVertical().Font(bold: true)
				.Row(Row.Title)
				.Bind(Label.TextProperty, nameof(IGetBooksQuery_Books.Title)),

			new BlackTextLabel(13).Font(italic: true).Margins(bottom: 5)
				.Row(Row.Author)
				.Bind(Label.TextProperty, nameof(IGetBooksQuery_Books.Author), convert: static (IGetBooksQuery_Books_Author? author) => $"by {author?.Name ?? "Unknown"}"),

			new BoxView { Color = Colors.DarkGray }.Margin(5, 0)
				.Row(Row.Separator)
		}
	};

	enum Row { Title, Author, Separator }

	class BlackTextLabel : Label
	{
		public BlackTextLabel(double fontSize)
		{
			FontSize = fontSize;
			Padding = new Thickness(10, 0);
			TextColor = Colors.Black;
			LineBreakMode = LineBreakMode.TailTruncation;
		}
	}
}