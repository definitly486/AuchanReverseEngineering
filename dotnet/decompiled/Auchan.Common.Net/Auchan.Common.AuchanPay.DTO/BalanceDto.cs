using Newtonsoft.Json;

namespace Auchan.Common.AuchanPay.DTO;

public class BalanceDto
{
	[JsonProperty("txnRspCode")]
	public string? TxnRspCode { get; set; }

	[JsonProperty("avlBalCurrency")]
	public string? AvlBalCurrency { get; set; }

	[JsonProperty("avlBalAmount")]
	public string? AvlBalAmount { get; set; }

	[JsonProperty("panDisplay")]
	public string? PanDisplay { get; set; }

	[JsonProperty("code")]
	public string? Code { get; set; }
}
