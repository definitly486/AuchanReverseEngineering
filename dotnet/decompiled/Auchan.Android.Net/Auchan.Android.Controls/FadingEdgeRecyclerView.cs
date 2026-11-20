using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using AndroidX.RecyclerView.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

[Register("auchan.FadingEdgeRecyclerView")]
public class FadingEdgeRecyclerView : RecyclerView
{
	public float? TopFadeEdge { get; set; }

	public float? BottomFadeEdge { get; set; }

	protected override float TopFadingEdgeStrength => TopFadeEdge ?? base.TopFadingEdgeStrength;

	protected override float BottomFadingEdgeStrength => BottomFadeEdge ?? base.BottomFadingEdgeStrength;

	public FadingEdgeRecyclerView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public FadingEdgeRecyclerView(Context context)
		: base(context)
	{
	}

	public FadingEdgeRecyclerView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public FadingEdgeRecyclerView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet attrs)
	{
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.FadingEdgeRecyclerView);
		float num = typedArray.GetFloat(1, -1f);
		float num2 = typedArray.GetFloat(0, -1f);
		typedArray.Recycle();
		if (num >= 0f)
		{
			TopFadeEdge = num;
		}
		if (num2 >= 0f)
		{
			BottomFadeEdge = num2;
		}
	}
}
