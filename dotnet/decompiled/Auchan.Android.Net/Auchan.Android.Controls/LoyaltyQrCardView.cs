using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;

namespace Auchan.Android.Controls;

public class LoyaltyQrCardView : ConstraintLayout
{
	private View _shadowBottomView;

	private CardView _card;

	private bool _isBlocked;

	public View BlockedShadowView { get; private set; }

	public TextView TitleLabel { get; private set; }

	public TextView CardNumberLabel { get; private set; }

	public ImageView AddToGooglePayButton { get; private set; }

	public bool IsBlocked
	{
		get
		{
			return _isBlocked;
		}
		set
		{
			if (_isBlocked != value)
			{
				_isBlocked = value;
				BlockedShadowView.Visibility = ((!value) ? ViewStates.Gone : ViewStates.Visible);
				_shadowBottomView.Visibility = ((!value) ? ViewStates.Gone : ViewStates.Visible);
				TitleLabel.SetTextColor(new Color(ContextCompat.GetColor(base.Context, value ? 2131099790 : 2131099697)));
				TitleLabel.SetTypeface(TitleLabel.Typeface, value ? TypefaceStyle.Bold : TypefaceStyle.Normal);
				CardNumberLabel.SetTextColor(new Color(ContextCompat.GetColor(base.Context, value ? 2131099700 : 2131099697)));
				_card.SetBackgroundColor(new Color(ContextCompat.GetColor(base.Context, value ? 2131099698 : 2131100610)));
			}
		}
	}

	protected LoyaltyQrCardView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LoyaltyQrCardView(Context context)
		: this(context, null)
	{
	}

	public LoyaltyQrCardView(Context context, IAttributeSet attrs)
		: this(context, attrs, -1)
	{
	}

	public LoyaltyQrCardView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context, attrs, defStyleAttr);
	}

	private void Init(Context context, IAttributeSet attrs, int defStyleAttr)
	{
		View view = LayoutInflater.From(context).Inflate(2131493370, this, attachToRoot: true);
		_shadowBottomView = view.RequireViewById<View>(2131298357);
		_card = view.RequireViewById<CardView>(2131296638);
		BlockedShadowView = view.RequireViewById<View>(2131296543);
		TitleLabel = _card.RequireViewById<TextView>(2131298655);
		CardNumberLabel = _card.RequireViewById<TextView>(2131296662);
		AddToGooglePayButton = _card.RequireViewById<ImageView>(2131296360);
		AddToGooglePayButton.Visibility = ViewStates.Invisible;
	}
}
