using System;
using System.Collections.ObjectModel;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("message")]
[ThreadAgnostic]
public class MessageLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	public bool WithException { get; set; }

	public string ExceptionSeparator { get; set; }

	public bool Raw { get; set; }

	public MessageLayoutRenderer()
	{
		ExceptionSeparator = "|";
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		int num;
		if (logEvent.Exception != null && WithException)
		{
			object?[]? parameters = logEvent.Parameters;
			if (parameters != null && parameters.Length == 1 && logEvent.Parameters[0] == logEvent.Exception)
			{
				num = ((logEvent.Message == "{0}") ? 1 : 0);
				goto IL_0047;
			}
		}
		num = 0;
		goto IL_0047;
		IL_0047:
		bool flag = (byte)num != 0;
		if (Raw)
		{
			builder.Append(logEvent.Message);
		}
		else if (!flag)
		{
			if (logEvent.MessageFormatter?.Target is ILogMessageFormatter messageFormatter)
			{
				logEvent.AppendFormattedMessage(messageFormatter, builder);
			}
			else
			{
				builder.Append(logEvent.FormattedMessage);
			}
		}
		if (WithException && logEvent.Exception != null)
		{
			Exception primaryException = GetPrimaryException(logEvent.Exception);
			if (!flag)
			{
				builder.Append(ExceptionSeparator);
			}
			builder.Append(primaryException.ToString());
		}
	}

	private static Exception GetPrimaryException(Exception exception)
	{
		if (exception is AggregateException ex)
		{
			ReadOnlyCollection<Exception> innerExceptions = ex.InnerExceptions;
			if (innerExceptions != null && innerExceptions.Count == 1)
			{
				Exception ex2 = ex.InnerExceptions[0];
				if (!(ex2 is AggregateException))
				{
					return ex2;
				}
			}
			AggregateException ex3 = ex.Flatten();
			ReadOnlyCollection<Exception> innerExceptions2 = ex3.InnerExceptions;
			if (innerExceptions2 != null && innerExceptions2.Count == 1)
			{
				return ex3.InnerExceptions[0];
			}
			return ex3;
		}
		return exception;
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		if (WithException)
		{
			return null;
		}
		return (Raw ? logEvent.Message : logEvent.FormattedMessage) ?? string.Empty;
	}
}
