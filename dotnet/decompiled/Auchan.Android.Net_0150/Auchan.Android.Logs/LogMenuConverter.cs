using Android.App;
using Android.Graphics;
using Android.Views;
using AndroidX.Core.Content;

namespace Auchan.Android.Logs;

public static class LogMenuConverter
{
	public static Color ColorFromIsError(bool isErrorEntry)
	{
		if (isErrorEntry)
		{
			return new Color(ContextCompat.GetColor(Application.Context, 2131099841));
		}
		return new Color(ContextCompat.GetColor(Application.Context, 2131099793));
	}

	public static ViewStates ViewStateFromIsError(bool isErrorEntry)
	{
		if (isErrorEntry)
		{
			return ViewStates.Visible;
		}
		return ViewStates.Gone;
	}

	public static ViewStates ViewStateFromIsDescriptionVisible(bool isDescriptionVisible)
	{
		if (isDescriptionVisible)
		{
			return ViewStates.Visible;
		}
		return ViewStates.Gone;
	}
}
