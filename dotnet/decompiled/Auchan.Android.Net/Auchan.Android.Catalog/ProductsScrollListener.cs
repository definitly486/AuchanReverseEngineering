using System;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Catalog;

public class ProductsScrollListener(Action callback = null) : RecyclerView.OnScrollListener()
{
	public event Action<int> VisibilityChanged;

	public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
	{
		if (recyclerView.GetLayoutManager() is GridLayoutManager gridLayoutManager)
		{
			int obj = gridLayoutManager.FindLastCompletelyVisibleItemPosition();
			this.VisibilityChanged?.Invoke(obj);
		}
		callback?.Invoke();
	}
}
