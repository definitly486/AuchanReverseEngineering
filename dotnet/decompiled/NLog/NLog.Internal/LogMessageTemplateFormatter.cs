using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.MessageTemplates;

namespace NLog.Internal;

internal sealed class LogMessageTemplateFormatter : ILogMessageFormatter
{
	private static readonly StringBuilderPool _builderPool = new StringBuilderPool(Environment.ProcessorCount * 2);

	private readonly LogFactory _logFactory;

	private IValueFormatter? _valueFormatter;

	private readonly bool _forceMessageTemplateRenderer;

	private readonly bool _singleTargetOnly;

	private IValueFormatter ValueFormatter => _valueFormatter ?? (_valueFormatter = _logFactory.ServiceRepository.GetService<IValueFormatter>());

	public LogMessageFormatter MessageFormatter { get; }

	public bool? EnableMessageTemplateParser
	{
		get
		{
			if (!_forceMessageTemplateRenderer)
			{
				return null;
			}
			return true;
		}
	}

	public LogMessageTemplateFormatter(LogFactory logFactory, bool forceMessageTemplateRenderer, bool singleTargetOnly)
	{
		_logFactory = logFactory;
		_forceMessageTemplateRenderer = forceMessageTemplateRenderer;
		_singleTargetOnly = singleTargetOnly;
		MessageFormatter = FormatMessage;
	}

	public bool HasProperties(LogEventInfo logEvent)
	{
		if (!LogMessageStringFormatter.HasParameters(logEvent))
		{
			return false;
		}
		if (_singleTargetOnly)
		{
			TemplateEnumerator templateEnumerator = new TemplateEnumerator(logEvent.Message);
			if (!templateEnumerator.MoveNext() || templateEnumerator.Current.MaybePositionalTemplate)
			{
				return false;
			}
		}
		return true;
	}

	public void AppendFormattedMessage(LogEventInfo logEvent, StringBuilder builder)
	{
		if (_singleTargetOnly)
		{
			object?[]? parameters = logEvent.Parameters;
			if (parameters != null && parameters.Length != 0)
			{
				Render(logEvent.Message, logEvent.FormatProvider ?? _logFactory.DefaultCultureInfo ?? CultureInfo.CurrentCulture, logEvent.Parameters, builder, out IList<MessageTemplateParameter> _);
				return;
			}
		}
		builder.Append(logEvent.FormattedMessage);
	}

	public string FormatMessage(LogEventInfo logEvent)
	{
		object[] parameters = logEvent.Parameters;
		if (parameters != null && parameters.Length != 0 && !string.IsNullOrEmpty(logEvent.Message))
		{
			StringBuilderPool.ItemHolder itemHolder = _builderPool.Acquire();
			try
			{
				AppendToBuilder(logEvent, parameters, itemHolder.Item);
				return itemHolder.Item.ToString();
			}
			finally
			{
				((IDisposable)itemHolder/*cast due to .constrained prefix*/).Dispose();
			}
		}
		return logEvent.Message;
	}

	private void AppendToBuilder(LogEventInfo logEvent, object?[] parameters, StringBuilder builder)
	{
		Render(logEvent.Message, logEvent.FormatProvider ?? _logFactory.DefaultCultureInfo ?? CultureInfo.CurrentCulture, parameters, builder, out IList<MessageTemplateParameter> messageTemplateParameters);
		logEvent.TryCreatePropertiesInternal(messageTemplateParameters ?? ArrayHelper.Empty<MessageTemplateParameter>());
	}

	private void Render(string template, IFormatProvider? formatProvider, object?[] parameters, StringBuilder sb, out IList<MessageTemplateParameter>? messageTemplateParameters)
	{
		messageTemplateParameters = null;
		TemplateEnumerator templateEnumerator = new TemplateEnumerator(template);
		if (!templateEnumerator.MoveNext() || (templateEnumerator.Current.MaybePositionalTemplate && !_forceMessageTemplateRenderer))
		{
			sb.AppendFormat(formatProvider, template, parameters);
			return;
		}
		int num = 0;
		int num2 = 0;
		int holeStartPosition = 0;
		int length = sb.Length;
		do
		{
			Literal literal = templateEnumerator.Current.Literal;
			sb.Append(template, num, literal.Print);
			num += literal.Print;
			if (literal.Skip == 0)
			{
				num++;
				continue;
			}
			num += literal.Skip;
			Hole hole = templateEnumerator.Current.Hole;
			if (hole.Alignment != 0)
			{
				holeStartPosition = sb.Length;
			}
			if (hole.Index != -1 && messageTemplateParameters == null)
			{
				num2++;
				RenderHolePositional(sb, in hole, formatProvider, parameters[hole.Index]);
			}
			else
			{
				object value = parameters[num2];
				if (messageTemplateParameters == null)
				{
					messageTemplateParameters = new MessageTemplateParameter[parameters.Length];
					if (num2 != 0)
					{
						templateEnumerator = new TemplateEnumerator(template);
						sb.Length = length;
						num2 = 0;
						num = 0;
						continue;
					}
				}
				messageTemplateParameters[num2++] = new MessageTemplateParameter(hole.Name, value, hole.Format, hole.CaptureType);
				RenderHole(sb, in hole, formatProvider, value);
			}
			if (hole.Alignment != 0)
			{
				RenderPadding(sb, hole.Alignment, holeStartPosition);
			}
		}
		while (templateEnumerator.MoveNext());
		messageTemplateParameters = VerifyMessageTemplateParameters(messageTemplateParameters, num2);
	}

	internal string Render(ref TemplateEnumerator templateEnumerator, IFormatProvider? formatProvider, in ReadOnlySpan<object?> parameters, out IList<MessageTemplateParameter>? messageTemplateParameters)
	{
		messageTemplateParameters = null;
		StringBuilderPool.ItemHolder itemHolder = _builderPool.Acquire();
		try
		{
			StringBuilder item = itemHolder.Item;
			string template = templateEnumerator.Template;
			int num = 0;
			int holeStartPosition = 0;
			int num2 = 0;
			do
			{
				Literal literal = templateEnumerator.Current.Literal;
				item.Append(template, num, literal.Print);
				num += literal.Print;
				if (literal.Skip == 0)
				{
					num++;
					continue;
				}
				num += literal.Skip;
				Hole hole = templateEnumerator.Current.Hole;
				if (hole.Alignment != 0)
				{
					holeStartPosition = item.Length;
				}
				if (hole.Index != -1 && messageTemplateParameters == null)
				{
					num2++;
					RenderHolePositional(item, in hole, formatProvider, parameters[hole.Index]);
				}
				else
				{
					object value = parameters[num2];
					if (messageTemplateParameters == null)
					{
						messageTemplateParameters = new MessageTemplateParameter[parameters.Length];
						if (num2 != 0)
						{
							templateEnumerator = new TemplateEnumerator(template);
							item.ClearBuilder();
							num2 = 0;
							num = 0;
							continue;
						}
					}
					messageTemplateParameters[num2++] = new MessageTemplateParameter(hole.Name, value, hole.Format, hole.CaptureType);
					RenderHole(item, in hole, formatProvider, value);
				}
				if (hole.Alignment != 0)
				{
					RenderPadding(item, hole.Alignment, holeStartPosition);
				}
			}
			while (templateEnumerator.MoveNext());
			messageTemplateParameters = VerifyMessageTemplateParameters(messageTemplateParameters, num2);
			return item.ToString();
		}
		finally
		{
			((IDisposable)itemHolder/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private static IList<MessageTemplateParameter>? VerifyMessageTemplateParameters(IList<MessageTemplateParameter>? messageTemplateParameters, int holeIndex)
	{
		if (messageTemplateParameters != null && holeIndex != messageTemplateParameters.Count)
		{
			MessageTemplateParameter[] array = new MessageTemplateParameter[holeIndex];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = messageTemplateParameters[i];
			}
			messageTemplateParameters = array;
		}
		return messageTemplateParameters;
	}

	private void RenderHolePositional(StringBuilder sb, in Hole hole, IFormatProvider? formatProvider, object? value)
	{
		if (value == null)
		{
			sb.Append("NULL");
		}
		else if (hole.CaptureType == CaptureType.Normal)
		{
			NLog.MessageTemplates.ValueFormatter.FormatToString(value, hole.Format, formatProvider, sb);
		}
		else
		{
			RenderHole(sb, hole.CaptureType, hole.Format, formatProvider, value);
		}
	}

	private void RenderHole(StringBuilder sb, in Hole hole, IFormatProvider? formatProvider, object? value)
	{
		RenderHole(sb, hole.CaptureType, hole.Format, formatProvider, value);
	}

	private void RenderHole(StringBuilder sb, CaptureType captureType, string? holeFormat, IFormatProvider? formatProvider, object? value)
	{
		if (value == null)
		{
			sb.Append("NULL");
		}
		else
		{
			ValueFormatter.FormatValue(value, holeFormat, captureType, formatProvider, sb);
		}
	}

	private static void RenderPadding(StringBuilder sb, int holeAlignment, int holeStartPosition)
	{
		int num = sb.Length - holeStartPosition;
		int num2 = Math.Abs(holeAlignment) - num;
		if (num2 > 0)
		{
			if (holeAlignment < 0 || num == 0)
			{
				sb.Append(' ', num2);
				return;
			}
			string value = sb.ToString(holeStartPosition, num);
			sb.Length = holeStartPosition;
			sb.Append(' ', num2);
			sb.Append(value);
		}
	}
}
