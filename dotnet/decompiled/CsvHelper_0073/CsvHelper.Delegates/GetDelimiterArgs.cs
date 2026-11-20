using CsvHelper.Configuration;

namespace CsvHelper.Delegates;

public readonly struct GetDelimiterArgs
{
	public readonly string Text;

	public readonly IParserConfiguration Configuration;

	public GetDelimiterArgs(string text, IParserConfiguration configuration)
	{
		Text = text;
		Configuration = configuration;
	}
}
