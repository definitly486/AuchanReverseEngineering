using System;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal.Fakeables;

namespace NLog.LayoutRenderers;

[LayoutRenderer("appdomain")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class AppDomainLayoutRenderer : LayoutRenderer
{
	private const string ShortFormat = "{0:00}";

	private const string LongFormat = "{0:0000}:{1}";

	private const string FriendlyFormat = "{1}";

	private const string LongFormatCode = "Long";

	private const string ShortFormatCode = "Short";

	private const string FriendlyFormatCode = "Friendly";

	private readonly IAppEnvironment _currentAppEnvironment;

	private string? _assemblyName;

	[DefaultParameter]
	public string Format { get; set; } = "Long";

	public AppDomainLayoutRenderer()
		: this(LogFactory.DefaultAppEnvironment)
	{
	}

	internal AppDomainLayoutRenderer(IAppEnvironment appEnvironment)
	{
		_currentAppEnvironment = appEnvironment;
	}

	protected override void InitializeLayoutRenderer()
	{
		_assemblyName = null;
		base.InitializeLayoutRenderer();
	}

	protected override void CloseLayoutRenderer()
	{
		_assemblyName = null;
		base.CloseLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (_assemblyName == null)
		{
			string formattingString = GetFormattingString(Format);
			_assemblyName = string.Format(CultureInfo.InvariantCulture, formattingString, _currentAppEnvironment.AppDomainId, _currentAppEnvironment.AppDomainFriendlyName);
		}
		builder.Append(_assemblyName);
	}

	private static string GetFormattingString(string format)
	{
		if (string.Equals(format, "Long", StringComparison.OrdinalIgnoreCase))
		{
			return "{0:0000}:{1}";
		}
		if (string.Equals(format, "Short", StringComparison.OrdinalIgnoreCase))
		{
			return "{0:00}";
		}
		if (string.Equals(format, "Friendly", StringComparison.OrdinalIgnoreCase))
		{
			return "{1}";
		}
		return format;
	}
}
