using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

public class GridSpacesItemDecoration2 : RecyclerView.ItemDecoration
{
	private readonly int _verticalSpaceInPx;

	private readonly int _horizontalSpaceInPx;

	public GridSpacesItemDecoration2(int verticalSpaceInDp, int horizontalSpaceInDp)
	{
		_verticalSpaceInPx = Converter.DpToPx(verticalSpaceInDp) / 2;
		_horizontalSpaceInPx = Converter.DpToPx(horizontalSpaceInDp) / 2;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		outRect.Right = _horizontalSpaceInPx;
		outRect.Left = _horizontalSpaceInPx;
		outRect.Bottom = _verticalSpaceInPx;
		outRect.Top = _verticalSpaceInPx;
	}
}
