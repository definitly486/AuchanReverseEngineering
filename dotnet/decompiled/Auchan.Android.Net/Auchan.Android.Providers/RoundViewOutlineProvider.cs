using Android.Graphics;
using Android.Views;

namespace Auchan.Android.Providers;

public class RoundViewOutlineProvider : ViewOutlineProvider
{
	private readonly float _radius;

	public RoundViewOutlineProvider(float radius)
	{
		_radius = radius;
	}

	public override void GetOutline(View view, Outline outline)
	{
		if (view != null)
		{
			outline?.SetRoundRect(0, 0, view.MeasuredWidth, view.MeasuredHeight, _radius);
		}
	}
}
