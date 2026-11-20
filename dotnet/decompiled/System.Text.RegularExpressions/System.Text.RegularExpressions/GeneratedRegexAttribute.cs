using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed class GeneratedRegexAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string _003CPattern_003Ek__BackingField;

	[CompilerGenerated]
	private readonly RegexOptions _003COptions_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CMatchTimeoutMilliseconds_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CCultureName_003Ek__BackingField;

	public GeneratedRegexAttribute([StringSyntax("Regex")] string pattern)
		: this(pattern, RegexOptions.None)
	{
	}

	public GeneratedRegexAttribute([StringSyntax("Regex", new object[] { "options" })] string pattern, RegexOptions options)
		: this(pattern, options, -1)
	{
	}

	public GeneratedRegexAttribute([StringSyntax("Regex", new object[] { "options" })] string pattern, RegexOptions options, int matchTimeoutMilliseconds)
		: this(pattern, options, matchTimeoutMilliseconds, string.Empty)
	{
	}

	public GeneratedRegexAttribute([StringSyntax("Regex", new object[] { "options" })] string pattern, RegexOptions options, int matchTimeoutMilliseconds, string cultureName)
	{
		_003CPattern_003Ek__BackingField = pattern;
		_003COptions_003Ek__BackingField = options;
		_003CMatchTimeoutMilliseconds_003Ek__BackingField = matchTimeoutMilliseconds;
		_003CCultureName_003Ek__BackingField = cultureName;
	}
}
