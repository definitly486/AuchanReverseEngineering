namespace Auchan.Common.Common;

public interface IApplicationSettings
{
	bool IsEmployeeOnboardingShowed { get; set; }

	bool IsLocationDialogShown { get; set; }

	void Reset();
}
