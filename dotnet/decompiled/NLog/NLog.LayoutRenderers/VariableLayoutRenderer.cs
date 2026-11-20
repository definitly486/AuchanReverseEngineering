using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers;

[LayoutRenderer("var")]
public class VariableLayoutRenderer : LayoutRenderer
{
	[DefaultParameter]
	public string Name { get; set; } = string.Empty;

	public string Default { get; set; } = string.Empty;

	public Layout? ActiveLayout
	{
		get
		{
			if (!TryGetLayout(out Layout layout))
			{
				return null;
			}
			return layout;
		}
	}

	protected override void InitializeLayoutRenderer()
	{
		if (string.IsNullOrEmpty(Name))
		{
			throw new NLogConfigurationException("Var-LayoutRenderer Name-property must be assigned. Lookup blank value not supported.");
		}
		if (TryGetLayout(out Layout layout))
		{
			layout?.Initialize(base.LoggingConfiguration);
		}
		base.InitializeLayoutRenderer();
	}

	private bool TryGetLayout(out Layout? layout)
	{
		layout = null;
		if (Name != null)
		{
			return base.LoggingConfiguration?.TryLookupDynamicVariable(Name, out layout) ?? false;
		}
		return false;
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (Name != null)
		{
			if (TryGetLayout(out Layout layout))
			{
				layout?.Render(logEvent, builder);
			}
			else if (Default != null)
			{
				builder.Append(Default);
			}
		}
	}
}
