using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;
using NLog.MessageTemplates;

namespace NLog.LayoutRenderers;

[LayoutRenderer("all-event-properties")]
[ThreadAgnostic]
[ThreadAgnosticImmutable]
public class AllEventPropertiesLayoutRenderer : LayoutRenderer
{
	private string _format;

	private string? _beforeKey;

	private string? _afterKey;

	private string? _afterValue;

	private string _separator = ", ";

	private string _separatorOriginal = ", ";

	private static readonly LayoutRenderer _disableThreadAgnostic = new FuncLayoutRenderer(string.Empty, (LogEventInfo evt, LoggingConfiguration? cfg) => string.Empty);

	public string Separator
	{
		get
		{
			return _separatorOriginal ?? _separator;
		}
		set
		{
			_separatorOriginal = value;
			_separator = SimpleLayout.Evaluate(value, base.LoggingConfiguration, null, false);
		}
	}

	public bool IncludeEmptyValues { get; set; }

	public bool IncludeScopeProperties { get; set; }

	public ISet<string> Exclude { get; set; }

	public LayoutRenderer? DisableThreadAgnostic
	{
		get
		{
			if (!IncludeScopeProperties)
			{
				return null;
			}
			return _disableThreadAgnostic;
		}
	}

	public string Format
	{
		get
		{
			return _format;
		}
		set
		{
			if (string.IsNullOrEmpty(value) || value.IndexOf("[key]", StringComparison.Ordinal) < 0)
			{
				throw new ArgumentException("Invalid format: [key] placeholder is missing.");
			}
			if (value.IndexOf("[value]", StringComparison.Ordinal) < 0)
			{
				throw new ArgumentException("Invalid format: [value] placeholder is missing.");
			}
			_format = value;
			string[] array = _format.Split(new string[2] { "[key]", "[value]" }, StringSplitOptions.None);
			if (array.Length == 3)
			{
				_beforeKey = array[0];
				_afterKey = array[1];
				_afterValue = array[2];
			}
			else
			{
				_beforeKey = null;
				_afterKey = null;
				_afterValue = null;
			}
		}
	}

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	public AllEventPropertiesLayoutRenderer()
	{
		_format = (Format = "[key]=[value]");
		Exclude = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
	}

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (_separatorOriginal != null)
		{
			_separator = SimpleLayout.Evaluate(_separatorOriginal, base.LoggingConfiguration);
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!logEvent.HasProperties && !IncludeScopeProperties)
		{
			return;
		}
		IFormatProvider formatProvider = GetFormatProvider(logEvent, Culture);
		ISet<string> exclude = Exclude;
		bool checkForExclude = exclude != null && exclude.Count > 0;
		bool nonStandardFormat = _beforeKey == null || _afterKey == null || _afterValue == null;
		bool includeSeparator = false;
		if (logEvent.HasProperties)
		{
			using PropertiesDictionary.PropertyDictionaryEnumerator propertyDictionaryEnumerator = logEvent.CreatePropertiesInternal().GetPropertyEnumerator();
			while (propertyDictionaryEnumerator.MoveNext())
			{
				MessageTemplateParameter currentParameter = propertyDictionaryEnumerator.CurrentParameter;
				if (AppendProperty(builder, currentParameter.Name, currentParameter.Value, currentParameter.Format, formatProvider, includeSeparator, checkForExclude, nonStandardFormat))
				{
					includeSeparator = true;
				}
			}
		}
		if (!IncludeScopeProperties)
		{
			return;
		}
		using ScopeContextPropertyEnumerator<object> scopeContextPropertyEnumerator = ScopeContext.GetAllPropertiesEnumerator();
		while (scopeContextPropertyEnumerator.MoveNext())
		{
			KeyValuePair<string, object> current = scopeContextPropertyEnumerator.Current;
			if (AppendProperty(builder, current.Key, current.Value, null, formatProvider, includeSeparator, checkForExclude, nonStandardFormat))
			{
				includeSeparator = true;
			}
		}
	}

	private bool AppendProperty(StringBuilder builder, object propertyKey, object? propertyValue, string? propertyFormat, IFormatProvider? formatProvider, bool includeSeparator, bool checkForExclude, bool nonStandardFormat)
	{
		if (!IncludeEmptyValues && StringHelpers.IsNullOrEmptyString(propertyValue))
		{
			return false;
		}
		if (checkForExclude && Exclude.Contains((propertyKey as string) ?? string.Empty))
		{
			return false;
		}
		if (includeSeparator)
		{
			builder.Append(_separator);
		}
		if (nonStandardFormat)
		{
			string newValue = Convert.ToString(propertyKey, formatProvider);
			string newValue2 = Convert.ToString(propertyValue, formatProvider);
			string value = Format.Replace("[key]", newValue).Replace("[value]", newValue2);
			builder.Append(value);
		}
		else
		{
			builder.Append(_beforeKey);
			builder.AppendFormattedValue(propertyKey, null, formatProvider, base.ValueFormatter);
			builder.Append(_afterKey);
			builder.AppendFormattedValue(propertyValue, propertyFormat, formatProvider, base.ValueFormatter);
			builder.Append(_afterValue);
		}
		return true;
	}
}
