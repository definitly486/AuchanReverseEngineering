using System;
using System.Drawing;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.View;
using AndroidX.Core.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;

namespace Auchan.Android.Controls;

internal sealed class HintPopup : HintPopupBase
{
	private const int LightThemeShadowInsetDp = 16;

	private const int LightThemeElevationDp = 12;

	private const int LightThemeTriangleZDp = 13;

	private const int HorizontalMarginDp = 20;

	private const int CornerRadiusDp = 8;

	private static readonly WeakReference<HintPopup> s_Current = new WeakReference<HintPopup>(null);

	private readonly View _relativeTo;

	private readonly Point _offset;

	private readonly bool _centerOnAnchor;

	private readonly View _triangle;

	private readonly View _contentTextContainer;

	private bool IsDropDown => _triangle.Rotation <= float.Epsilon;

	public HintPopup(IScreenViewModel viewModel, View relativeTo, Point offset, View contentView, int width, int height, Action? onClick, bool centerOnAnchor)
		: base(contentView, width, height)
	{
		HintPopup hintPopup = this;
		lock (s_Current)
		{
			s_Current.SetTarget(this);
		}
		_relativeTo = relativeTo;
		_offset = offset;
		_centerOnAnchor = centerOnAnchor;
		_triangle = contentView.RequireViewById<View>(2131298767);
		_contentTextContainer = contentView.RequireViewById<View>(2131296843);
		LayoutTriangle();
		TextView textView = contentView.RequireViewById<TextView>(2131296844);
		new CompositeDisposable
		{
			relativeTo.OnLayoutChange(LayoutTriangle),
			contentView.OnLayoutChange(LayoutTriangle),
			_contentTextContainer.OnLayoutChange(LayoutTriangle),
			((View)textView).OnClick((Action)delegate
			{
				onClick?.Invoke();
				hintPopup.Dismiss();
			}),
			contentView.OnClick((Action)delegate
			{
				onClick?.Invoke();
			}),
			Disposable.Create(delegate
			{
				lock (s_Current)
				{
					if (s_Current.TryGetTarget(out HintPopup _))
					{
						s_Current.SetTarget(null);
					}
				}
			})
		}.AddTo(_closeDisposables);
		viewModel.PauseCommand.Subscribe(delegate
		{
			hintPopup.Dismiss();
		}).AddTo(_closeDisposables);
	}

	private void LayoutTriangle()
	{
		if (_triangle.Width == 0 || _contentTextContainer.Width == 0 || Width == 0)
		{
			return;
		}
		Point locationOnScreen = _relativeTo.GetLocationOnScreen();
		ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)_triangle.LayoutParameters;
		int num2;
		if (_centerOnAnchor)
		{
			View view = (View)_triangle.Parent;
			Point locationOnScreen2 = view.GetLocationOnScreen();
			int num = Converter.DpToPx(8f);
			int val = _contentTextContainer.Left + num;
			int val2 = Math.Max(val, _contentTextContainer.Right - num - _triangle.Width);
			int val3 = locationOnScreen.X - locationOnScreen2.X + (_relativeTo.Width - _triangle.Width) / 2 + _offset.X;
			num2 = Math.Max(val, Math.Min(val3, val2)) - view.PaddingLeft;
		}
		else
		{
			Point locationOnScreen3 = _triangle.GetLocationOnScreen();
			num2 = marginLayoutParams.LeftMargin + locationOnScreen.X - locationOnScreen3.X + _relativeTo.Width / 2 + ((!IsDropDown) ? (_triangle.Width / 2) : 0) + _offset.X;
			if (num2 < 0)
			{
				num2 = 0;
			}
			else if (num2 > Width - _triangle.Width)
			{
				num2 = Width - _triangle.Width;
			}
		}
		if (marginLayoutParams.LeftMargin != num2)
		{
			_ = marginLayoutParams.LeftMargin;
			marginLayoutParams.LeftMargin = num2;
			_triangle.LayoutParameters = marginLayoutParams;
			_triangle.RequestLayout();
		}
	}

	public static IDisposable? Show(IScreenViewModel viewModel, string text, View anchor, Point offsetDp, bool atTop, bool checkAnchorVisibility = false, Size sizeDp = default(Size), Size paddingDp = default(Size), Action? onClick = null, bool centerOnAnchor = false, bool useLightTheme = false, int maxWidthDp = 0)
	{
		return Show(viewModel, new LinkedText(text), anchor, offsetDp, atTop, checkAnchorVisibility, sizeDp, paddingDp, onClick, centerOnAnchor, useLightTheme, maxWidthDp);
	}

	public static IDisposable? Show(IScreenViewModel viewModel, LinkedText text, View anchor, Point offsetDp, bool atTop, bool checkAnchorVisibility = false, Size sizeDp = default(Size), Size paddingDp = default(Size), Action? onClick = null, bool centerOnAnchor = false, bool useLightTheme = false, int maxWidthDp = 0)
	{
		if (!viewModel.IsActive)
		{
			return null;
		}
		if (checkAnchorVisibility && !anchor.IsVisibleToUser())
		{
			return null;
		}
		lock (s_Current)
		{
			if (s_Current.TryGetTarget(out HintPopup _))
			{
				return null;
			}
		}
		View rootView = anchor.RootView;
		long num = SystemClock.UptimeMillis();
		MotionEvent motionEvent = MotionEvent.Obtain(num, num, MotionEventActions.Cancel, 0f, 0f, MetaKeyStates.None);
		rootView.DispatchTouchEvent(motionEvent);
		motionEvent.Recycle();
		View view = LayoutInflater.From(anchor.Context).Inflate(atTop ? 2131493472 : 2131493471, null, attachToRoot: false);
		if (paddingDp.Width > 0 || paddingDp.Height > 0)
		{
			Size size = paddingDp.DpToPx();
			view.SetPadding(size.Width, size.Height, size.Width, size.Height);
		}
		TextView textView = view.RequireViewById<TextView>(2131296844);
		textView.AddLinkedText(text);
		int num2 = 0;
		if (useLightTheme)
		{
			View view2 = view.RequireViewById<View>(2131296843);
			View view3 = view.RequireViewById<View>(2131298767);
			num2 = Converter.DpToPx(16f);
			view2.SetBackgroundResource(2131230917);
			ViewCompat.SetBackgroundTintList(view3, ContextCompat.GetColorStateList(anchor.Context, 2131099697));
			textView.SetTextColor(ContextCompat.GetColorStateList(anchor.Context, 2131099872));
			textView.SetIncludeFontPadding(includepad: false);
			textView.LetterSpacing = -0.01f;
			TextViewCompat.SetLineHeight(textView, Converter.SpToPx(14f));
			view.SetPadding(view.PaddingLeft + num2, view.PaddingTop + num2, view.PaddingRight + num2, view.PaddingBottom + num2);
			if (view is ViewGroup viewGroup)
			{
				viewGroup.SetClipChildren(clipChildren: false);
				viewGroup.SetClipToPadding(clipToPadding: false);
			}
			ViewCompat.SetElevation(view2, Converter.DpToPx(12f));
			view3.OutlineProvider = null;
			ViewCompat.SetElevation(view3, Converter.DpToPx(13f));
			view3.BringToFront();
		}
		if (sizeDp.Width > 0 || sizeDp.Height > 0)
		{
			Size size2 = sizeDp.DpToPx();
			view.RequireViewById<View>(2131296843).UpdateLayoutParams(delegate(ViewGroup.LayoutParams lp)
			{
				lp.Width = ((size2.Width > 0) ? size2.Width : lp.Width);
				lp.Height = ((size2.Height > 0) ? size2.Height : lp.Height);
			});
		}
		int num3 = rootView.Width;
		if (maxWidthDp > 0)
		{
			num3 = Math.Min(num3 - (centerOnAnchor ? (2 * Converter.DpToPx(20f)) : 0), Converter.DpToPx(maxWidthDp) + view.PaddingLeft + view.PaddingRight);
			View view4 = view.RequireViewById<View>(2131296843);
			View view5 = view.RequireViewById<View>(2131298767);
			view4.SetMinimumWidth(view5.LayoutParameters.Width + 2 * Converter.DpToPx(8f));
		}
		view.Measure(View.MeasureSpec.MakeMeasureSpec(Math.Max(0, num3), MeasureSpecMode.AtMost), View.MeasureSpec.MakeMeasureSpec(rootView.Height, MeasureSpecMode.AtMost));
		Point offset = new Point(Converter.DpToPx(offsetDp.X), Converter.DpToPx(offsetDp.Y));
		int xoff = (centerOnAnchor ? GetCenteredHorizontalOffset(anchor, rootView, view.MeasuredWidth) : 0);
		HintPopup pw = new HintPopup(viewModel, anchor, offset, view, view.MeasuredWidth, view.MeasuredHeight, onClick, centerOnAnchor);
		if (atTop)
		{
			pw.ShowAsDropDown(anchor, xoff, -view.MeasuredHeight - anchor.Height - offset.Y + num2, GravityFlags.Left);
		}
		else
		{
			_ = (ViewGroup.MarginLayoutParams)pw._contentTextContainer.LayoutParameters;
			pw.ShowAsDropDown(anchor, xoff, offset.Y - num2, GravityFlags.Left);
		}
		return Disposable.Create(delegate
		{
			pw.Dismiss();
		});
	}

	private static int GetCenteredHorizontalOffset(View anchor, View rootView, int popupWidth)
	{
		Point locationOnScreen = anchor.GetLocationOnScreen();
		Point locationOnScreen2 = rootView.GetLocationOnScreen();
		int num = Converter.DpToPx(20f);
		int val = locationOnScreen.X + (anchor.Width - popupWidth) / 2;
		int num2 = locationOnScreen2.X + num;
		int num3 = locationOnScreen2.X + rootView.Width - popupWidth - num;
		return ((num3 >= num2) ? Math.Max(num2, Math.Min(val, num3)) : locationOnScreen2.X) - locationOnScreen.X;
	}
}
