using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews;

public class PointsViewSpendingUnavailable : ConstraintLayoutWidgetBase
{
	private TextView _titleText;

	public PointsViewSpendingUnavailable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PointsViewSpendingUnavailable(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public PointsViewSpendingUnavailable(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PointsViewSpendingUnavailable(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public PointsViewSpendingUnavailable(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	private void Initialize(Context context)
	{
		int resource = 2131493141;
		View view = View.Inflate(context, resource, this);
		_titleText = view.RequireViewById<TextView>(2131298660);
	}

	public void Setup(CheckoutViewModel viewModel, ILifecycleOwner viewLifecycleOwner)
	{
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_titleText.AddLinkedText(viewModel.PointsNotAvailableText, null, underlineLinks: false);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsNotAvailableText")))).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
