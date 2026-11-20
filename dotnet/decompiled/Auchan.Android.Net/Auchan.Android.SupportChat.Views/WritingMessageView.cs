using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Common.SupportChat.ItemViewModels;

namespace Auchan.Android.SupportChat.Views;

public sealed class WritingMessageView : FrameLayout, IChatContentView
{
	public const int IconMargin = 8;

	public const int IconSize = 40;

	private readonly ImageView _icon;

	private readonly View _avatarImageContainer;

	public WritingMessageView(Context context)
		: base(context)
	{
		View view = View.Inflate(context, 2131493199, this) ?? throw new InvalidOperationException("can't inflate layout");
		LayoutParameters = new ViewGroup.LayoutParams(-1, -2);
		_avatarImageContainer = view.RequireViewById<View>(2131296487);
		_icon = view.RequireViewById<ImageView>(2131296486);
	}

	public void SetMessageLayout(MessageLayoutType layout, WritingMessageViewModel message)
	{
		_avatarImageContainer.Visibility = ViewStates.Visible;
		_icon.SetImageDrawable(ContextCompat.GetDrawable(base.Context, 2131231046));
	}

	public void Bind(WritingMessageViewModel message, ICollection<IDisposable> disposables)
	{
	}
}
