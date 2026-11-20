using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Home;
using Google.Android.Material.Card;

namespace Auchan.Android.Base.Widgets;

[Register("auchan.PersonalOfferView")]
public class PersonalOfferView : ConstraintLayoutWidgetBase
{
	private TextView _title;

	private TextView _description;

	private TextView _expiry;

	private MaterialCardView _background;

	private ImageView _offerImage;

	private ImageView _titleIcon;

	private ImageView _titleTail;

	private ViewGroup _titleContainer;

	private View _newIndicator;

	private AppCompatButton _acceptButton;

	public View NewIndicator => _newIndicator;

	public AppCompatButton AcceptButton => _acceptButton;

	protected PersonalOfferView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PersonalOfferView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public PersonalOfferView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public PersonalOfferView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public PersonalOfferView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		View view = View.Inflate(context, 2131493168, this);
		_title = view.RequireViewById<TextView>(2131298659);
		_description = view.RequireViewById<TextView>(2131296964);
		_expiry = view.RequireViewById<TextView>(2131297725);
		_background = view.RequireViewById<MaterialCardView>(2131296494);
		_offerImage = view.RequireViewById<ImageView>(2131296511);
		_newIndicator = view.RequireViewById<View>(2131297338);
		_acceptButton = view.RequireViewById<AppCompatButton>(2131296274);
		_titleContainer = view.RequireViewById<ViewGroup>(2131298650);
		_titleIcon = view.RequireViewById<ImageView>(2131298653);
		_titleTail = view.RequireViewById<ImageView>(2131298657);
	}

	public void Setup(PersOfferItemViewModel offer)
	{
		_title.Text = offer.Title;
		_description.Text = offer.Subitle;
		_expiry.Text = offer.TimePeriod;
		_background.SetCardBackgroundColor(Color.Rgb(offer.BgColor.R, offer.BgColor.G, offer.BgColor.B));
		_newIndicator.Visibility = (!offer.IsViewed).ToVisibility();
		_offerImage.FromUrl(offer.ImageUrl);
		MarginLayoutParams marginLayoutParams = (MarginLayoutParams)_title.LayoutParameters;
		int num = 4;
		switch (offer.DisplayType)
		{
		case OfferDisplayType.Cashback:
		{
			_titleContainer.SetBackgroundColor(new Color(ContextCompat.GetColor(base.Context, 2131100541)));
			_titleIcon.SetImageResource(2131231063);
			_titleTail.SetImageResource(2131231435);
			ImageView titleIcon3 = _titleIcon;
			ViewStates visibility = (_titleTail.Visibility = ViewStates.Visible);
			titleIcon3.Visibility = visibility;
			_title.SetTextColor(base.Context.GetColorStateList(2131099697));
			break;
		}
		case OfferDisplayType.Discount:
		{
			_titleContainer.SetBackgroundColor(new Color(ContextCompat.GetColor(base.Context, 2131100542)));
			_titleIcon.SetImageResource(2131231330);
			_titleTail.SetImageResource(2131231436);
			ImageView titleIcon2 = _titleIcon;
			ViewStates visibility = (_titleTail.Visibility = ViewStates.Visible);
			titleIcon2.Visibility = visibility;
			_title.SetTextColor(base.Context.GetColorStateList(2131099697));
			break;
		}
		default:
		{
			_titleContainer.SetBackgroundColor(Color.Transparent);
			ImageView titleIcon = _titleIcon;
			ViewStates visibility = (_titleTail.Visibility = ViewStates.Gone);
			titleIcon.Visibility = visibility;
			num = 0;
			_title.SetTextColor(base.Context.GetColorStateList(2131099872));
			break;
		}
		}
		_background.SetCardBackgroundColor(Color.Rgb(offer.BgColor.R, offer.BgColor.G, offer.BgColor.B));
		marginLayoutParams.SetMargins(Converter.DpToPx(num), 0, 0, 0);
		_title.LayoutParameters = marginLayoutParams;
	}
}
