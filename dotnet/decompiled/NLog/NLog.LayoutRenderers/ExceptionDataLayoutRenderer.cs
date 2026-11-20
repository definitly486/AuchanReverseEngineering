using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers;

[LayoutRenderer("exceptiondata")]
[LayoutRenderer("exception-data")]
[ThreadAgnostic]
[ThreadAgnosticImmutable]
public class ExceptionDataLayoutRenderer : LayoutRenderer
{
	[DefaultParameter]
	public string Item { get; set; } = string.Empty;

	public bool BaseException { get; set; }

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (string.IsNullOrEmpty(Item))
		{
			throw new NLogConfigurationException("ExceptionData-LayoutRenderer Item-property must be assigned. Lookup blank value not supported.");
		}
	}

	private Exception? GetTopException(LogEventInfo logEvent)
	{
		if (!BaseException)
		{
			return logEvent.Exception;
		}
		return logEvent.Exception?.GetBaseException();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		Exception topException = GetTopException(logEvent);
		if (topException != null)
		{
			object obj = topException.Data[Item];
			if (obj != null)
			{
				AppendFormattedValue(builder, logEvent, obj, Format, Culture);
			}
		}
	}
}
