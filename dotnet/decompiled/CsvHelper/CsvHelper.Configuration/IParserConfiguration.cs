using System.Globalization;
using System.Text;
using CsvHelper.Delegates;

namespace CsvHelper.Configuration;

public interface IParserConfiguration
{
	CultureInfo CultureInfo { get; }

	bool CacheFields { get; }

	string NewLine { get; }

	bool IsNewLineSet { get; }

	CsvMode Mode { get; }

	int BufferSize { get; }

	int ProcessFieldBufferSize { get; }

	bool CountBytes { get; }

	Encoding Encoding { get; }

	BadDataFound? BadDataFound { get; }

	double MaxFieldSize { get; }

	bool LineBreakInQuotedFieldIsBadData { get; }

	char Comment { get; }

	bool AllowComments { get; }

	bool IgnoreBlankLines { get; }

	char Quote { get; }

	string Delimiter { get; }

	bool DetectDelimiter { get; }

	GetDelimiter GetDelimiter { get; }

	string[] DetectDelimiterValues { get; }

	char Escape { get; }

	TrimOptions TrimOptions { get; }

	char[] WhiteSpaceChars { get; }

	bool ExceptionMessagesContainRawData { get; }

	void Validate();
}
