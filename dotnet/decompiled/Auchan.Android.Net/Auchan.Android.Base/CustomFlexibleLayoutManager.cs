using Android.Content;
using Google.Flexbox;

namespace Auchan.Android.Base;

public class CustomFlexibleLayoutManager : FlexboxLayoutManager
{
	private readonly bool _isScrollable;

	public CustomFlexibleLayoutManager(Context context, int flexDirection, bool isScrollable)
		: base(context, flexDirection)
	{
		_isScrollable = isScrollable;
	}

	public override bool CanScrollVertically()
	{
		if (base.CanScrollVertically())
		{
			return _isScrollable;
		}
		return false;
	}

	public override bool CanScrollHorizontally()
	{
		if (base.CanScrollHorizontally())
		{
			return _isScrollable;
		}
		return false;
	}
}
