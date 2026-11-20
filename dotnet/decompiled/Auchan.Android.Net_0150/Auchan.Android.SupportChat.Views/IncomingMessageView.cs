using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat.ItemViewModels;

namespace Auchan.Android.SupportChat.Views;

public sealed class IncomingMessageView : FrameLayout, IChatContentView
{
	public const int IconMargin = 8;

	public const int IconSize = 40;

	private readonly TextView _headerView;

	private readonly ImageView _icon;

	private readonly View _avatarImageContainer;

	public MessageView MessageView { get; }

	public IncomingMessageView(Context context)
		: base(context)
	{
		View view = View.Inflate(context, 2131493194, this) ?? throw new InvalidOperationException("can't inflate layout");
		LayoutParameters = new ViewGroup.LayoutParams(-1, -2);
		_avatarImageContainer = view.RequireViewById<View>(2131296487);
		_icon = view.RequireViewById<ImageView>(2131296486);
		_headerView = view.RequireViewById<TextView>(2131298352);
		CardView cardView = view.RequireViewById<CardView>(2131297565);
		MessageView = new MessageView(context, Auchan.Android.SupportChat.Views.MessageView.Alignment.Left);
		ViewGroup.LayoutParams layoutParameters = MessageView.LayoutParameters;
		MessageView.LayoutParameters = new LayoutParams(layoutParameters.Width, layoutParameters.Height);
		cardView.AddView(MessageView);
	}

	public void SetMessageLayout(MessageLayoutType layout, IncomingMessageViewModel message)
	{
		_headerView.Text = message.OperatorName;
		_headerView.Visibility = (layout == MessageLayoutType.Single || layout == MessageLayoutType.Upper).ToVisibility();
		if (layout == MessageLayoutType.Single || layout == MessageLayoutType.Lower)
		{
			_avatarImageContainer.Visibility = ViewStates.Visible;
			if (message.OperatorImageUrl == "Default")
			{
				_icon.SetImageDrawable(ContextCompat.GetDrawable(base.Context, 2131231046));
			}
			else
			{
				_icon.FromUrl(message.OperatorImageUrl);
			}
		}
		else
		{
			_avatarImageContainer.Visibility = ViewStates.Invisible;
		}
		switch (layout)
		{
		case MessageLayoutType.Upper:
		case MessageLayoutType.Single:
			MessageView.SetCornersRounded(topLeft: true, topRight: true, bottomRight: true, bottomLeft: false);
			break;
		case MessageLayoutType.Middle:
			MessageView.SetCornersRounded(topLeft: false, topRight: true, bottomRight: true, bottomLeft: false);
			break;
		case MessageLayoutType.Lower:
			MessageView.SetCornersRounded(topLeft: false, topRight: true, bottomRight: true, bottomLeft: true);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public void Bind(IncomingMessageViewModel message, ICollection<IDisposable> disposables)
	{
		MessageView.Bind(message);
		GradientDrawable gradientDrawable = (GradientDrawable)MessageView.MessageBackground.Mutate();
		gradientDrawable.SetColor(MessageView.ReceivedMessageBackgroundArgbColor);
		MessageView.MessageBackground = gradientDrawable;
		MessageView.ErrorImageView.Visibility = ViewStates.Gone;
		message.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetMessageLayout(message.Layout, message);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Layout")))).AddTo(disposables);
	}
}
