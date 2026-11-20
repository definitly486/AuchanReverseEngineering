using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Ecom.Cart;

public class DeliveryDateDivider : RecyclerView.ItemDecoration
{
	public int MarginStart { get; set; }

	public int Offset { get; set; }

	public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
	{
		if (parent.GetChildAdapterPosition(view) == 0)
		{
			outRect.Left = MarginStart;
		}
		outRect.Right = Offset;
	}
}
