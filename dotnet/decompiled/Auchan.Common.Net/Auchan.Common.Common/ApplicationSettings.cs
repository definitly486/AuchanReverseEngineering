using Microsoft.Maui.Storage;

namespace Auchan.Common.Common;

public class ApplicationSettings : IApplicationSettings
{
	private const string PREFERENCES_NAME = "ApplicationSharedPreferences";

	public bool IsEmployeeOnboardingShowed
	{
		get
		{
			return Preferences.Get("IsEmployeeOnboardingShowed", defaultValue: false, "ApplicationSharedPreferences");
		}
		set
		{
			Preferences.Set("IsEmployeeOnboardingShowed", value, "ApplicationSharedPreferences");
		}
	}

	public bool IsLocationDialogShown
	{
		get
		{
			return Preferences.Get("IsLocationDialogShown", defaultValue: false, "ApplicationSharedPreferences");
		}
		set
		{
			Preferences.Set("IsLocationDialogShown", value, "ApplicationSharedPreferences");
		}
	}

	public void Reset()
	{
		Preferences.Clear("ApplicationSharedPreferences");
	}
}
