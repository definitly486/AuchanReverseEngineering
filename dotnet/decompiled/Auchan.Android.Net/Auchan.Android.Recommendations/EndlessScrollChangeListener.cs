using System;
using Android.Content.Res;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Recommendations;

internal class EndlessScrollChangeListener(Action onLoadMore, Action<int, int, int>? onScrollChanged = null) : RecyclerView.OnScrollListener()
{
	public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
	{
		base.OnScrolled(recyclerView, dx, dy);
		int num = recyclerView.ComputeVerticalScrollOffset();
		int num2 = recyclerView.ComputeVerticalScrollRange();
		if (recyclerView.ChildCount != 0)
		{
			int valueOrDefault = (Resources.System?.DisplayMetrics?.HeightPixels).GetValueOrDefault();
			if (num2 - num < valueOrDefault)
			{
				onLoadMore?.Invoke();
			}
			onScrollChanged?.Invoke(num, dx, dy);
		}
	}
}
