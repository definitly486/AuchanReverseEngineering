namespace Microsoft.Maui.ApplicationModel;

public static class AppInfo
{
	private static IAppInfo? currentImplementation;

	public static string PackageName => Current.PackageName;

	public static string VersionString => Current.VersionString;

	public static string BuildString => Current.BuildString;

	public static IAppInfo Current => currentImplementation ?? (currentImplementation = new AppInfoImplementation());

	public static void ShowSettingsUI()
	{
		Current.ShowSettingsUI();
	}
}
