using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class FlexibleDividerItemDecoration : VerticalSpaceItemDecoration
{
	private readonly Func<int, Java.Lang.Object> _getDividerByPosition;

	public FlexibleDividerItemDecoration(Func<int, Java.Lang.Object> getDividerByPosition, bool skipLastItem = true)
		: base(0, skipLastItem)
	{
		_getDividerByPosition = getDividerByPosition;
	}

	protected override int GetBottomOffset(RecyclerView parent, View currentView)
	{
		if (!SkipLastItem || !VerticalSpaceItemDecoration.IsLastItem(parent, currentView))
		{
			return GetDividerHeight(_getDividerByPosition(parent.GetChildAdapterPosition(currentView)));
		}
		return 0;
	}

	public override void OnDraw(Canvas c, RecyclerView parent, RecyclerView.State state)
	{
		int num = (SkipLastItem ? (parent.ChildCount - 1) : parent.ChildCount);
		for (int i = 0; i < num; i++)
		{
			View childAt = parent.GetChildAt(i);
			Java.Lang.Object obj = _getDividerByPosition(parent.GetChildAdapterPosition(childAt));
			if (!(obj is Drawable drawable))
			{
				if (!(obj is View dividerView))
				{
					throw new NotImplementedException("dead code");
				}
				c.DrawBitmap(PrepareDividerView(parent, dividerView), 0f, childAt.Bottom, new Paint());
			}
			else
			{
				drawable.SetBounds(0, childAt.Bottom, parent.Width, childAt.Bottom + GetDividerHeight(drawable));
				drawable.Draw(c);
			}
		}
	}

	private Java.Lang.Object GetDividerForView(RecyclerView recycler, View currentView)
	{
		return _getDividerByPosition(recycler.GetChildAdapterPosition(currentView));
	}

	private static int GetDividerHeight(Java.Lang.Object divider)
	{
		if (!(divider is Drawable drawable))
		{
			if (divider is View view)
			{
				return GetDividerHeight(view);
			}
			throw new NotImplementedException("dead code");
		}
		return GetDividerHeight(drawable);
	}

	private static int GetDividerHeight(Drawable drawable)
	{
		return drawable.IntrinsicHeight;
	}

	private static int GetDividerHeight(View view)
	{
		return view.Height;
	}

	private static Bitmap PrepareDividerView(RecyclerView parent, View dividerView)
	{
		dividerView.Measure(View.MeasureSpec.MakeMeasureSpec(parent.Width, MeasureSpecMode.Exactly), View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified));
		dividerView.Layout(0, 0, dividerView.MeasuredWidth, dividerView.MeasuredHeight);
		Bitmap bitmap = Bitmap.CreateBitmap(parent.Width, GetDividerHeight(dividerView), Bitmap.Config.Argb8888 ?? throw new NullReferenceException("Argb8888")) ?? throw new NullReferenceException("Bitmap");
		dividerView.Draw(new Canvas(bitmap));
		return bitmap;
	}
}
