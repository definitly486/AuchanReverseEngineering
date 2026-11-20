using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public static class StackTraceParser
{
	private static readonly Regex _regex = new Regex("^\\s*at (?<className>.+)\\.(?<methodName>.+\\(.*\\))( in (?<fileName>.+):line (?<lineNumber>\\d+))?\\s*$", RegexOptions.Multiline | RegexOptions.ExplicitCapture, TimeSpan.FromMinutes(1L));

	public static IEnumerable<StackFrame> Parse(Exception? exception)
	{
		List<StackFrame> list = new List<StackFrame>();
		ParseException(exception, list);
		return list;
	}

	private static void ParseException(Exception? exception, List<StackFrame> stackFrames)
	{
		if (exception == null)
		{
			return;
		}
		stackFrames.AddRange(ParseStackTrace(exception.StackTrace));
		if (exception is AggregateException ex)
		{
			int num = 0;
			{
				foreach (Exception innerException in ex.InnerExceptions)
				{
					ParseInnerException(innerException, num, stackFrames);
					num++;
				}
				return;
			}
		}
		if (exception.InnerException != null)
		{
			ParseInnerException(exception.InnerException, 0, stackFrames);
		}
	}

	private static void ParseInnerException(Exception innerException, int number, List<StackFrame> stackFrames)
	{
		(string? NamespaceName, string ClassName) namespaceNameAndClassName = GetNamespaceNameAndClassName(innerException.GetType());
		string item = namespaceNameAndClassName.NamespaceName;
		string item2 = namespaceNameAndClassName.ClassName;
		string methodName = string.Empty;
		if (!string.IsNullOrEmpty(item))
		{
			methodName = item2 + ": " + innerException.Message;
			item2 = $"(Inner Exception #{number}) {item}";
		}
		else
		{
			item2 = $"(Inner Exception #{number}) {item2}: {innerException.Message}";
		}
		stackFrames.Add(new StackFrame(item2, methodName, "", 0));
		ParseException(innerException, stackFrames);
	}

	private static (string? NamespaceName, string ClassName) GetNamespaceNameAndClassName(Type type)
	{
		string text = type.ToString();
		string text2 = type.Namespace;
		if (!string.IsNullOrEmpty(text2))
		{
			text = text.Substring(text2.Length + 1);
		}
		return (NamespaceName: text2, ClassName: text);
	}

	private static IEnumerable<StackFrame> ParseStackTrace(string? stackTrace)
	{
		if (string.IsNullOrEmpty(stackTrace))
		{
			yield break;
		}
		foreach (Match item in _regex.Matches(stackTrace))
		{
			string value = item.Groups["className"].Value;
			string value2 = item.Groups["methodName"].Value;
			Group obj2 = item.Groups["lineNumber"];
			int num = (obj2.Success ? int.Parse(obj2.Value) : 0);
			Group obj3 = item.Groups["fileName"];
			string fileName = ((obj3.Success && num > 0) ? obj3.Value : "<unknown>");
			yield return new StackFrame(value, value2, fileName, num);
		}
	}
}
