using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public static class Launcher
{
	private static ILauncher? defaultImplementation;

	private static ILauncher Current => Default;

	public static ILauncher Default => defaultImplementation ?? (defaultImplementation = new LauncherImplementation());

	public static Task<bool> OpenAsync(string uri)
	{
		return Current.OpenAsync(uri);
	}

	public static Task<bool> TryOpenAsync(Uri uri)
	{
		return Current.TryOpenAsync(uri);
	}
}
