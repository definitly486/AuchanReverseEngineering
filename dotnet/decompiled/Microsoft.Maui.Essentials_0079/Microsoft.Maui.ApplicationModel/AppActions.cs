namespace Microsoft.Maui.ApplicationModel;

public static class AppActions
{
	private static IAppActions? currentImplementation;

	public static IAppActions Current => currentImplementation ?? (currentImplementation = new AppActionsImplementation());
}
