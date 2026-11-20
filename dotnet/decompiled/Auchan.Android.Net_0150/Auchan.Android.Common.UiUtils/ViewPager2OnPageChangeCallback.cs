using System;
using AndroidX.ViewPager2.Widget;

namespace Auchan.Android.Common.UiUtils;

public class ViewPager2OnPageChangeCallback : ViewPager2.OnPageChangeCallback
{
	private readonly Action<int>? _pageSelected;

	private readonly Action<int, float, int>? _pageScrolled;

	private readonly Action<int>? _pageScrollStateChanged;

	public ViewPager2OnPageChangeCallback(Action<int>? pageSelected = null, Action<int, float, int>? pageScrolled = null, Action<int>? pageScrollStateChanged = null)
	{
		_pageSelected = pageSelected;
		_pageScrolled = pageScrolled;
		_pageScrollStateChanged = pageScrollStateChanged;
	}

	public override void OnPageSelected(int position)
	{
		_pageSelected?.Invoke(position);
	}

	public override void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
	{
		_pageScrolled?.Invoke(position, positionOffset, positionOffsetPixels);
	}

	public override void OnPageScrollStateChanged(int state)
	{
		_pageScrollStateChanged?.Invoke(state);
	}
}
