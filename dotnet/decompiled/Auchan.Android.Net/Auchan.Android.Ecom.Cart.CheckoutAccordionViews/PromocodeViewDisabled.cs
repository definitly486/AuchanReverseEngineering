using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews;

public class PromocodeViewDisabled : ConstraintLayoutWidgetBase
{
	private View _view;

	private TextView _titleText;

	private View _plusButton;

	public PromocodeViewDisabled(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PromocodeViewDisabled(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PromocodeViewDisabled(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public PromocodeViewDisabled(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	public PromocodeViewDisabled(Context context)
		: base(context)
	{
		Initialize(context);
	}

	private void Initialize(Context context)
	{
		int resource = 2131493143;
		_view = View.Inflate(context, resource, this);
		_titleText = _view.RequireViewById<TextView>(2131298660);
	}

	public void Setup(CheckoutViewModel viewModel, ILifecycleOwner lifecycleOwner)
	{
		_titleText.Text = viewModel.PromocodeTitle;
		viewModel.BindEvents(_view.OnClick(viewModel.OnPromocodeAdd)).AutoDisposeOnDestroy(lifecycleOwner);
	}
}
