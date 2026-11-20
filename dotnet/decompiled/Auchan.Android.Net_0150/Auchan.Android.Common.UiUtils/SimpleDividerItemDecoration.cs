using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.Core.Content;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Common.UiUtils;

public class SimpleDividerItemDecoration : RecyclerView.ItemDecoration
{
	private readonly Drawable? _divider;

	public SimpleDividerItemDecoration(Context context)
	{
		_divider = ContextCompat.GetDrawable(context, 2131231457);
	}

	public override void OnDrawOver(Canvas c, RecyclerView parent, RecyclerView.State state)
	{
		int paddingLeft = parent.PaddingLeft;
		int right = parent.Width - parent.PaddingRight;
		int num = (parent.GetAdapter()?.ItemCount ?? 0) - 1;
		int childCount = parent.ChildCount;
		for (int i = 0; i < childCount; i++)
		{
			View childAt = parent.GetChildAt(i);
			int childAdapterPosition = parent.GetChildAdapterPosition(childAt);
			if (childAdapterPosition != -1 && childAdapterPosition != 0 && childAdapterPosition != num)
			{
				RecyclerView.LayoutParams layoutParams = (RecyclerView.LayoutParams)childAt.LayoutParameters;
				int num2 = childAt.Bottom + layoutParams.BottomMargin;
				int bottom = num2 + _divider.IntrinsicHeight;
				_divider.SetBounds(paddingLeft, num2, right, bottom);
				_divider.Draw(c);
			}
		}
	}
}
