using System;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Controls;

public class SectionedGridSpanSizeLookup : GridLayoutManager.SpanSizeLookup
{
	private GridLayoutManager _gridLayoutManager;

	private Func<int, bool> _isSectionHeaderPosition;

	public SectionedGridSpanSizeLookup(GridLayoutManager gridLayoutManager, Func<int, bool> isSectionHeaderPosition)
	{
		_gridLayoutManager = gridLayoutManager;
		_isSectionHeaderPosition = isSectionHeaderPosition;
	}

	public override int GetSpanSize(int position)
	{
		if (!_isSectionHeaderPosition(position))
		{
			return 1;
		}
		return _gridLayoutManager.SpanCount;
	}
}
