namespace Auchan.Common.Controls.Accordion;

public static class AccordionElementStateExtensions
{
	public static AccordionElementState SetState(this AccordionElementState currentState, bool isEnabled)
	{
		if (!isEnabled)
		{
			return AccordionElementState.Gone;
		}
		if (!currentState.IsEnabled())
		{
			return AccordionElementState.Inactive;
		}
		return currentState;
	}

	public static bool IsEnabled(this AccordionElementState currentState)
	{
		if ((uint)currentState <= 1u)
		{
			return true;
		}
		return false;
	}
}
