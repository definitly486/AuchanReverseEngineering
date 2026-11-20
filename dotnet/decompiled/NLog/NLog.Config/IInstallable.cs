namespace NLog.Config;

public interface IInstallable
{
	void Install(InstallationContext installationContext);

	void Uninstall(InstallationContext installationContext);

	bool? IsInstalled(InstallationContext installationContext);
}
