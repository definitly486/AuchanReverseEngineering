using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal record ApiV2ResponseDto
{
	internal record ErrorDto
	{
		[JsonProperty("code")]
		public required string Code { get; init; }

		[JsonProperty("message")]
		public required string Message { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		protected ErrorDto(ErrorDto original)
		{
			Code = original.Code;
			Message = original.Message;
		}

		public ErrorDto()
		{
		}
	}

	[JsonProperty("errors")]
	public required IReadOnlyList<ErrorDto> Errors { get; init; } = Array.Empty<ErrorDto>();

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected ApiV2ResponseDto(ApiV2ResponseDto original)
	{
		Errors = original.Errors;
	}

	public ApiV2ResponseDto()
	{
	}
}
