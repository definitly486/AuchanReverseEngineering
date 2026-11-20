using System;
using System.Reactive.Disposables;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Google.Android.Material.Shape;
using Java.Lang;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal sealed class ExpressDeliveryAvailablePopup : PopupWindow
{
	private const int AutoDismissDelayMillis = 5000;

	private readonly CompositeDisposable _closeDisposables = new CompositeDisposable();

	private readonly View _autoDismissView;

	private readonly Runnable _autoDismissRunnable;

	public ExpressDeliveryAvailablePopup(IScreenViewModel viewModel, View contentView)
		: base(contentView, contentView.MeasuredWidth, contentView.MeasuredHeight)
	{
		Focusable = false;
		OutsideTouchable = true;
		Touchable = true;
		SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
		SetTouchInterceptor(new ViewOnTouchListener(delegate(View _, MotionEvent e)
		{
			if (e.Action != MotionEventActions.Outside)
			{
				return false;
			}
			Dismiss();
			return true;
		}));
		_autoDismissView = contentView;
		_autoDismissRunnable = new Runnable(Dismiss);
		ContentView.OnClick(Dismiss).AddTo(_closeDisposables);
		viewModel.PauseCommand.Subscribe(delegate
		{
			Dismiss();
		}).AddTo(_closeDisposables);
	}

	private void StartAutoDismiss()
	{
		_autoDismissView.PostDelayed(_autoDismissRunnable, 5000L);
	}

	public override void Dismiss()
	{
		_autoDismissView.RemoveCallbacks(_autoDismissRunnable);
		base.Dismiss();
		_closeDisposables.Dispose();
	}

	public static void Show(IScreenViewModel viewModel, string text, View relativeTo, Point offsetDp)
	{
		View rootView = relativeTo.RootView;
		View view = LayoutInflater.From(relativeTo.Context).Inflate(2131493468, null, attachToRoot: false);
		view.RequireViewById<TextView>(2131298603).Text = text;
		view.Measure(View.MeasureSpec.MakeMeasureSpec(rootView.Width, MeasureSpecMode.Exactly), View.MeasureSpec.MakeMeasureSpec(rootView.Height, MeasureSpecMode.AtMost));
		Point point = new Point(Converter.DpToPx(offsetDp.X), Converter.DpToPx(offsetDp.Y));
		ExpressDeliveryAvailablePopup expressDeliveryAvailablePopup = new ExpressDeliveryAvailablePopup(viewModel, view);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131296638);
		ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)frameLayout.LayoutParameters;
		expressDeliveryAvailablePopup.ShowAsDropDown(relativeTo, point.X - marginLayoutParams.MarginStart, -view.MeasuredHeight - relativeTo.Height - point.Y + marginLayoutParams.BottomMargin, GravityFlags.Start | GravityFlags.Top);
		expressDeliveryAvailablePopup.StartAutoDismiss();
		OffsetEdgeTreatment bottomEdge = new OffsetEdgeTreatment(new TriangleEdgeTreatment(Converter.DpToPx(7f), inside: false), -(rootView.Width / 2 - Converter.DpToPx(68f)));
		ShapeAppearanceModel shapeAppearanceModel = new ShapeAppearanceModel.Builder().SetBottomEdge(bottomEdge).SetAllCornerSizes(Converter.DpToPx(8f)).Build();
		MaterialShapeDrawable materialShapeDrawable = MaterialShapeDrawable.CreateWithElevationOverlay(frameLayout.Context, Converter.DpToPx(4f), ColorStateList.ValueOf(new Color(ContextCompat.GetColor(frameLayout.Context, 2131099697))));
		materialShapeDrawable.ShadowCompatibilityMode = 2;
		materialShapeDrawable.SetShadowColor(2131099712);
		materialShapeDrawable.ShapeAppearanceModel = shapeAppearanceModel;
		frameLayout.Background = materialShapeDrawable;
	}
}
