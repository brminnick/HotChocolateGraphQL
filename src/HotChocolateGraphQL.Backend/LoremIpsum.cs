using System.Text;

namespace HotChocolateGraphQL.Backend;

class LoremIpsum
{
	static readonly Random _random = new();

	static readonly IReadOnlyList<string> _wordList = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
		"adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
		"tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

	public static string Generate(int minWords, int maxWords)
	{
		int numWords = _random.Next(maxWords - minWords) + minWords + 1;

		var resultBuilder = new StringBuilder();

		for (int w = 0; w < numWords; w++)
		{
			if (w > 0)
				resultBuilder.Append(' ');

			resultBuilder.Append(_wordList[_random.Next(_wordList.Count)]);
		}

		return resultBuilder.ToString();
	}
}