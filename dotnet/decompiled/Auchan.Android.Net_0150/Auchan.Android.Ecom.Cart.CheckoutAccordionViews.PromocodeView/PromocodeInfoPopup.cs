using System;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Extensions;
using EBind;

namespace Auchan.Android.Ecom.Cart.CheckoutAccordionViews.PromocodeView;

internal sealed class PromocodeInfoPopup : PopupWindow
{
	private readonly View _atTopOf;

	private readonly CompositeDisposable _closeDisposables = new CompositeDisposable();

	private readonly View _triangle;

	private readonly View _contentTextContainer;

	public PromocodeInfoPopup(CheckoutViewModel viewModel, View atTopOf, View contentView, int width, int height)
		: base(contentView, width, height)
	{
		PromocodeInfoPopup promocodeInfoPopup = this;
		_atTopOf = atTopOf;
		_triangle = contentView.RequireViewById<View>(2131298767);
		_contentTextContainer = contentView.RequireViewById<View>(2131296843);
		Focusable = true;
		OutsideTouchable = true;
		Touchable = true;
		LayoutTriangle();
		atTopOf.LayoutChange += new DisposableDelegate<EventHandler<View.LayoutChangeEventArgs>>(delegate
		{
			promocodeInfoPopup.LayoutTriangle();
		}, delegate(EventHandler<View.LayoutChangeEventArgs> eh)
		{
			atTopOf.LayoutChange -= eh;
		}).AddTo(_closeDisposables);
		ContentView.LayoutChange += new DisposableDelegate<EventHandler<View.LayoutChangeEventArgs>>(delegate
		{
			promocodeInfoPopup.LayoutTriangle();
		}, delegate(EventHandler<View.LayoutChangeEventArgs> eh)
		{
			promocodeInfoPopup.ContentView.LayoutChange -= eh;
		}).AddTo(_closeDisposables);
		viewModel.PauseCommand.Subscribe(delegate
		{
			promocodeInfoPopup.Dismiss();
		}).AddTo(_closeDisposables);
	}

	public override void Dismiss()
	{
		base.Dismiss();
		_closeDisposables.Dispose();
	}

	private void LayoutTriangle()
	{
		int[] array = new int[2];
		_atTopOf.GetLocationOnScreen(array);
		int num = array[0];
		_ = array[1];
		int num2 = num;
		_triangle.GetLocationOnScreen(array);
		int num3 = array[0];
		_ = array[1];
		int num4 = num3;
		ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)_triangle.LayoutParameters;
		int num5 = marginLayoutParams.LeftMargin + num2 - num4;
		if (marginLayoutParams.LeftMargin != num5)
		{
			marginLayoutParams.LeftMargin = num5;
			_triangle.LayoutParameters = marginLayoutParams;
			_triangle.RequestLayout();
		}
		marginLayoutParams = (ViewGroup.MarginLayoutParams)_contentTextContainer.LayoutParameters;
		if (_contentTextContainer.Width < num5)
		{
			marginLayoutParams.LeftMargin = num5 + _triangle.Width - _contentTextContainer.Width;
		}
		else
		{
			marginLayoutParams.LeftMargin = 0;
		}
		_contentTextContainer.LayoutParameters = marginLayoutParams;
	}

	public static void Show(CheckoutViewModel viewModel, View atTopOf)
	{
		View rootView = atTopOf.RootView;
		View view = LayoutInflater.From(atTopOf.Context).Inflate(2131493483, null, attachToRoot: false);
		view.RequireViewById<TextView>(2131296844).Text = viewModel.PromocodeInfo;
		view.Measure(View.MeasureSpec.MakeMeasureSpec(rootView.Width, MeasureSpecMode.Exactly), View.MeasureSpec.MakeMeasureSpec(rootView.Height, MeasureSpecMode.AtMost));
		new PromocodeInfoPopup(viewModel, atTopOf, view, view.MeasuredWidth, view.MeasuredHeight).ShowAsDropDown(atTopOf, -atTopOf.Width / 2, atTopOf.Height / ((Build.VERSION.SdkInt >= BuildVersionCodes.N) ? 2 : (-2)), GravityFlags.Right);
	}
}
