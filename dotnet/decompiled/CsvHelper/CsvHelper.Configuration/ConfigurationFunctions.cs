using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper.Delegates;

namespace CsvHelper.Configuration;

public static class ConfigurationFunctions
{
	private static readonly char[] lineEndingChars = new char[2] { '\r', '\n' };

	public static void HeaderValidated(HeaderValidatedArgs args)
	{
		if (args.InvalidHeaders.Count() == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		InvalidHeader[] invalidHeaders = args.InvalidHeaders;
		foreach (InvalidHeader invalidHeader in invalidHeaders)
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(36, 2, stringBuilder2);
			handler.AppendLiteral("Header with name '");
			handler.AppendFormatted(string.Join("' or '", invalidHeader.Names));
			handler.AppendLiteral("'[");
			handler.AppendFormatted(invalidHeader.Index);
			handler.AppendLiteral("] was not found.");
			stringBuilder3.AppendLine(ref handler);
		}
		if (args.Context.Reader?.HeaderRecord != null)
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder2);
			handler.AppendLiteral("Headers: '");
			handler.AppendFormatted(string.Join("', '", args.Context.Reader.HeaderRecord));
			handler.AppendLiteral("'");
			stringBuilder4.AppendLine(ref handler);
		}
		string value = "If you are expecting some headers to be missing and want to ignore this validation, set the configuration HeaderValidated to null. You can also change the functionality to do something else, like logging the issue.";
		stringBuilder.AppendLine(value);
		throw new HeaderValidationException(args.Context, args.InvalidHeaders, stringBuilder.ToString());
	}

	public static void MissingFieldFound(MissingFieldFoundArgs args)
	{
		string value = "You can ignore missing fields by setting MissingFieldFound to null.";
		if (args.HeaderNames == null || args.HeaderNames.Length == 0)
		{
			throw new MissingFieldException(args.Context, $"Field at index '{args.Index}' does not exist. {value}");
		}
		string value2 = ((args.Index > 0) ? $" at field index '{args.Index}'" : string.Empty);
		if (args.HeaderNames.Length == 1)
		{
			throw new MissingFieldException(args.Context, $"Field with name '{args.HeaderNames[0]}'{value2} does not exist. {value}");
		}
		throw new MissingFieldException(args.Context, $"Field containing names '{string.Join("' or '", args.HeaderNames)}'{value2} does not exist. {value}");
	}

	public static void BadDataFound(BadDataFoundArgs args)
	{
		throw new BadDataException(args.Field, args.RawRecord, args.Context, "You can ignore bad data by setting BadDataFound to null.");
	}

	public static bool ReadingExceptionOccurred(ReadingExceptionOccurredArgs args)
	{
		return true;
	}

	public static bool ShouldQuote(ShouldQuoteArgs args)
	{
		IWriterConfiguration configuration = args.Row.Configuration;
		string field = args.Field;
		if (field == null || field.Length == 0)
		{
			return false;
		}
		if (field[0] != ' ' && field[field.Length - 1] != ' ' && !field.Contains(configuration.Quote) && (configuration.IsNewLineSet || field.IndexOfAny(lineEndingChars) <= -1) && (!configuration.IsNewLineSet || !field.Contains(configuration.NewLine)))
		{
			if (configuration.Delimiter.Length > 0)
			{
				return field.Contains(configuration.Delimiter);
			}
			return false;
		}
		return true;
	}

	public static string PrepareHeaderForMatch(PrepareHeaderForMatchArgs args)
	{
		return args.Header ?? string.Empty;
	}

	public static bool ShouldUseConstructorParameters(ShouldUseConstructorParametersArgs args)
	{
		if (!args.ParameterType.HasParameterlessConstructor() && args.ParameterType.HasConstructor() && !args.ParameterType.IsValueType && !args.ParameterType.IsPrimitive && !args.ParameterType.IsEnum && !args.ParameterType.IsInterface)
		{
			return Type.GetTypeCode(args.ParameterType) == TypeCode.Object;
		}
		return false;
	}

	public static ConstructorInfo GetConstructor(GetConstructorArgs args)
	{
		return args.ClassType.GetConstructorWithMostParameters();
	}

	public static string GetDynamicPropertyName(GetDynamicPropertyNameArgs args)
	{
		if (args.Context.Reader?.HeaderRecord == null)
		{
			return $"Field{args.FieldIndex + 1}";
		}
		string header = args.Context.Reader.HeaderRecord[args.FieldIndex];
		PrepareHeaderForMatchArgs args2 = new PrepareHeaderForMatchArgs(header, args.FieldIndex);
		return args.Context.Reader.Configuration.PrepareHeaderForMatch(args2);
	}

	public static string GetDelimiter(GetDelimiterArgs args)
	{
		string text = args.Text;
		IParserConfiguration config = args.Configuration;
		if (config.Mode == CsvMode.RFC4180)
		{
			text = Regex.Replace(text, $"{config.Quote}.*?{config.Quote}", string.Empty, RegexOptions.Singleline);
		}
		else if (config.Mode == CsvMode.Escape)
		{
			text = Regex.Replace(text, $"({config.Escape}.)", string.Empty, RegexOptions.Singleline);
		}
		string text2 = config.NewLine;
		if (new string[3] { "\r\n", "\r", "\n" }.Contains(text2))
		{
			text2 = "\r\n|\r|\n";
		}
		List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
		while (text.Length > 0)
		{
			Match match = Regex.Match(text, text2);
			string text3 = (match.Success ? text.Substring(0, match.Index) : text);
			if (text3.Length > 0)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				string[] detectDelimiterValues = config.DetectDelimiterValues;
				foreach (string text4 in detectDelimiterValues)
				{
					string pattern = Regex.Replace(text4, "([.$^{\\[(|)*+?\\\\])", "\\$1");
					dictionary[text4] = Regex.Matches(text3, pattern).Count;
				}
				list.Add(dictionary);
			}
			text = (match.Success ? text.Substring(match.Index + match.Length) : string.Empty);
		}
		if (list.Count > 1)
		{
			list.Remove(list.Last());
		}
		var source = (from counts in list
			from count in counts
			group count by count.Key into g
			where g.All((KeyValuePair<string, int> x) => x.Value > 0)
			let sum = g.Sum((KeyValuePair<string, int> x) => x.Value)
			orderby sum descending
			select new
			{
				Delimiter = g.Key,
				Count = sum
			}).ToList();
		string text5 = null;
		text5 = ((!source.Any(x => x.Delimiter == config.CultureInfo.TextInfo.ListSeparator) || list.Count <= 1) ? source.Select(x => x.Delimiter).FirstOrDefault() : config.CultureInfo.TextInfo.ListSeparator);
		if (text5 != null)
		{
			config.Validate();
		}
		return text5 ?? config.Delimiter;
	}
}
