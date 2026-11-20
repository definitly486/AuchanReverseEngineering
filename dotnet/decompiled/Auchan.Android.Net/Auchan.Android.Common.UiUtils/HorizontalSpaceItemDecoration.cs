using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

internal class HorizontalSpaceItemDecoration : RecyclerView.ItemDecoration
{
	private readonly int _spaceInPx;

	private readonly int _startSpaceInPx;

	private readonly int _endSpaceInPx;

	public HorizontalSpaceItemDecoration(int spaceInDp, int startSpaceInDp, int endSpaceInDp)
	{
		_spaceInPx = Converter.DpToPx(spaceInDp);
		_endSpaceInPx = Converter.DpToPx(endSpaceInDp);
		_startSpaceInPx = Converter.DpToPx(startSpaceInDp);
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		if (IsFirstItem(parent, view))
		{
			outRect.Left = _startSpaceInPx;
		}
		if (IsLastItem(parent, view))
		{
			outRect.Right = _endSpaceInPx;
		}
		else
		{
			outRect.Right = _spaceInPx;
		}
	}

	protected static bool IsFirstItem(RecyclerView parent, View currentView)
	{
		return parent.GetChildAdapterPosition(currentView) == 0;
	}

	protected static bool IsLastItem(RecyclerView parent, View currentView)
	{
		return parent.GetChildAdapterPosition(currentView) == parent.GetAdapter().ItemCount - 1;
	}
}
