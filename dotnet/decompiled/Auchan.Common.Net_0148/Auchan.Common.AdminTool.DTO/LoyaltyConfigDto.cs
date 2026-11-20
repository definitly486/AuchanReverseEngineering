using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class LoyaltyConfigDto
{
	[JsonProperty("marks_balance_enabled")]
	public bool MarkBalanceEnabled { get; set; }

	[JsonProperty("marks_balance_operations_history_enabled")]
	public bool MarkBalanceOperationsHistoryEnabled { get; set; }

	[JsonProperty("express_balance_enabled")]
	public bool EPointsBalanceEnabled { get; set; }

	[JsonProperty("express_balance_operations_history_enabled")]
	public bool EPointsBalanceOperationsHistoryEnabled { get; set; }

	[JsonProperty("social_status_enabled_text")]
	public string SocialStatusConfirmedText { get; set; } = string.Empty;

	[JsonProperty("social_status_not_enabled_text")]
	public string SocialStatusUnconfirmedText { get; set; } = string.Empty;

	[JsonProperty("auchan_fund_transactions_enabled")]
	public bool IsPointsTransferToAuchanFundEnabled { get; set; }

	[JsonProperty("new_loyalty_users_transactions_enabled")]
	public bool IsPointsTransferToUserEnabled { get; set; }

	[JsonProperty("none_transactions_enabled_text")]
	public string PointsTransferDisabledMessage { get; set; } = string.Empty;

	[JsonProperty("users_transactions_enabled_text")]
	public string PointsTransferToAuchanFundDisabledMessage { get; set; } = string.Empty;

	[JsonProperty("auchan_fund_transactions_enabled_text")]
	public string PointsTransferToUsersDisabledMessage { get; set; } = string.Empty;

	[JsonProperty("connection_error_text")]
	public string ConnectionErrorText { get; set; } = string.Empty;

	[JsonProperty("connection_error_icon_url")]
	public string ConnectionErrorImage { get; set; } = string.Empty;
}
