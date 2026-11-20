using System;
using AndroidX.RecyclerView.Widget;

namespace ViewSparsedRecycler;

public class DelegateSpanSizeLookup : GridLayoutManager.SpanSizeLookup
{
	private readonly Func<int, int> _spanForPositionDelegate;

	public DelegateSpanSizeLookup(Func<int, int> spanForPosition)
	{
		_spanForPositionDelegate = spanForPosition;
	}

	public override int GetSpanSize(int position)
	{
		return _spanForPositionDelegate(position);
	}
}
