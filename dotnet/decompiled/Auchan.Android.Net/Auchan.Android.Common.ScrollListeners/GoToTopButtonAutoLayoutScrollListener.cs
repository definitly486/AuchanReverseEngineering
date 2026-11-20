using System;
using System.Linq;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Common.Controls.AutoLayout;
using Google.Android.Material.AppBar;

namespace Auchan.Android.Common.ScrollListeners;

internal sealed class GoToTopButtonAutoLayoutScrollListener : GoToTopButtonScrollListener
{
	private readonly AutoLayoutViewModel _viewModel;

	public GoToTopButtonAutoLayoutScrollListener(RecyclerView recyclerView, AutoLayoutViewModel viewModel, View button, Action buttonShowAction, Action buttonHideAction, AppBarLayout? appBarLayout = null)
		: base(button, buttonShowAction, buttonHideAction, appBarLayout)
	{
		_viewModel = viewModel;
	}

	public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
	{
		if (!base.IsEnabled)
		{
			return;
		}
		int num = recyclerView.ComputeVerticalScrollOffset();
		if (base.IsAutoScrollingToTop && num == 0)
		{
			_isAutoScrollingToTop = false;
			_appBarLayout?.SetExpanded(expanded: true, animate: true);
		}
		int num2 = _viewModel.Elements.Count((AutoLayoutViewModel.AutoLayoutElement x) => x.Type == "RecommendationProduct");
		if (num2 < 12)
		{
			HideButtonIfNeeded();
			return;
		}
		double num3 = ((num2 % 2 == 0) ? ((double)((float)num2 / 2f)) : ((double)((float)num2 / 2f) + 0.5));
		float num4 = Converter.DpToPx(312f);
		double num5 = (double)recyclerView.ComputeVerticalScrollRange() - (double)num4 * num3;
		double num6 = _screenHeight / (double)num4;
		double num7 = (double)num4 * Math.Floor(6.0 - num6);
		if ((double)num >= Math.Abs(_screenHeight - (num5 + num7)))
		{
			ShowButtonIfNeeded();
		}
		else if (num == 0 || (double)num <= Math.Abs(_screenHeight - (num5 + num7)))
		{
			HideButtonIfNeeded();
		}
	}
}
