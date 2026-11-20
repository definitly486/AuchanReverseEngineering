using System;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Google.Android.Material.AppBar;
using Microsoft.Maui.Devices;

namespace Auchan.Android.Common.ScrollListeners;

internal class GoToTopButtonScrollListener : RecyclerView.OnScrollListener
{
	private const float ScreenMultiplierToShowButton = 0.2f;

	private const float ScreenMultilpierToHideButton = 0.05f;

	protected readonly View _button;

	protected readonly AppBarLayout? _appBarLayout;

	private readonly Action _buttonShowAction;

	private readonly Action _buttonHideAction;

	protected bool _isAutoScrollingToTop;

	private int _scrollUpDistance;

	private int _scrollDownDistance;

	protected readonly double _screenHeight = DeviceDisplay.MainDisplayInfo.Height;

	private bool IsButtonVisible => _button.Visibility == ViewStates.Visible;

	public bool IsAutoScrollingToTop => _isAutoScrollingToTop;

	public bool IsEnabled { get; set; } = true;

	public GoToTopButtonScrollListener(View button, Action buttonShowAction, Action buttonHideAction, AppBarLayout? appBarLayout = null)
	{
		if (button == null || buttonShowAction == null || buttonHideAction == null)
		{
			throw new ArgumentNullException();
		}
		_button = button;
		_appBarLayout = appBarLayout;
		_buttonShowAction = buttonShowAction;
		_buttonHideAction = buttonHideAction;
	}

	public void SetAutoScrollingToTop()
	{
		_isAutoScrollingToTop = true;
	}

	public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
	{
		if (!IsEnabled)
		{
			return;
		}
		int num = recyclerView.ComputeVerticalScrollOffset();
		if (num == 0)
		{
			if (IsAutoScrollingToTop)
			{
				_appBarLayout?.SetExpanded(expanded: true, animate: true);
			}
			_isAutoScrollingToTop = false;
			HideButtonIfNeeded();
		}
		else if (!((double)num < _screenHeight))
		{
			if (dy > 0)
			{
				CheckScrollDown(dy);
			}
			else
			{
				CheckScrollUp(dy);
			}
		}
	}

	protected void HideButtonIfNeeded()
	{
		if (IsButtonVisible)
		{
			_buttonHideAction?.Invoke();
		}
	}

	protected void ShowButtonIfNeeded()
	{
		if (!IsButtonVisible)
		{
			_buttonShowAction?.Invoke();
		}
	}

	private void CheckScrollDown(int dy)
	{
		_isAutoScrollingToTop = false;
		if (IsButtonVisible)
		{
			_scrollDownDistance += dy;
			if (!((double)_scrollDownDistance < _screenHeight * 0.05000000074505806))
			{
				HideButtonIfNeeded();
				_scrollUpDistance = 0;
				_scrollDownDistance = 0;
			}
		}
	}

	private void CheckScrollUp(int dy)
	{
		if (!IsButtonVisible && !_isAutoScrollingToTop)
		{
			_scrollUpDistance += Math.Abs(dy);
			if (!((double)_scrollUpDistance < _screenHeight * 0.20000000298023224))
			{
				ShowButtonIfNeeded();
				_scrollUpDistance = 0;
				_scrollDownDistance = 0;
			}
		}
	}
}
