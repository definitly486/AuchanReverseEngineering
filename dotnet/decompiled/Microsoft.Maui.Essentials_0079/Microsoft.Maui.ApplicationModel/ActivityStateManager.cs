namespace Microsoft.Maui.ApplicationModel;

public static class ActivityStateManager
{
	private static IActivityStateManager? defaultImplementation;

	public static IActivityStateManager Default => defaultImplementation ?? (defaultImplementation = new ActivityStateManagerImplementation());
}
