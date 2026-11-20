using Android.Graphics;
using Android.Views;
using AndroidX.CardView.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Profile.Favorites;

internal class SectionedGridDecoration : RecyclerView.ItemDecoration
{
	public int Offset { get; set; }

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		int num = Converter.DpToPx(Offset) / 2;
		int right = (outRect.Left = num);
		outRect.Right = right;
		if (view is CardView)
		{
			right = (outRect.Bottom = num);
			outRect.Top = right;
		}
	}
}
