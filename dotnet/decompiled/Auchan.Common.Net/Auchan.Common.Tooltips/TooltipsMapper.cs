namespace Auchan.Common.Tooltips;

public static class TooltipsMapper
{
	public static Tooltip ToModel(this TooltipDto tooltipDto)
	{
		return new Tooltip(tooltipDto.Priority, tooltipDto.ShowCount, tooltipDto.Target, tooltipDto.Title, tooltipDto.TitleIcon, tooltipDto.Description, tooltipDto.Audience);
	}
}
