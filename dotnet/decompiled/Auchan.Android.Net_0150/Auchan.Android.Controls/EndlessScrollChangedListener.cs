using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Controls;

public class EndlessScrollChangedListener : RecyclerView.OnScrollListener
{
	private OnLoadMoreListener _onLoadMoreListener;

	public void SetOnLoadMoreListener(OnLoadMoreListener listener)
	{
		_onLoadMoreListener = listener;
	}

	public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
	{
		int num = recyclerView.ComputeVerticalScrollOffset();
		int num2 = recyclerView.ComputeVerticalScrollRange();
		int num3 = recyclerView.ComputeVerticalScrollExtent();
		int num4 = num2 - num3 * 3 / 2;
		if (num > num4)
		{
			_onLoadMoreListener?.OnLoadMore();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_onLoadMoreListener = null;
		}
		base.Dispose(disposing);
	}
}
