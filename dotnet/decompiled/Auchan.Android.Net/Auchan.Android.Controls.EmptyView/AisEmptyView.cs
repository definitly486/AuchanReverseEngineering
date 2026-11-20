using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Auchan.Android.Controls.EmptyView;

[Register("auchan.AisEmptyView")]
public class AisEmptyView : LinearLayout
{
	private ImageView _qrCodeButton;

	private TextView _moreButton;

	protected AisEmptyView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public AisEmptyView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public AisEmptyView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public AisEmptyView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public AisEmptyView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		View.Inflate(context, 2131493426, this);
	}
}
