using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Base;

[Register("Auchan.Android.Base.CustomLinearLayoutManager")]
public sealed class CustomLinearLayoutManager : LinearLayoutManager
{
	public bool IsScrollable { get; set; }

	public CustomLinearLayoutManager(Context context)
		: base(context)
	{
	}

	public CustomLinearLayoutManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public CustomLinearLayoutManager(Context context, int orientation, bool reverseLayout)
		: base(context, orientation, reverseLayout)
	{
	}

	public CustomLinearLayoutManager(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public override bool CanScrollHorizontally()
	{
		if (IsScrollable)
		{
			return base.CanScrollHorizontally();
		}
		return false;
	}

	public override bool CanScrollVertically()
	{
		if (IsScrollable)
		{
			return base.CanScrollVertically();
		}
		return false;
	}
}
