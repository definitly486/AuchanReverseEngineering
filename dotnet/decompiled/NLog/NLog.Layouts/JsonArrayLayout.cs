using System.Collections.Generic;
using System.Text;
using NLog.Config;
using NLog.Targets;

namespace NLog.Layouts;

[Layout("JsonArrayLayout")]
[ThreadAgnostic]
public class JsonArrayLayout : Layout
{
	private Layout[]? _precalculateLayouts;

	private IJsonConverter? _jsonConverter;

	private IJsonConverter JsonConverter => _jsonConverter ?? (_jsonConverter = ResolveService<IJsonConverter>());

	[ArrayParameter(typeof(Layout), "item")]
	public IList<Layout> Items { get; } = new List<Layout>();

	public bool SuppressSpaces { get; set; } = true;

	public bool RenderEmptyObject { get; set; } = true;

	protected override void InitializeLayout()
	{
		base.InitializeLayout();
		_precalculateLayouts = ResolveLayoutPrecalculation(Items);
	}

	protected override void CloseLayout()
	{
		_jsonConverter = null;
		_precalculateLayouts = null;
		base.CloseLayout();
	}

	internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		PrecalculateBuilderInternal(logEvent, target, _precalculateLayouts);
	}

	protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		int length = target.Length;
		RenderJsonFormattedMessage(logEvent, target);
		if (target.Length == length && RenderEmptyObject)
		{
			target.Append(SuppressSpaces ? "[]" : "[ ]");
		}
	}

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		return RenderAllocateBuilder(logEvent);
	}

	private void RenderJsonFormattedMessage(LogEventInfo logEvent, StringBuilder sb)
	{
		int length = sb.Length;
		for (int i = 0; i < Items.Count; i++)
		{
			Layout layout = Items[i];
			int length2 = sb.Length;
			if (length2 == length)
			{
				sb.Append(SuppressSpaces ? "[" : "[ ");
			}
			else
			{
				sb.Append(SuppressSpaces ? "," : ", ");
			}
			if (!RenderLayoutJsonValue(logEvent, layout, sb))
			{
				sb.Length = length2;
			}
		}
		if (sb.Length != length)
		{
			sb.Append(SuppressSpaces ? "]" : " ]");
		}
	}

	private bool RenderLayoutJsonValue(LogEventInfo logEvent, Layout layout, StringBuilder sb)
	{
		int length = sb.Length;
		object rawValue;
		if (layout is JsonLayout)
		{
			layout.Render(logEvent, sb);
		}
		else if (layout.TryGetRawValue(logEvent, out rawValue))
		{
			if (!JsonConverter.SerializeObject(rawValue, sb))
			{
				return false;
			}
		}
		else
		{
			sb.Append('"');
			length = sb.Length;
			layout.Render(logEvent, sb);
			if (length != sb.Length)
			{
				DefaultJsonSerializer.PerformJsonEscapeWhenNeeded(sb, length, escapeUnicode: true);
				sb.Append('"');
			}
		}
		return length != sb.Length;
	}

	public override string ToString()
	{
		return ToStringWithNestedItems(Items, (Layout l) => l.ToString());
	}
}
