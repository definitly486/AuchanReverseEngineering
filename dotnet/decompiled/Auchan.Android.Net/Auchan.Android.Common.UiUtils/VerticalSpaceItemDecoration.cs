using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Common.UiUtils;

public class VerticalSpaceItemDecoration : RecyclerView.ItemDecoration
{
	private readonly int _spaceInPx;

	protected readonly bool SkipLastItem;

	public VerticalSpaceItemDecoration(int spaceInDp, bool skipLastItem = true)
	{
		_spaceInPx = Converter.DpToPx(spaceInDp);
		SkipLastItem = skipLastItem;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		outRect.Bottom = GetBottomOffset(parent, view);
	}

	protected virtual int GetBottomOffset(RecyclerView parent, View currentView)
	{
		if (!SkipLastItem || !IsLastItem(parent, currentView))
		{
			return _spaceInPx;
		}
		return 0;
	}

	protected static bool IsLastItem(RecyclerView parent, View currentView)
	{
		if (parent != null && parent.GetAdapter() != null)
		{
			return parent.GetChildAdapterPosition(currentView) == ((parent == null) ? ((int?)null) : (parent.GetAdapter()?.ItemCount - 1));
		}
		return false;
	}
}
