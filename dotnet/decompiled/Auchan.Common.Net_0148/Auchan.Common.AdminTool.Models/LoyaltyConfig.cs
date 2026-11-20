namespace Auchan.Common.AdminTool.Models;

public class LoyaltyConfig
{
	public bool EPointsBalanceEnabled { get; set; }

	public bool EPointsBalanceOperationsHistoryEnabled { get; set; }

	public string SocialStatusConfirmedText { get; set; } = string.Empty;

	public string SocialStatusUnconfirmedText { get; set; } = string.Empty;

	public bool IsPointsTransferToAuchanFundEnabled { get; set; }

	public bool IsPointsTransferToUserEnabled { get; set; }

	public string PointsTransferDisabledMessage { get; set; } = string.Empty;

	public string PointsTransferToAuchanFundDisabledMessage { get; set; } = string.Empty;

	public string PointsTransferToUsersDisabledMessage { get; set; } = string.Empty;

	public string ConnectionErrorText { get; set; } = string.Empty;

	public string ConnectionErrorImage { get; set; } = string.Empty;
}
