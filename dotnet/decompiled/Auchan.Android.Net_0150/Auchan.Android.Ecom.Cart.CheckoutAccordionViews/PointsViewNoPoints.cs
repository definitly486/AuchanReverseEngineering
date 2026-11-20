using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews;

public class PointsViewNoPoints : ConstraintLayoutWidgetBase
{
	private TextView _titleText;

	public PointsViewNoPoints(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PointsViewNoPoints(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public PointsViewNoPoints(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PointsViewNoPoints(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public PointsViewNoPoints(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	private void Initialize(Context context)
	{
		int resource = 2131493140;
		View view = View.Inflate(context, resource, this);
		_titleText = view.RequireViewById<TextView>(2131298660);
	}

	public void Setup(CheckoutViewModel viewModel, ILifecycleOwner viewLifecycleOwner)
	{
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetLinkedText(viewModel.NoPointsText);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NoPointsText")))).AutoDisposeOnDestroy(viewLifecycleOwner);
	}

	private void SetLinkedText(LinkedText? linkedText)
	{
		_titleText.AddLinkedText(linkedText);
		_titleText.SetLinkTextColor(Color.Red);
	}
}
