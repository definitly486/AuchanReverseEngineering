using System;
using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

public class GridSpacesItemDecoration3 : RecyclerView.ItemDecoration
{
	private readonly int _topOffsetPX;

	private readonly int _bottomOffsetPX;

	private readonly int _startOffsetPX;

	private readonly int _endOffsetPX;

	private readonly Func<int, bool>? _selectorDelegate;

	public GridSpacesItemDecoration3(int topOffsetDP, int bottomOffsetDP, int startOffsetDP, int endOffsetDP, Func<int, bool>? selectorDelegate = null)
	{
		_topOffsetPX = Converter.DpToPx(topOffsetDP);
		_bottomOffsetPX = Converter.DpToPx(bottomOffsetDP);
		_startOffsetPX = Converter.DpToPx(startOffsetDP);
		_endOffsetPX = Converter.DpToPx(endOffsetDP);
		_selectorDelegate = selectorDelegate;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		int childAdapterPosition = parent.GetChildAdapterPosition(view);
		Func<int, bool>? selectorDelegate = _selectorDelegate;
		if (selectorDelegate != null && selectorDelegate(childAdapterPosition))
		{
			outRect.Top = _topOffsetPX;
			outRect.Bottom = _bottomOffsetPX;
			outRect.Left = _startOffsetPX;
			outRect.Right = _endOffsetPX;
		}
	}
}
