using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ShareCartModel
{
	public required string Token { get; init; }

	public required string Payload { get; init; }

	public string Title => Payload.Split('\n').FirstOrDefault() ?? "";

	public string Url => Payload.Split('\n').LastOrDefault() ?? "";

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ShareCartModel(ShareCartModel original)
	{
		Token = original.Token;
		Payload = original.Payload;
	}

	public ShareCartModel()
	{
	}
}
