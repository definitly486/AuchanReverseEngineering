using Auchan.Common.Common;

namespace Auchan.Common.Tooltips;

public class Tooltip
{
	public int Priority { get; }

	public int ShowCount { get; }

	public TooltipTargetType Target { get; }

	public string Title { get; }

	public TooltipTitleIconType TitleIcon { get; }

	public string Description { get; }

	public AudienceType Audience { get; }

	public Tooltip(int priority, int showCount, TooltipTargetType target, string title, TooltipTitleIconType titleIcon, string description, AudienceType audience)
	{
		Priority = priority;
		ShowCount = showCount;
		Target = target;
		Title = title;
		TitleIcon = titleIcon;
		Description = description;
		Audience = audience;
	}
}
