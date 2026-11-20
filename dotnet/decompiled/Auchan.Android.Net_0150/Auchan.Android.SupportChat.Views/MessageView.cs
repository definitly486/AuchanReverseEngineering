using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.SupportChat;
using Auchan.Common.SupportChat.ItemViewModels;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Request;
using Bumptech.Glide.Request.Target;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.SupportChat.Views;

public sealed class MessageView : ConstraintLayout, IChatContentView, IRequestListener, IJavaObject, IDisposable, IJavaPeerable
{
	public enum Alignment
	{
		Left,
		Right
	}

	private const int CORNER_RADIUS = 16;

	private BaseMessageViewModel? _model;

	public TextView MessageTextView { get; }

	public ImageView MessageImageView { get; }

	public TextView MessageImageLoadingText { get; }

	public CardView MessageImageContainer { get; }

	public TextView TimestampTextView { get; }

	public TextView TimestampAtBackground { get; }

	public View TimestampBackgroundContainer { get; }

	public GradientDrawable MessageBackground { get; set; }

	public ViewGroup MessageContainer { get; }

	public LayoutParams MessageContainerLayoutParams { get; }

	public ImageView ErrorImageView { get; set; }

	public float CornerRadiiValue { get; }

	public int ReceivedMessageBackgroundArgbColor => ContextCompat.GetColor(base.Context, 2131099699);

	public MessageView(Context context, Alignment alignment, int xMarginFromEdge = 0)
		: base(context)
	{
		View.Inflate(context, 2131493197, this);
		LayoutParameters = new ViewGroup.LayoutParams(-1, -2);
		MessageTextView = RequireViewById<TextView>(2131297570);
		MessageImageView = RequireViewById<ImageView>(2131297567);
		MessageImageLoadingText = RequireViewById<TextView>(2131297569);
		MessageImageContainer = RequireViewById<CardView>(2131297568);
		TimestampTextView = RequireViewById<TextView>(2131298643);
		TimestampAtBackground = RequireViewById<TextView>(2131298644);
		TimestampBackgroundContainer = RequireViewById<View>(2131298645);
		MessageContainer = RequireViewById<ViewGroup>(2131297564);
		MessageBackground = ((GradientDrawable)MessageContainer.Background) ?? throw new NullReferenceException("Background");
		MessageContainerLayoutParams = (LayoutParams)(MessageContainer.LayoutParameters ?? throw new NullReferenceException("LayoutParameters"));
		if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
		{
			CornerRadiiValue = (MessageBackground.GetCornerRadii() ?? throw new NullReferenceException("GetCornerRadii")).First((float x) => x != 0f);
		}
		else
		{
			CornerRadiiValue = Converter.DpToPx(16f);
		}
		ErrorImageView = RequireViewById<ImageView>(2131297114);
		if (alignment == Alignment.Left)
		{
			MessageContainerLayoutParams.StartToStart = 0;
			MessageContainerLayoutParams.MarginStart = Converter.DpToPx(xMarginFromEdge);
		}
		else
		{
			MessageContainerLayoutParams.EndToEnd = 0;
			MessageContainerLayoutParams.MarginEnd = Converter.DpToPx(xMarginFromEdge);
		}
	}

	public void SetMessageLayout(MessageLayoutType layout, OutgoingMessageViewModel message)
	{
		switch (layout)
		{
		case MessageLayoutType.Upper:
		case MessageLayoutType.Single:
			SetCornersRounded(topLeft: true, topRight: true, bottomRight: false, bottomLeft: true);
			break;
		case MessageLayoutType.Middle:
			SetCornersRounded(topLeft: true, topRight: false, bottomRight: false, bottomLeft: true);
			break;
		case MessageLayoutType.Lower:
			SetCornersRounded(topLeft: true, topRight: false, bottomRight: true, bottomLeft: true);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public void SetCornersRounded(bool topLeft, bool topRight, bool bottomRight, bool bottomLeft)
	{
		float cornerRadiiValue = CornerRadiiValue;
		GradientDrawable gradientDrawable = (GradientDrawable)MessageBackground.Mutate();
		gradientDrawable.SetCornerRadii(new float[8]
		{
			topLeft ? cornerRadiiValue : 0f,
			topLeft ? cornerRadiiValue : 0f,
			topRight ? cornerRadiiValue : 0f,
			topRight ? cornerRadiiValue : 0f,
			bottomRight ? cornerRadiiValue : 0f,
			bottomRight ? cornerRadiiValue : 0f,
			bottomLeft ? cornerRadiiValue : 0f,
			bottomLeft ? cornerRadiiValue : 0f
		});
		MessageBackground = gradientDrawable;
	}

	public void Bind(BaseMessageViewModel message)
	{
		_model = message;
		bool flag = !string.IsNullOrEmpty(message.MessageText);
		if (flag)
		{
			MessageTextView.SetSupportChatHtml(message.MessageText + " ⠀⠀⠀⠀", delegate
			{
			});
		}
		else
		{
			MessageTextView.Text = "";
		}
		MessageTextView.Visibility = flag.ToVisibility();
		TextView timestampAtBackground = TimestampAtBackground;
		string text = (TimestampTextView.Text = message.MessageTime);
		timestampAtBackground.Text = text;
		TimestampTextView.Visibility = flag.ToVisibility();
		TimestampBackgroundContainer.Visibility = (!flag).ToVisibility();
		if (!string.IsNullOrEmpty(message.AttachmentUrl) && message.IsImage)
		{
			MessageContainerLayoutParams.MatchConstraintMaxWidth = 0;
			MessageImageView.FromUrlWithListener(message.AttachmentUrl, this);
			MessageImageLoadingText.Text = "Загружается изображение: " + message.AttachmentUrl;
			MessageImageLoadingText.Visibility = ViewStates.Visible;
		}
		else
		{
			MessageContainerLayoutParams.MatchConstraintMaxWidth = -2;
		}
	}

	public void Bind(OutgoingMessageViewModel message, ICollection<IDisposable> disposables)
	{
		Bind(message);
		GradientDrawable gradientDrawable = (GradientDrawable)MessageBackground.Mutate();
		gradientDrawable.SetColor(ContextCompat.GetColor(base.Context, string.IsNullOrEmpty(message.MessageText) ? 2131099699 : 2131099738));
		MessageBackground = gradientDrawable;
		message.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				ErrorImageView.Visibility = (message.Status == MessageStatusType.Error).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Status")),
			(delegate
			{
				SetMessageLayout(message.Layout, message);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Layout"))
		})).AddTo(disposables);
		message.BindEvents(ErrorImageView.OnClick(message.ResendCommand.Trigger)).AddTo(disposables);
	}

	public bool OnLoadFailed(GlideException p0, Java.Lang.Object p1, ITarget p2, bool p3)
	{
		string text = MessageImageLoadingText.Text;
		if (text?.Length > "Загружается изображение: ".Length)
		{
			string text2 = text.Substring("Загружается изображение: ".Length);
			MessageImageLoadingText.Text = "Не могу отобразить изображение: " + text2;
		}
		return false;
	}

	public bool OnResourceReady(Java.Lang.Object p0, Java.Lang.Object p1, ITarget p2, DataSource p3, bool p4)
	{
		MessageImageLoadingText.Visibility = ViewStates.Gone;
		_model?.OnImageDownloaded();
		return false;
	}
}
