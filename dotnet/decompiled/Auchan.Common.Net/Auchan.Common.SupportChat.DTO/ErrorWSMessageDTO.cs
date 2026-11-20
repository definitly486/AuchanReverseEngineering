using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.SupportChat.DTO;

public sealed record ErrorWSMessageDTO : BaseWSMessageDTO
{
	public required string JsonMessage { get; init; }

	public required string Error { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ErrorWSMessageDTO(ErrorWSMessageDTO original)
		: base(original)
	{
		JsonMessage = original.JsonMessage;
		Error = original.Error;
	}

	public ErrorWSMessageDTO()
	{
	}
}
