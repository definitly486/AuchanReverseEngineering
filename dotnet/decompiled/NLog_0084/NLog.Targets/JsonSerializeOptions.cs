using System;
using System.ComponentModel;

namespace NLog.Targets;

public class JsonSerializeOptions
{
	[Obsolete("Marked obsolete with NLog 5.0.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool QuoteKeys { get; set; } = true;

	[Obsolete("Marked obsolete with NLog 5.0. Should always be InvariantCulture.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IFormatProvider? FormatProvider { get; set; }

	[Obsolete("Marked obsolete with NLog 5.0. Should always be InvariantCulture.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public string? Format { get; set; }

	public bool EscapeUnicode { get; set; }

	[Obsolete("Marked obsolete with NLog 5.5. Should never escape forward slash")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool EscapeForwardSlash { get; set; }

	public bool EnumAsInteger { get; set; }

	public bool SuppressSpaces { get; set; } = true;

	public bool SanitizeDictionaryKeys { get; set; }

	public int MaxRecursionLimit { get; set; } = 10;
}
