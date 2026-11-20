using System;
using System.ComponentModel;

namespace Auchan.Common.SafeEntrance.Managers;

public interface ISafeEntranceContext : INotifyPropertyChanged
{
	bool IsPinCodeCreated { get; set; }

	string? PinCode { get; set; }

	int ExtraSafeState { get; set; }

	int CurrentAppVersion { get; set; }

	bool IsUserEnteredForeground { get; set; }

	DateTime UserEnteredBackground { get; set; }

	bool IsBiometryCreated { get; set; }

	int BiometryType { get; set; }
}
