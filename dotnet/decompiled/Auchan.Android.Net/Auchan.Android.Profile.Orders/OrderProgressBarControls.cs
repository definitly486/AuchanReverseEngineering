using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content.Resources;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal sealed class OrderProgressBarControls(LinearLayout view, Resources resources, bool showText)
{
	public void Bind(OrderProgressViewModel viewModel, ILifecycleOwner lifecycleOwner)
	{
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				OnOrderProgressChanged(viewModel.Items);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Items")),
			(delegate
			{
				view.Visibility = viewModel.Visibility.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Visibility"))
		})).AutoDisposeOnDestroy(lifecycleOwner);
	}

	private void OnOrderProgressChanged(IReadOnlyList<OrderProgressViewModel.Item> items)
	{
		bool flag = Converter.PxToDp(((Activity)view.Context).GetScreenWidthInPixels()) <= 361;
		int itemWidthForSmallScreen = Converter.DpToPx(55f);
		view.RemoveAllViews();
		Color backgroundColorPassed = new Color(ResourcesCompat.GetColor(resources, 2131100611, null));
		Color backgroundColorToBe = new Color(ResourcesCompat.GetColor(resources, 2131099847, null));
		LayoutInflater layoutInflater = LayoutInflater.FromContext(view.Context);
		foreach (OrderProgressViewModel.Item item in items)
		{
			View view = layoutInflater.Inflate(2131493270, view, attachToRoot: false);
			if (flag)
			{
				view.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
				{
					lp.Width = itemWidthForSmallScreen;
				});
			}
			view.Id = View.GenerateViewId();
			new OrderProgressItemControls(view, showText).Bind(view, item, backgroundColorPassed, backgroundColorToBe, resources);
		}
	}
}
