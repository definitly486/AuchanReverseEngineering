using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base.WidgetBases;

namespace Auchan.Android.Profile.Stores;

[Register("auchan.TempWorkInformerView")]
public class TempWorkInformerView : LinearLayoutWidgetBase
{
	public TextView ContentTextView { get; private set; }

	protected TempWorkInformerView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public TempWorkInformerView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public TempWorkInformerView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public TempWorkInformerView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public TempWorkInformerView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493200, this);
		ContentTextView = view.RequireViewById<TextView>(2131298602);
	}
}
