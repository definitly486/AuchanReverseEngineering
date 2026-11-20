using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed class UploadFileResponseDTO
{
	[JsonProperty("result")]
	public UploadFileResultDTO? Result { get; set; }

	[JsonProperty("status")]
	public string? Status { get; set; }

	[JsonProperty("error")]
	public string? Error { get; set; }

	[JsonProperty("isValidationError")]
	public bool IsValidationError { get; set; }
}
