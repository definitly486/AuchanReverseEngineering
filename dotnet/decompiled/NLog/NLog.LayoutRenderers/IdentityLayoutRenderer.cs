using System.Security.Principal;
using System.Text;
using System.Threading;

namespace NLog.LayoutRenderers;

[LayoutRenderer("identity")]
public class IdentityLayoutRenderer : LayoutRenderer
{
	public string Separator { get; set; } = ":";

	public bool Name { get; set; } = true;

	public bool AuthType { get; set; } = true;

	public bool IsAuthenticated { get; set; } = true;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		IIdentity value = GetValue();
		if (value != null)
		{
			string value2 = string.Empty;
			if (IsAuthenticated)
			{
				builder.Append(value2);
				value2 = Separator;
				builder.Append(value.IsAuthenticated ? "auth" : "notauth");
			}
			if (AuthType)
			{
				builder.Append(value2);
				value2 = Separator;
				builder.Append(value.AuthenticationType);
			}
			if (Name)
			{
				builder.Append(value2);
				builder.Append(value.Name);
			}
		}
	}

	private static IIdentity? GetValue()
	{
		return Thread.CurrentPrincipal?.Identity;
	}
}
