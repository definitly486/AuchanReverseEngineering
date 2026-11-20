using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Text;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using EBind;

namespace Auchan.Android.Controls;

public class UserNotificationBannerView : ConstraintLayout
{
	private readonly TextView _textView;

	private readonly ImageView _rightChevron;

	public UserNotificationBannerView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		View view = View.Inflate(context, 2131493531, this) ?? throw new Resources.NotFoundException();
		_textView = view.RequireViewById<TextView>(2131298412);
		_rightChevron = view.RequireViewById<ImageView>(2131298246);
		_rightChevron.Visibility = ViewStates.Invisible;
	}

	public void Bind(UserNotificationBanner? banner, ICollection<IDisposable> disposables)
	{
		if (banner != null)
		{
			Setup(banner).AddTo(disposables);
		}
	}

	private IDisposable Setup(UserNotificationBanner banner)
	{
		_textView.TextFormatted = HtmlCompat.FromHtml(banner.HtmlText, 0);
		if (!banner.IsSoftUpdate)
		{
			return Disposable.Empty;
		}
		return SetupForSoftUpdate();
		IDisposable SetupForSoftUpdate()
		{
			_rightChevron.Visibility = ViewStates.Visible;
			DisposableDelegate<EventHandler> disposableDelegate = new DisposableDelegate<EventHandler>(delegate
			{
				banner.OnSoftUpdateClicked?.Invoke();
			}, delegate(EventHandler handler)
			{
				base.Click -= handler;
			});
			base.Click += disposableDelegate;
			return disposableDelegate;
		}
	}
}
