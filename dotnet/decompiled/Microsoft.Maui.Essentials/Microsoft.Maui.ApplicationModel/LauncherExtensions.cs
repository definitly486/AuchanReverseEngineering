using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public static class LauncherExtensions
{
	public static Task<bool> OpenAsync(this ILauncher launcher, string uri)
	{
		return launcher.OpenAsync(new Uri(uri));
	}
}
