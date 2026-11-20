using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NLog.Common;
using NLog.Internal;

namespace NLog.Config;

internal static class LoggingConfigurationElementExtensions
{
	public static bool MatchesName(this ILoggingConfigurationElement section, string expectedName)
	{
		return string.Equals(section?.Name?.Trim(), expectedName, StringComparison.OrdinalIgnoreCase);
	}

	public static void AssertName(this ILoggingConfigurationElement section, params string[] allowedNames)
	{
		foreach (string expectedName in allowedNames)
		{
			if (section.MatchesName(expectedName))
			{
				return;
			}
		}
		throw new InvalidOperationException("Assertion failed. Expected element name '" + string.Join("|", allowedNames) + "', actual: '" + section?.Name + "'.");
	}

	public static string GetRequiredValue(this ILoggingConfigurationElement element, string attributeName, string section)
	{
		string optionalValue = element.GetOptionalValue(attributeName, null);
		if (optionalValue == null)
		{
			throw new NLogConfigurationException("Expected " + attributeName + " on " + element.Name + " in " + section);
		}
		if (StringHelpers.IsNullOrWhiteSpace(optionalValue))
		{
			throw new NLogConfigurationException("Expected non-empty " + attributeName + " on " + element.Name + " in " + section);
		}
		return optionalValue;
	}

	public static string? GetOptionalValue(this ILoggingConfigurationElement element, string attributeName, string? defaultValue)
	{
		return (from configItem in element.Values
			where string.Equals(configItem.Key, attributeName, StringComparison.OrdinalIgnoreCase)
			select configItem.Value).FirstOrDefault() ?? defaultValue;
	}

	public static bool GetOptionalBooleanValue(this ILoggingConfigurationElement element, string attributeName, bool defaultValue)
	{
		string text = element.GetOptionalValue(attributeName, null)?.Trim() ?? string.Empty;
		if (string.IsNullOrEmpty(text))
		{
			return defaultValue;
		}
		try
		{
			return Convert.ToBoolean(text, CultureInfo.InvariantCulture);
		}
		catch (Exception ex)
		{
			NLogConfigurationException ex2 = new NLogConfigurationException($"'{attributeName}' hasn't a valid boolean value '{text}'. {defaultValue} will be used", ex);
			if (ex2.MustBeRethrown())
			{
				throw ex2;
			}
			InternalLogger.Error(ex, ex2.Message);
			return defaultValue;
		}
	}

	public static string GetConfigItemTypeAttribute(this ILoggingConfigurationElement element, string? sectionNameForRequiredValue = null)
	{
		return StripOptionalNamespacePrefix(((sectionNameForRequiredValue != null) ? element.GetRequiredValue("type", sectionNameForRequiredValue) : element.GetOptionalValue("type", null)) ?? string.Empty).Trim();
	}

	public static IEnumerable<ILoggingConfigurationElement> FilterChildren(this ILoggingConfigurationElement element, string elementName)
	{
		if (elementName == null || element?.Children == null)
		{
			yield break;
		}
		foreach (ILoggingConfigurationElement child in element.Children)
		{
			if (child.Name.Equals(elementName, StringComparison.OrdinalIgnoreCase))
			{
				yield return child;
			}
		}
	}

	private static string StripOptionalNamespacePrefix(string attributeValue)
	{
		if (attributeValue == null)
		{
			return string.Empty;
		}
		int num = attributeValue.IndexOf(':');
		if (num < 0)
		{
			return attributeValue;
		}
		return attributeValue.Substring(num + 1);
	}
}
