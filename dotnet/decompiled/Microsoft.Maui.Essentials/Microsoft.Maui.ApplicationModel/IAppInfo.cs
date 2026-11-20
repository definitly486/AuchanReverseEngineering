namespace Microsoft.Maui.ApplicationModel;

public interface IAppInfo
{
	string PackageName { get; }

	string VersionString { get; }

	string BuildString { get; }

	void ShowSettingsUI();
}
