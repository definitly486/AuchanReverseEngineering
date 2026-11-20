using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Base;

public sealed class CustomSizeLinearLayoutManager : LinearLayoutManager
{
	public bool ScrollingEnabled { get; set; } = true;

	public Func<RecyclerView.LayoutParams> CellSizeFunc { get; set; }

	public CustomSizeLinearLayoutManager(Context context)
		: base(context)
	{
	}

	public CustomSizeLinearLayoutManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public CustomSizeLinearLayoutManager(Context context, int orientation, bool reverseLayout)
		: base(context, orientation, reverseLayout)
	{
	}

	public CustomSizeLinearLayoutManager(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public override bool CheckLayoutParams(RecyclerView.LayoutParams lp)
	{
		if (CellSizeFunc != null)
		{
			RecyclerView.LayoutParams layoutParams = CellSizeFunc();
			lp.Width = layoutParams.Width;
			lp.Height = layoutParams.Height;
		}
		return true;
	}

	public override bool CanScrollHorizontally()
	{
		return ScrollingEnabled;
	}

	public override bool CanScrollVertically()
	{
		return ScrollingEnabled;
	}
}
