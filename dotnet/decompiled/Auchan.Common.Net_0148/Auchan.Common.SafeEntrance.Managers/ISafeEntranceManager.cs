using System.ComponentModel;
using System.Threading.Tasks;
using Auchan.Common.SafeEntrance.Enums;

namespace Auchan.Common.SafeEntrance.Managers;

public interface ISafeEntranceManager : INotifyPropertyChanged
{
	int NumberOfPinCodeReEnters { get; set; }

	bool IsPinCodeCreated { get; }

	bool IsBiometryCreated { get; }

	bool IsBiometryEnabledOnDevice { get; }

	bool PermissionDenied { get; }

	Task CreatePinCodeAsync(string pinCode);

	Task CreateBiometryAsync();

	Task<bool> ValidateEnteredPinCodeAsync(string pinCode);

	bool CanEnterWithBiometry();

	Task<bool> ProcceedWithBiometryAsync();

	Task ForgotPinCodeAsync();

	bool ShouldShowEnterPinCode();

	void MarkForegroundTransitionForSafeEntrance();

	void MarkBackgroundTransitionForSafeEntrance();

	void RemovePinCode();

	void RemoveBiometry();

	BiometryTypes GetCurrentDeviceBiometryType();

	void MarkAuthIsNeeded();

	bool GetAuthIsNeededAndReset();
}
