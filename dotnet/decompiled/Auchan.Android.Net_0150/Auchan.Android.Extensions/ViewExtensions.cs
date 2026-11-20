using System;
using System.Buffers;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.Views;
using AndroidX.Core.View.Accessibility;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Providers;
using Auchan.Common.Common;
using Google.Android.Material.AppBar;

namespace Auchan.Android.Extensions;

public static class ViewExtensions
{
	internal static bool IsFullyExpanded(this AppBarLayout appBarLayout)
	{
		return appBarLayout.Top == 0;
	}

	public static Rect ScreenVisibleRect(this View view)
	{
		Rect rect = new Rect();
		System.Drawing.Point locationOnScreen = view.GetLocationOnScreen();
		view.GetGlobalVisibleRect(rect);
		rect.OffsetTo(locationOnScreen.X, locationOnScreen.Y);
		return rect;
	}

	public static System.Drawing.Point GetLocationOnScreen(this View view)
	{
		int[] array = ArrayPool<int>.Shared.Rent(2);
		try
		{
			view.GetLocationOnScreen(array);
			return new System.Drawing.Point(array[0], array[1]);
		}
		finally
		{
			ArrayPool<int>.Shared.Return(array);
		}
	}

	public static System.Drawing.Point GetLocationInWindow(this View @this)
	{
		int[] array = ArrayPool<int>.Shared.Rent(2);
		try
		{
			@this.GetLocationInWindow(array);
			return new System.Drawing.Point(array[0], array[1]);
		}
		finally
		{
			ArrayPool<int>.Shared.Return(array);
		}
	}

	public static Size GetSizeInDp(this View view)
	{
		return new Size(Converter.PxToDp(view.Width), Converter.PxToDp(view.Height));
	}

	public static void SetHeight(this View view, int heightDp)
	{
		int height = Converter.DpToPx(heightDp);
		ViewGroup.LayoutParams layoutParameters = view.LayoutParameters;
		layoutParameters.Height = height;
		view.LayoutParameters = layoutParameters;
	}

	public static void SetPaddingDp(this View view, int left, int top, int right, int bottom)
	{
		int left2 = ((left > 0) ? Converter.DpToPx(left) : 0);
		int top2 = ((top > 0) ? Converter.DpToPx(top) : 0);
		int right2 = ((right > 0) ? Converter.DpToPx(right) : 0);
		int bottom2 = ((bottom > 0) ? Converter.DpToPx(bottom) : 0);
		view.SetPadding(left2, top2, right2, bottom2);
	}

	public static int GetTopRelativeTo(this View child, View parent)
	{
		int num = child.Top;
		View view = child.Parent as View;
		while (view != null && view.Id != parent.Id)
		{
			num += view.Top;
			view = view.Parent as View;
		}
		return num;
	}

	public static void SetRoundedCorners(this View layout, float radiusDp)
	{
		int num = Converter.DpToPx(radiusDp);
		layout.OutlineProvider = new RoundViewOutlineProvider(num);
		layout.ClipToOutline = true;
	}

	public static bool IsVisibleToUser(this View @this)
	{
		AccessibilityNodeInfoCompat accessibilityNodeInfoCompat = AccessibilityNodeInfoCompat.Obtain();
		@this.OnInitializeAccessibilityNodeInfo(accessibilityNodeInfoCompat.Unwrap());
		return accessibilityNodeInfoCompat.VisibleToUser;
	}

	public static IEnumerable<ViewGroup> EnumerateParents(this View view)
	{
		for (IViewParent v = view.Parent; v != null; v = v.Parent)
		{
			if (v is ViewGroup viewGroup)
			{
				yield return viewGroup;
			}
		}
	}

	public static T? FindParent<T>(this View view) where T : ViewGroup
	{
		for (IViewParent parent = view.Parent; parent != null; parent = parent.Parent)
		{
			if (parent is T result)
			{
				return result;
			}
		}
		return null;
	}

	public static T RequireParent<T>(this View view) where T : ViewGroup
	{
		T val = view.FindParent<T>();
		if (val != null)
		{
			return val;
		}
		throw new NotFoundException($"parent of type {typeof(T)} isn't found");
	}

	public static View UpdateLayoutParams<T>(this View @this, Action<T> action) where T : ViewGroup.LayoutParams
	{
		if (@this.LayoutParameters is T val)
		{
			action(val);
			@this.LayoutParameters = val;
		}
		return @this;
	}

	public static View UpdateLayoutParams(this View @this, Action<ViewGroup.LayoutParams> action)
	{
		ViewGroup.LayoutParams layoutParameters = @this.LayoutParameters;
		if (layoutParameters != null)
		{
			action(layoutParameters);
			@this.LayoutParameters = layoutParameters;
		}
		return @this;
	}

	public static View ScaleLayoutDimensions(this View @this, double scale)
	{
		@this.SetPadding((int)((double)@this.PaddingLeft * scale), (int)((double)@this.PaddingTop * scale), (int)((double)@this.PaddingBottom * scale), (int)((double)@this.PaddingRight * scale));
		@this.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			if (lp.Width >= 0)
			{
				lp.Width = (int)((double)lp.Width * scale);
			}
			if (lp.Height >= 0)
			{
				lp.Height = (int)((double)lp.Height * scale);
			}
			lp.SetMargins((int)((double)lp.LeftMargin * scale), (int)((double)lp.TopMargin * scale), (int)((double)lp.RightMargin * scale), (int)((double)lp.BottomMargin * scale));
		});
		if (@this is ViewGroup viewGroup)
		{
			for (int num = 0; num < viewGroup.ChildCount; num++)
			{
				viewGroup.GetChildAt(num)?.ScaleLayoutDimensions(scale);
			}
		}
		return @this;
	}

	public static IDisposable SetOnClickListenerSafe(this View view, ViewOnClickListener listener)
	{
		view.SetOnClickListener(listener);
		return Disposable.Create(delegate
		{
			view.SetOnClickListener(null);
			listener?.Dispose();
		});
	}

	public static IDisposable OnClick(this View @this, Action handler)
	{
		return @this.OnClick((EventHandler)delegate
		{
			handler();
		});
	}

	public static IDisposable OnClick(this View @this, EventHandler handler)
	{
		@this.Click += handler;
		return Disposable.Create(delegate
		{
			@this.Click -= handler;
		});
	}

	public static IDisposable OnFocusChange(this View @this, Action handler)
	{
		return @this.OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnFocusChange(this View @this, EventHandler<View.FocusChangeEventArgs> handler)
	{
		@this.FocusChange += handler;
		return Disposable.Create(delegate
		{
			@this.FocusChange -= handler;
		});
	}

	public static IDisposable OnTouch(this View @this, Action handler)
	{
		return @this.OnTouch((EventHandler<View.TouchEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnTouch(this View @this, EventHandler<View.TouchEventArgs> handler)
	{
		@this.Touch += handler;
		return Disposable.Create(delegate
		{
			@this.Touch -= handler;
		});
	}

	public static IDisposable OnScrollChange(this View @this, Action handler)
	{
		return @this.OnScrollChange((EventHandler<View.ScrollChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnScrollChange(this View @this, EventHandler<View.ScrollChangeEventArgs> handler)
	{
		@this.ScrollChange += handler;
		return Disposable.Create(delegate
		{
			@this.ScrollChange -= handler;
		});
	}

	public static IDisposable OnScrollChange(this ViewTreeObserver @this, Action handler)
	{
		return @this.OnScrollChange((EventHandler)delegate
		{
			handler();
		});
	}

	public static IDisposable OnScrollChange(this ViewTreeObserver @this, EventHandler handler)
	{
		@this.ScrollChanged += handler;
		return Disposable.Create(delegate
		{
			@this.ScrollChanged -= handler;
		});
	}

	public static IDisposable OnGlobalLayout(this ViewTreeObserver @this, Action handler)
	{
		return @this.OnGlobalLayout((EventHandler)delegate
		{
			handler();
		});
	}

	public static IDisposable OnGlobalLayout(this ViewTreeObserver @this, EventHandler handler)
	{
		@this.GlobalLayout += handler;
		return Disposable.Create(delegate
		{
			if (@this.IsAlive)
			{
				@this.GlobalLayout -= handler;
			}
		});
	}

	public static IDisposable OnLayoutChange(this View @this, Action handler)
	{
		return @this.OnLayoutChange((EventHandler<View.LayoutChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnLayoutChange(this View @this, EventHandler<View.LayoutChangeEventArgs> handler)
	{
		@this.LayoutChange += handler;
		return Disposable.Create(delegate
		{
			@this.LayoutChange -= handler;
		});
	}

	public static IDisposable OnViewDetachedFromWindow(this View @this, EventHandler<View.ViewDetachedFromWindowEventArgs> handler)
	{
		@this.ViewDetachedFromWindow += handler;
		return Disposable.Create(delegate
		{
			@this.ViewDetachedFromWindow -= handler;
		});
	}

	public static IDisposable OnViewDetachedFromWindow(this View @this, Action handler)
	{
		return @this.OnViewDetachedFromWindow((EventHandler<View.ViewDetachedFromWindowEventArgs>)delegate
		{
			handler();
		});
	}
}
