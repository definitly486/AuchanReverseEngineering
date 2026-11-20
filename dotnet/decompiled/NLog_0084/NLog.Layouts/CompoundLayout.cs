using System.Collections.Generic;
using System.Text;
using NLog.Config;

namespace NLog.Layouts;

[Layout("CompoundLayout")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public class CompoundLayout : Layout
{
	private Layout[]? _precalculateLayouts;

	[ArrayParameter(typeof(Layout), "layout")]
	public IList<Layout> Layouts { get; private set; }

	public CompoundLayout()
	{
		Layouts = new List<Layout>();
	}

	protected override void InitializeLayout()
	{
		foreach (Layout layout in Layouts)
		{
			layout.Initialize(base.LoggingConfiguration);
		}
		base.InitializeLayout();
		_precalculateLayouts = ResolveLayoutPrecalculation(Layouts);
	}

	internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		PrecalculateBuilderInternal(logEvent, target, _precalculateLayouts);
	}

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		return RenderAllocateBuilder(logEvent);
	}

	protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		for (int i = 0; i < Layouts.Count; i++)
		{
			Layouts[i].Render(logEvent, target);
		}
	}

	protected override void CloseLayout()
	{
		_precalculateLayouts = null;
		foreach (Layout layout in Layouts)
		{
			layout.Close();
		}
		base.CloseLayout();
	}

	public override string ToString()
	{
		return ToStringWithNestedItems(Layouts, (Layout l) => l.ToString());
	}
}
