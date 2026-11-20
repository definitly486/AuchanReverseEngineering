using Android.Widget;

namespace Auchan.Android.Reviews;

public class StarView
{
	public enum Style
	{
		Gold,
		HalfGrey,
		Grey
	}

	public ImageView StarImageView { get; }

	public StarView(ImageView starImageView, Style style = Style.Grey)
	{
		StarImageView = starImageView;
		SetStyle(style);
	}

	public void SetStyle(Style style)
	{
		StarImageView.SetImageResource(style switch
		{
			Style.Gold => 2131231374, 
			Style.HalfGrey => 2131231376, 
			_ => 2131231375, 
		});
	}
}
