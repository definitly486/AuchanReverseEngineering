using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Common.UiUtils;

public class StartEndMarginDivider : RecyclerView.ItemDecoration
{
	public RecyclerView.Adapter Adapter { get; }

	public int MarginStart { get; }

	public int MarginEnd { get; }

	public StartEndMarginDivider(RecyclerView.Adapter adapter, int marginStart, int marginEnd)
	{
		Adapter = adapter;
		MarginStart = marginStart;
		MarginEnd = marginEnd;
	}

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		int childAdapterPosition = parent.GetChildAdapterPosition(view);
		if (childAdapterPosition == 0)
		{
			outRect.Left = MarginStart;
		}
		if (childAdapterPosition == Adapter.ItemCount - 1)
		{
			outRect.Right = MarginEnd;
		}
	}
}
