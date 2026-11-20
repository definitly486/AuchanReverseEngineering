using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.Controls;

public class ReceiveInformationView : ConstraintLayout
{
	private View _view;

	public TextView ReceiveMethodTextView { get; private set; }

	public TextView ReceiveAddressTextView { get; private set; }

	public ImageView ReceiveMethodImageView { get; private set; }

	public string ReceiveMethodText
	{
		get
		{
			return ReceiveMethodTextView.Text;
		}
		set
		{
			ReceiveMethodTextView.Text = value;
		}
	}

	public string ReceiveAddressText
	{
		get
		{
			return ReceiveAddressTextView.Text;
		}
		set
		{
			ReceiveAddressTextView.Text = value;
		}
	}

	public ReceiveInformationView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		_view = View.Inflate(context, 2131493512, this);
		ReceiveAddressTextView = _view.RequireViewById<TextView>(2131298165);
		ReceiveMethodTextView = _view.RequireViewById<TextView>(2131298167);
		ReceiveMethodImageView = _view.RequireViewById<ImageView>(2131298166);
	}
}
