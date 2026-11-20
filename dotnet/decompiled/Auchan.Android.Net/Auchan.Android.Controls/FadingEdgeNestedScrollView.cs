using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using AndroidX.Core.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

[Register("auchan.FadingEdgeNestedScrollView")]
public class FadingEdgeNestedScrollView : NestedScrollView
{
	public float? TopFadeEdge { get; set; }

	public float? BottomFadeEdge { get; set; }

	protected override float TopFadingEdgeStrength => TopFadeEdge ?? base.TopFadingEdgeStrength;

	protected override float BottomFadingEdgeStrength => BottomFadeEdge ?? base.BottomFadingEdgeStrength;

	public FadingEdgeNestedScrollView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public FadingEdgeNestedScrollView(Context context)
		: base(context)
	{
	}

	public FadingEdgeNestedScrollView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public FadingEdgeNestedScrollView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet attrs)
	{
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.FadingEdgeNestedScrollView);
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
