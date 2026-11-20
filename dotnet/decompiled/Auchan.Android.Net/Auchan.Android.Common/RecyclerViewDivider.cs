using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Common;

public class RecyclerViewDivider : RecyclerView.ItemDecoration
{
	public int Offset { get; set; }

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		int right = (outRect.Bottom = Offset);
		outRect.Right = right;
	}
}
