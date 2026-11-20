using System;
using System.Text;

namespace CsvHelper;

[Serializable]
public class CsvHelperException : Exception
{
	[NonSerialized]
	private readonly CsvContext? context;

	public CsvContext? Context => context;

	protected internal CsvHelperException()
	{
	}

	protected internal CsvHelperException(string message)
		: base(message)
	{
	}

	protected internal CsvHelperException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public CsvHelperException(CsvContext context)
	{
		this.context = context;
	}

	public CsvHelperException(CsvContext context, string message)
		: base(AddDetails(message, context))
	{
		this.context = context;
	}

	public CsvHelperException(CsvContext context, string message, Exception innerException)
		: base(AddDetails(message, context), innerException)
	{
		this.context = context;
	}

	private static string AddDetails(string message, CsvContext context)
	{
		string value = new string(' ', 3);
		StringBuilder stringBuilder = new StringBuilder();
		if (context.Reader != null)
		{
			stringBuilder.AppendLine("IReader state:");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("ColumnCount");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Reader.ColumnCount);
			stringBuilder3.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("CurrentIndex");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Reader.CurrentIndex);
			stringBuilder4.AppendLine(ref handler);
			try
			{
				StringBuilder stringBuilder5 = new StringBuilder();
				if (context.Reader.HeaderRecord != null)
				{
					stringBuilder5.Append("[\"");
					stringBuilder5.Append(string.Join("\",\"", context.Reader.HeaderRecord));
					stringBuilder5.Append("\"]");
				}
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder6 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(1, 4, stringBuilder2);
				handler.AppendFormatted(value);
				handler.AppendFormatted("HeaderRecord");
				handler.AppendLiteral(":");
				handler.AppendFormatted("\n");
				handler.AppendFormatted(stringBuilder5);
				stringBuilder6.AppendLine(ref handler);
			}
			catch
			{
			}
		}
		if (context.Parser != null)
		{
			stringBuilder.AppendLine("IParser state:");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder7 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("ByteCount");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Parser.ByteCount);
			stringBuilder7.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder8 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("CharCount");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Parser.CharCount);
			stringBuilder8.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder9 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("Row");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Parser.Row);
			stringBuilder9.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder10 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("RawRow");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Parser.RawRow);
			stringBuilder10.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder11 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("Count");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Parser.Count);
			stringBuilder11.AppendLine(ref handler);
			try
			{
				string value2 = (context.Configuration.ExceptionMessagesContainRawData ? context.Parser.RawRecord : "Hidden because ExceptionMessagesContainRawData is false.");
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder12 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(1, 4, stringBuilder2);
				handler.AppendFormatted(value);
				handler.AppendFormatted("RawRecord");
				handler.AppendLiteral(":");
				handler.AppendFormatted("\n");
				handler.AppendFormatted(value2);
				stringBuilder12.AppendLine(ref handler);
			}
			catch
			{
			}
		}
		if (context.Writer != null)
		{
			stringBuilder.AppendLine("IWriter state:");
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder13 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("Row");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Writer.Row);
			stringBuilder13.AppendLine(ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder14 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(2, 3, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("Index");
			handler.AppendLiteral(": ");
			handler.AppendFormatted(context.Writer.Index);
			stringBuilder14.AppendLine(ref handler);
			StringBuilder stringBuilder15 = new StringBuilder();
			if (context.Writer.HeaderRecord != null)
			{
				stringBuilder15.Append("[");
				if (context.Writer.HeaderRecord.Length != 0)
				{
					stringBuilder15.Append("\"");
					stringBuilder15.Append(string.Join("\",\"", context.Writer.HeaderRecord));
					stringBuilder15.Append("\"");
				}
				stringBuilder15.Append("]");
			}
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder16 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(1, 4, stringBuilder2);
			handler.AppendFormatted(value);
			handler.AppendFormatted("HeaderRecord");
			handler.AppendLiteral(":");
			handler.AppendFormatted("\n");
			handler.AppendFormatted(context.Writer.Row);
			stringBuilder16.AppendLine(ref handler);
		}
		return $"{message}{"\n"}{stringBuilder}";
	}
}
