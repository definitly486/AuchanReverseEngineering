using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Common;

public sealed record AlertButton
{
	public required string Title { get; set; }

	public Action? Action { get; set; }

	public ActionType Type { get; set; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AlertButton(AlertButton original)
	{
		Title = original.Title;
		Action = original.Action;
		Type = original.Type;
	}

	public AlertButton()
	{
	}
}
