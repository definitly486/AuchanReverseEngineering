using System;
using NLog.Internal;

namespace NLog.Config;

internal abstract class LoggerNameMatcher
{
	private sealed class NoneLoggerNameMatcher : LoggerNameMatcher
	{
		public static readonly NoneLoggerNameMatcher Instance = new NoneLoggerNameMatcher();

		protected override string MatchMode => "None";

		private NoneLoggerNameMatcher()
			: base(string.Empty, null)
		{
		}

		public override bool NameMatches(string loggerName)
		{
			return false;
		}
	}

	private sealed class AllLoggerNameMatcher : LoggerNameMatcher
	{
		public static readonly AllLoggerNameMatcher Instance = new AllLoggerNameMatcher();

		protected override string MatchMode => "All";

		private AllLoggerNameMatcher()
			: base("*", null)
		{
		}

		public override bool NameMatches(string loggerName)
		{
			return true;
		}
	}

	private sealed class EqualsLoggerNameMatcher : LoggerNameMatcher
	{
		protected override string MatchMode => "Equals";

		public EqualsLoggerNameMatcher(string pattern)
			: base(pattern, pattern)
		{
		}

		public override bool NameMatches(string loggerName)
		{
			return loggerName?.Equals(_matchingArgument, StringComparison.Ordinal) ?? (_matchingArgument == null);
		}
	}

	private sealed class StartsWithLoggerNameMatcher : LoggerNameMatcher
	{
		protected override string MatchMode => "StartsWith";

		public StartsWithLoggerNameMatcher(string pattern)
			: base(pattern, pattern.Substring(0, pattern.Length - 1))
		{
		}

		public override bool NameMatches(string loggerName)
		{
			return loggerName?.StartsWith(_matchingArgument, StringComparison.Ordinal) ?? (_matchingArgument == null);
		}
	}

	private sealed class EndsWithLoggerNameMatcher : LoggerNameMatcher
	{
		protected override string MatchMode => "EndsWith";

		public EndsWithLoggerNameMatcher(string pattern)
			: base(pattern, pattern.Substring(1))
		{
		}

		public override bool NameMatches(string loggerName)
		{
			return loggerName?.EndsWith(_matchingArgument, StringComparison.Ordinal) ?? (_matchingArgument == null);
		}
	}

	private sealed class ContainsLoggerNameMatcher : LoggerNameMatcher
	{
		protected override string MatchMode => "Contains";

		public ContainsLoggerNameMatcher(string pattern)
			: base(pattern, pattern.Substring(1, pattern.Length - 2))
		{
		}

		public override bool NameMatches(string loggerName)
		{
			if (loggerName == null)
			{
				return _matchingArgument == null;
			}
			return loggerName.IndexOf(_matchingArgument, StringComparison.Ordinal) >= 0;
		}
	}

	private sealed class MultiplePatternLoggerNameMatcher : LoggerNameMatcher
	{
		private readonly string _wildCardPattern;

		protected override string MatchMode => "MultiplePattern";

		public MultiplePatternLoggerNameMatcher(string pattern)
			: base(pattern, pattern)
		{
			_wildCardPattern = Guard.ThrowIfNull(pattern, "pattern");
		}

		public override bool NameMatches(string loggerName)
		{
			return MatchingName(0, _wildCardPattern.Length, loggerName, 0, loggerName?.Length ?? 0);
		}

		private bool MatchingName(int wildcardStart, int wildcardEnd, string loggerName, int loggerNameStart, int loggerNameEnd)
		{
			for (int i = wildcardStart; i < wildcardEnd; i++)
			{
				char c = _wildCardPattern[i];
				if (c == '*')
				{
					break;
				}
				if (loggerNameStart >= loggerNameEnd)
				{
					return false;
				}
				char c2 = loggerName[loggerNameStart];
				if (c != '?' && c != c2)
				{
					return false;
				}
				loggerNameStart++;
				wildcardStart++;
			}
			for (int num = wildcardEnd - 1; num >= wildcardStart; num--)
			{
				char c3 = _wildCardPattern[num];
				if (c3 == '*')
				{
					break;
				}
				if (loggerNameStart >= loggerNameEnd)
				{
					return false;
				}
				char c4 = loggerName[loggerNameEnd - 1];
				if (c3 != '?' && c3 != c4)
				{
					return false;
				}
				loggerNameEnd--;
				wildcardEnd--;
			}
			char c5 = '*';
			for (int j = wildcardStart; j < wildcardEnd; j++)
			{
				c5 = _wildCardPattern[j];
				if (c5 != '*')
				{
					break;
				}
				wildcardStart++;
			}
			if (c5 == '*')
			{
				return true;
			}
			for (int k = loggerNameStart; k < loggerNameEnd; k++)
			{
				char c6 = loggerName[k];
				if (c5 == '?' || c6 == c5)
				{
					return MatchingName(wildcardStart, wildcardEnd, loggerName, k, loggerNameEnd);
				}
			}
			return false;
		}
	}

	protected readonly string? _matchingArgument;

	private readonly string _toString;

	public static LoggerNameMatcher Off => NoneLoggerNameMatcher.Instance;

	public string Pattern { get; }

	protected abstract string MatchMode { get; }

	public static LoggerNameMatcher Create(string loggerNamePattern)
	{
		if (loggerNamePattern == null)
		{
			return NoneLoggerNameMatcher.Instance;
		}
		if (loggerNamePattern.Trim() == "*")
		{
			return AllLoggerNameMatcher.Instance;
		}
		int num = loggerNamePattern.IndexOf('*');
		int num2 = loggerNamePattern.IndexOf('*', num + 1);
		int num3 = loggerNamePattern.IndexOf('?');
		if (num < 0 && num3 < 0)
		{
			return new EqualsLoggerNameMatcher(loggerNamePattern);
		}
		if (num3 < 0)
		{
			if (num == 0 && num2 == loggerNamePattern.Length - 1)
			{
				return new ContainsLoggerNameMatcher(loggerNamePattern);
			}
			if (num == 0 && num2 < 0)
			{
				return new EndsWithLoggerNameMatcher(loggerNamePattern);
			}
			if (num == loggerNamePattern.Length - 1 && num2 < 0)
			{
				return new StartsWithLoggerNameMatcher(loggerNamePattern);
			}
		}
		return new MultiplePatternLoggerNameMatcher(loggerNamePattern);
	}

	protected LoggerNameMatcher(string pattern, string? matchingArgument)
	{
		Pattern = pattern;
		_matchingArgument = matchingArgument;
		_toString = "logNamePattern: (" + matchingArgument + ":" + MatchMode + ")";
	}

	public override string ToString()
	{
		return _toString;
	}

	public abstract bool NameMatches(string loggerName);
}
