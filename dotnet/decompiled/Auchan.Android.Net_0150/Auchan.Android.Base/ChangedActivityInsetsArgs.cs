using System;
using Android.Views;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;

namespace Auchan.Android.Base;

public sealed class ChangedActivityInsetsArgs : EventArgs
{
	public required View ActivityView { get; init; }

	public required Insets ActivityViewOriginalPadding { get; init; }

	public required WindowInsetsCompat Insets { get; init; }

	public bool Handled { get; set; }
}
