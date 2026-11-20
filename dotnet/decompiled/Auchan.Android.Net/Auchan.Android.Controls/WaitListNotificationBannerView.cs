using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Home;

namespace Auchan.Android.Controls;

public class WaitListNotificationBannerView : ConstraintLayout
{
	private readonly TextView _productCount;

	private readonly TextView _productName;

	private readonly ImageView _productIcon;

	private readonly ImageView _closeButton;

	public WaitListNotificationBannerView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		View view = View.Inflate(context, 2131493534, this) ?? throw new Resources.NotFoundException();
		_productCount = view.RequireViewById<TextView>(2131298036);
		_productName = view.RequireViewById<TextView>(2131298018);
		_productIcon = view.RequireViewById<ImageView>(2131298010);
		_closeButton = view.RequireViewById<ImageView>(2131296795);
	}

	public void Bind(WaitListNotificationBanner? banner, ILifecycleOwner lifeCycleOwner)
	{
		if (banner != null)
		{
			Setup(banner, lifeCycleOwner);
		}
	}

	private void Setup(WaitListNotificationBanner banner, ILifecycleOwner lifeCycleOwner)
	{
		banner.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				_productCount.Text = banner.ProductCount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductCount")),
			(delegate
			{
				_productIcon.FromUrlAnimated(banner.ImageUrl);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ImageUrl")),
			(delegate
			{
				_productName.Text = banner.ProductName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductName"))
		})).AutoDisposeOnDestroy(lifeCycleOwner);
		banner.BindEvents(((View)_closeButton).OnClick((Action)delegate
		{
			banner.Visible = false;
		}), ((View)this).OnClick((Action)delegate
		{
			banner.OnNotificationClicked?.Invoke();
			banner.Visible = false;
		})).AutoDisposeOnDestroy(lifeCycleOwner);
	}
}
