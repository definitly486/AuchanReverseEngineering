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
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews;

public class PointsViewDisabled : ConstraintLayoutWidgetBase
{
	private View _view;

	private TextView _titleText;

	private TextView _availableText;

	private TextView _burningText;

	private ImageView _infoButton;

	public PointsViewDisabled(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public PointsViewDisabled(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public PointsViewDisabled(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public PointsViewDisabled(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public PointsViewDisabled(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	public void Initialize(Context context)
	{
		int resource = 2131493139;
		_view = View.Inflate(context, resource, this);
		_titleText = _view.RequireViewById<TextView>(2131298660);
		_availableText = _view.RequireViewById<TextView>(2131296485);
		_burningText = _view.RequireViewById<TextView>(2131296586);
		_infoButton = _view.RequireViewById<ImageView>(2131297360);
	}

	public void Setup(CheckoutViewModel viewModel, ILifecycleOwner viewLifecycleOwner)
	{
		_titleText.Text = viewModel.PointsPaymentTitle;
		viewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				_availableText.Text = viewModel.PointsAvailableText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsAvailableText")),
			(delegate
			{
				_burningText.Text = viewModel.PointsBurnableText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBurnableText")),
			(delegate
			{
				_infoButton.Visibility = viewModel.IsAdultWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAdultWarningVisible"))
		})).AutoDisposeOnDestroy(viewLifecycleOwner);
		viewModel.BindEvents(_infoButton.OnClick(viewModel.OnPointsPaymentInfoClick), _view.OnClick(viewModel.OnPointsPaymentAdd)).AutoDisposeOnDestroy(viewLifecycleOwner);
	}
}
