using System.ComponentModel;

namespace System.Timers;

[AttributeUsage(AttributeTargets.All)]
public class TimersDescriptionAttribute : DescriptionAttribute
{
	private bool _replaced;

	public override string Description
	{
		get
		{
			if (!_replaced)
			{
				_replaced = true;
				base.DescriptionValue = string.Format(base.Description, default(ReadOnlySpan<object>));
			}
			return base.Description;
		}
	}

	internal TimersDescriptionAttribute(TimersDescriptionStringId id)
		: base(GetResourceString(id))
	{
	}

	private static string GetResourceString(TimersDescriptionStringId id)
	{
		return id switch
		{
			TimersDescriptionStringId.TimerAutoReset => "TimerAutoReset", 
			TimersDescriptionStringId.TimerEnabled => "TimerEnabled", 
			TimersDescriptionStringId.TimerInterval => "TimerInterval", 
			TimersDescriptionStringId.TimerIntervalElapsed => "TimerIntervalElapsed", 
			TimersDescriptionStringId.TimerSynchronizingObject => "TimerSynchronizingObject", 
			_ => "", 
		};
	}
}
