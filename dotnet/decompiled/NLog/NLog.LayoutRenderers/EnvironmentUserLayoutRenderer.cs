using System;
using System.Text;
using NLog.Common;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("environment-user")]
public class EnvironmentUserLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	public bool UserName { get; set; } = true;

	public bool Domain { get; set; }

	public string DefaultUser { get; set; } = "UserUnknown";

	public string DefaultDomain { get; set; } = "DomainUnknown";

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(GetStringValue());
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetStringValue();
	}

	private string GetStringValue()
	{
		if (UserName)
		{
			if (!Domain)
			{
				return GetUserName();
			}
			return GetDomainName() + "\\" + GetUserName();
		}
		if (!Domain)
		{
			return string.Empty;
		}
		return GetDomainName();
	}

	private string GetUserName()
	{
		return GetValueSafe(() => Environment.UserName, DefaultUser);
	}

	private string GetDomainName()
	{
		return GetValueSafe(() => Environment.UserDomainName, DefaultDomain);
	}

	private static string GetValueSafe(Func<string> getValue, string defaultValue)
	{
		try
		{
			string text = getValue();
			return string.IsNullOrEmpty(text) ? (defaultValue ?? string.Empty) : text;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "Failed to lookup Environment-User. Fallback value={0}", new ReadOnlySpan<object>(new object[1] { defaultValue }));
			return defaultValue ?? string.Empty;
		}
	}
}
