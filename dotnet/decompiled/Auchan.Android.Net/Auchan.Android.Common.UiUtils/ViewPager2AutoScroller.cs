using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Runtime;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using AndroidX.ViewPager2.Widget;
using Auchan.Common.Helpers;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class ViewPager2AutoScroller : Java.Lang.Object, View.IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly List<ViewPager2> _viewPagers = new List<ViewPager2>();

	private IDisposable? _autoScrollDisposable;

	public Func<RecyclerView.Adapter, int> InitialPosition { get; set; } = (RecyclerView.Adapter _) => 0;

	public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(3L);

	public TimeSpan InterruptedDelay { get; set; } = TimeSpan.FromSeconds(3L);

	public ViewPager2AutoScroller(ViewPager2? viewPager = null)
	{
		if (viewPager != null)
		{
			_viewPagers.Add(viewPager);
		}
		Start(Interval);
	}

	public void Start(TimeSpan? initialInterval = null)
	{
		Stop();
		_autoScrollDisposable = Observable.Timer(initialInterval ?? Interval).Concat(Observable.Interval(Interval)).ObserveOn(MainThread.Scheduler)
			.Subscribe(delegate
			{
				foreach (ViewPager2 viewPager in _viewPagers)
				{
					int currentItem = viewPager.CurrentItem;
					int num = ((currentItem < viewPager.Adapter.ItemCount - 1) ? (currentItem + 1) : InitialPosition(viewPager.Adapter));
					if (IsVisible(viewPager))
					{
						viewPager.SetCurrentItem(num, System.Math.Abs(num - currentItem) == 1);
					}
				}
			});
	}

	private bool IsVisible(View pager)
	{
		int[] array = new int[2];
		pager.GetLocationOnScreen(array);
		int num = array[1];
		int heightPixels = pager.Context.Resources.DisplayMetrics.HeightPixels;
		bool flag = num > 0 && num < heightPixels;
		bool flag2 = num + pager.Height > 0 && num + pager.Height <= heightPixels;
		if (num != 0)
		{
			return flag || flag2;
		}
		return false;
	}

	public void Stop()
	{
		_autoScrollDisposable?.Dispose();
	}

	public bool OnTouch(View v, MotionEvent e)
	{
		switch (e.Action)
		{
		case MotionEventActions.Down:
			Stop();
			break;
		case MotionEventActions.Up:
		case MotionEventActions.Cancel:
			Start(InterruptedDelay);
			break;
		}
		return true;
	}

	public IDisposable AddPagerForSimultaneouslyScrolling(ViewPager2 pager)
	{
		_viewPagers.Add(pager);
		return Disposable.Create(delegate
		{
			_viewPagers.Remove(pager);
		});
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		_viewPagers.Clear();
		Stop();
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
