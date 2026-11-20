using System;
using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

public class SearchItemDecoration : RecyclerView.ItemDecoration
{
	private readonly int _spaceInPx;

	private readonly int _marginsInPx;

	private readonly Func<int, bool> _applySpaceDelegate;

	private readonly Func<int, bool> _needIncreaseIndex;

	private readonly Func<int, bool> _withoutBottomMargin;

	public SearchItemDecoration(int spaceInDp, int sideMarginsDp = 0, Func<int, bool> applySpaceDelegate = null, Func<int, bool> needIncreaseIndex = null, Func<int, bool> withoutBottomMargin = null)
	{
		_spaceInPx = Converter.DpToPx(spaceInDp) / 2;
		_marginsInPx = Converter.DpToPx(sideMarginsDp);
		_applySpaceDelegate = applySpaceDelegate;
		_needIncreaseIndex = needIncreaseIndex;
		_withoutBottomMargin = withoutBottomMargin;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		base.GetItemOffsets(outRect, view, parent, state);
		int num = parent.GetChildAdapterPosition(view);
		if ((_applySpaceDelegate == null || _applySpaceDelegate(num)) && parent.GetLayoutManager() is GridLayoutManager)
		{
			if (_needIncreaseIndex != null && _needIncreaseIndex(num))
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
			outRect.Bottom = ((!_withoutBottomMargin(num)) ? _spaceInPx : 0);
			outRect.Top = _spaceInPx;
		}
	}
}
