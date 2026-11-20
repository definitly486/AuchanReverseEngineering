using System;

namespace Auchan.Android.Controls;

public class OnLoadMoreListener
{
	private readonly Action _onLoadMore;

	public OnLoadMoreListener(Action onLoadMore)
	{
		_onLoadMore = onLoadMore;
	}

	public void OnLoadMore()
	{
		_onLoadMore();
	}
}
