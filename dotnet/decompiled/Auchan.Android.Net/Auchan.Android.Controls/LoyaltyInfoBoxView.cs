using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.Controls;

public class LoyaltyInfoBoxView : ConstraintLayout
{
	public TextView TitleLabel { get; private set; }

	public TextView DescriptionLabel { get; private set; }

	protected LoyaltyInfoBoxView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LoyaltyInfoBoxView(Context context)
		: this(context, null)
	{
	}

	public LoyaltyInfoBoxView(Context context, IAttributeSet attrs)
		: this(context, attrs, -1)
	{
	}

	public LoyaltyInfoBoxView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context, attrs, defStyleAttr);
	}

	private void Init(Context context, IAttributeSet attrs, int defStyleAttr)
	{
		View view = LayoutInflater.From(context).Inflate(2131493371, this, attachToRoot: true);
		TitleLabel = view.RequireViewById<TextView>(2131298655);
		DescriptionLabel = view.RequireViewById<TextView>(2131296962);
	}
}
