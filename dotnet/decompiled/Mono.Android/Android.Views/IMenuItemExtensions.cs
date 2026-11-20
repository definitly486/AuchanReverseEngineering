using Java.Lang;

namespace Android.Views;

public static class IMenuItemExtensions
{
	public static IMenuItem SetTitle(this IMenuItem self, string? title)
	{
		String obj = ((title == null) ? null : new String(title));
		IMenuItem result = self.SetTitle(obj);
		obj?.Dispose();
		return result;
	}
}
