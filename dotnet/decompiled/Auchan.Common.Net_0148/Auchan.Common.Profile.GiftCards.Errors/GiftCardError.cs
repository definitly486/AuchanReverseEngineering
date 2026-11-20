using System.Net;
using Auchan.Common.Base.Errors.Domain;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.GiftCards.Errors;

public class GiftCardError : DomainError
{
	[JsonProperty("errorCode")]
	public int ErrorCode { get; set; } = -1;

	[JsonProperty("errorText")]
	public string ErrorText { get; set; } = "";

	[JsonIgnore]
	public HttpStatusCode StatusCode { get; set; }
}
