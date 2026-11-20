using System;
using Auchan.Common.Base.Errors.Domain;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.GiftCards.Infrastructure;

public class GiftCardDataDTO : DomainError
{
	[JsonProperty("amount")]
	public decimal Amount { get; set; }

	[JsonProperty("validityDate")]
	public DateTime ExpiryDate { get; set; }

	[JsonProperty("errorText")]
	public string ErrorText { get; set; } = string.Empty;

	[JsonProperty("errorCode")]
	public int ErrorCode { get; set; }
}
