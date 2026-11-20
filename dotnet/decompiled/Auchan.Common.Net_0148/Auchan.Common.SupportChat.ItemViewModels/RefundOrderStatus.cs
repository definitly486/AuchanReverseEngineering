using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Auchan.Common.SupportChat.ItemViewModels;

public sealed record RefundOrderStatus
{
	public required string Text { get; init; }

	public required Color Foreground { get; init; }

	public required Color Background { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RefundOrderStatus(RefundOrderStatus original)
	{
		Text = original.Text;
		Foreground = original.Foreground;
		Background = original.Background;
	}

	public RefundOrderStatus()
	{
	}
}
