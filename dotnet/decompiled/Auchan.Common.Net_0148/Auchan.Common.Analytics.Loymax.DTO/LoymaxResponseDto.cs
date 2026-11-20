using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Loymax.DTO;

public sealed class LoymaxResponseDto
{
	public sealed class ErrorDto
	{
		[JsonProperty("code")]
		public required string Code { get; init; }

		[JsonProperty("message")]
		public required string Message { get; init; }
	}

	[JsonProperty("errors")]
	public IReadOnlyList<ErrorDto> Errors { get; init; } = Array.Empty<ErrorDto>();
}
