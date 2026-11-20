using Android.Content;
using Android.Util;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Ecom.AddressStoreSelection;

public class LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations : LinearLayoutManager
{
	public LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context context)
		: base(context)
	{
	}

	public LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context context, int orientation, bool reverseLayout)
		: base(context, orientation, reverseLayout)
	{
	}

	public LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public override bool SupportsPredictiveItemAnimations()
	{
		return false;
	}
}
