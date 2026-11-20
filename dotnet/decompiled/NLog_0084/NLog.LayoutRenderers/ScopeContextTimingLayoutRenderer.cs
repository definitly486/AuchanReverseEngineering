using System;
using System.Globalization;
using System.Text;
using NLog.Internal;
using NLog.Time;

namespace NLog.LayoutRenderers;

[LayoutRenderer("scopetiming")]
[LayoutRenderer("ndlctiming")]
public sealed class ScopeContextTimingLayoutRenderer : LayoutRenderer
{
	public bool CurrentScope { get; set; }

	public bool StartTime { get; set; }

	[Obsolete("Replaced by StartTime. Marked obsolete on NLog 6.0")]
	public bool ScopeBeginTime
	{
		get
		{
			return StartTime;
		}
		set
		{
			StartTime = value;
		}
	}

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		TimeSpan? timeSpan = (CurrentScope ? ScopeContext.PeekInnerNestedDuration() : ScopeContext.PeekOuterNestedDuration());
		if (!timeSpan.HasValue)
		{
			return;
		}
		if (timeSpan.Value < TimeSpan.Zero)
		{
			timeSpan = TimeSpan.Zero;
		}
		if (StartTime)
		{
			builder.Append(TimeSource.Current.Time.Subtract(timeSpan.Value).ToString(Format, Culture));
		}
		else if (string.IsNullOrEmpty(Format))
		{
			double totalMilliseconds = timeSpan.Value.TotalMilliseconds;
			if (Culture == CultureInfo.InvariantCulture)
			{
				RenderAppendDurationMs(builder, totalMilliseconds);
			}
			else
			{
				builder.Append(totalMilliseconds.ToString("0.###", Culture));
			}
		}
		else
		{
			builder.Append(timeSpan.Value.ToString(Format, Culture));
		}
	}

	private static void RenderAppendDurationMs(StringBuilder builder, double scopeDurationMs)
	{
		long num = (long)scopeDurationMs;
		if (num >= 0 && num < uint.MaxValue)
		{
			builder.AppendInvariant((uint)num);
		}
		else
		{
			builder.Append(num);
		}
		int num2 = (int)((scopeDurationMs - (double)num) * 1000.0);
		if (num2 > 0)
		{
			builder.Append('.');
			if (num2 < 100)
			{
				builder.Append('0');
			}
			if (num2 < 10)
			{
				builder.Append('0');
			}
			builder.AppendInvariant(num2);
		}
		else
		{
			builder.Append(".0");
		}
	}
}
