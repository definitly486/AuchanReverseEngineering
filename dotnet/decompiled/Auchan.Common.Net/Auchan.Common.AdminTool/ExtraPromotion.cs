using System;
using Auchan.Common.AdminTool.Enums;

namespace Auchan.Common.AdminTool;

public class ExtraPromotion
{
	public int Id { get; set; }

	public string Name { get; set; } = string.Empty;

	public ExtraPromotionLocation Location { get; set; }

	public ExtraPromotionTransition Transition { get; set; }

	public string Picture { get; set; } = string.Empty;

	public DateTime BeginsOn { get; set; }

	public DateTime EndsOn { get; set; }

	public int? LocationId { get; set; }

	public string? TransitionCode { get; set; }

	public int? RegionId { get; set; }
}
