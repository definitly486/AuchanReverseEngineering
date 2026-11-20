using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Controls;

[Register("auchan.BottomFadeEdgeRecyclerView")]
public class BottomFadeEdgeRecyclerView : RecyclerView
{
	protected override float TopFadingEdgeStrength => 0f;

	public BottomFadeEdgeRecyclerView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public BottomFadeEdgeRecyclerView(Context context)
		: base(context)
	{
	}

	public BottomFadeEdgeRecyclerView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public BottomFadeEdgeRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}
}
