using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos.Triggers;

public class StepTwoDto
{
	[JsonProperty("enabled")]
	public bool IsEnabled { get; set; }

	[JsonProperty("positive_balance_texts")]
	public List<string>? PositiveBalanceText { get; set; }

	[JsonProperty("zero_balance_texts")]
	public List<string>? ZeroBalanceText { get; set; }

	[JsonProperty("on_start_trigger_texts")]
	public List<string>? OnStartTriggerText { get; set; }

	[JsonProperty("auchan_pay_refill_text")]
	public string? APayRefillText { get; set; }

	[JsonProperty("personal_data_warning_text")]
	public string? PersonalDataWarningText { get; set; }

	[JsonProperty("registration_successful_text")]
	public string? RegistrationSuccessfulText { get; set; }

	[JsonProperty("auchan_pay_info_message")]
	public string? AuchanPayInfoMessage { get; set; }
}
