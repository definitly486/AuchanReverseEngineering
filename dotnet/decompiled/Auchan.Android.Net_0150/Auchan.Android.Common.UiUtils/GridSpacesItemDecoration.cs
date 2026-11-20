using System;
using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

public class GridSpacesItemDecoration : RecyclerView.ItemDecoration
{
	private readonly int _spaceInPx;

	private readonly int _marginsInPx;

	private readonly Func<int, bool> _applySpaceDelegate;

	private readonly bool _setUpWithBanners;

	private readonly int _topSpaceInPx;

	private readonly int _bottomSpaceInPx;

	public GridSpacesItemDecoration(int spaceInDp, int sideMarginsDp = 0, Func<int, bool> applySpaceDelegate = null, bool setUpWithBanners = false, int topSpaceInDp = 0, int bottomSpaceInDp = 0)
	{
		_spaceInPx = Converter.DpToPx(spaceInDp) / 2;
		_marginsInPx = Converter.DpToPx(sideMarginsDp);
		_topSpaceInPx = Converter.DpToPx((topSpaceInDp > 0) ? topSpaceInDp : (spaceInDp / 2));
		_bottomSpaceInPx = Converter.DpToPx((bottomSpaceInDp > 0) ? bottomSpaceInDp : (spaceInDp / 2));
		_applySpaceDelegate = applySpaceDelegate;
		_setUpWithBanners = setUpWithBanners;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		base.GetItemOffsets(outRect, view, parent, state);
		int num = parent.GetChildAdapterPosition(view);
		if ((_applySpaceDelegate == null || _applySpaceDelegate(num)) && parent.GetLayoutManager() is GridLayoutManager)
		{
			if (_setUpWithBanners)
			{
				num++;
			}
			if (num % 2 == 0)
			{
				outRect.Right = _spaceInPx + _marginsInPx;
				outRect.Left = _spaceInPx;
			}
			else
			{
				outRect.Left = _spaceInPx + _marginsInPx;
				outRect.Right = _spaceInPx;
			}
			outRect.Bottom = _bottomSpaceInPx;
			outRect.Top = _topSpaceInPx;
		}
	}
}
