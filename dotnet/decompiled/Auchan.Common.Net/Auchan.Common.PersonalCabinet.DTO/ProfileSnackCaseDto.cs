using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public class ProfileSnackCaseDto
{
	[JsonProperty("given_name")]
	public string? GivenName { get; set; }

	[JsonProperty("sn")]
	public string? Sn { get; set; }

	[JsonProperty("patronymic")]
	public string? Patronymic { get; set; }

	[JsonProperty("mail")]
	public string? Mail { get; set; }

	[JsonProperty("mail_confirmation")]
	public bool MailConfirmation { get; set; }

	[JsonProperty("additional_mail")]
	public string? AdditionalMail { get; set; }

	[JsonProperty("telnum_for_reg")]
	public string? TelNumForReg { get; set; }

	[JsonProperty("sex")]
	public string? Sex { get; set; }

	[JsonProperty("birthday")]
	public string? Birthday { get; set; }

	[JsonProperty("region")]
	public string? Region { get; set; }

	[JsonProperty("city")]
	public string? City { get; set; }

	[JsonProperty("src_reg")]
	public string? SourceRegistration { get; set; }

	[JsonProperty("subscribes")]
	public List<SubscriptionSnackCaseDto>? Subscribes { get; set; }

	[JsonProperty("stores")]
	public List<object>? Stores { get; set; }

	[JsonProperty("addresses")]
	public List<object>? Addresses { get; set; }

	[JsonProperty("phone_confirmation")]
	public bool PhoneConfirmation { get; set; }

	[JsonProperty("user_status")]
	public string? UserStatus { get; set; }

	[JsonProperty("confirm_phone_dt")]
	public string? ConfirmPhoneDt { get; set; }

	[JsonProperty("client_account_id")]
	public string? ClientAccountId { get; set; }

	[JsonProperty("magento_client_account_id")]
	public string MagentoAccountId { get; set; } = string.Empty;

	[JsonProperty("privacy_policy_flag")]
	public string? PrivacyPolicyFlag { get; set; }

	[JsonProperty("loyalty_agr")]
	public int LoyaltyFlag { get; set; }

	[JsonProperty("loyalty_id")]
	public string? LoyaltyId { get; set; }

	[JsonProperty("loymax_loyalty_id")]
	public string? LoymaxLoyaltyId { get; set; }

	[JsonProperty("ereceipt_flag")]
	public bool? EreceiptFlag { get; set; }
}
