using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Auchan.Common.Extensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.SafeEntrance.Managers;

public class SafeEntranceContext : ISafeEntranceContext, INotifyPropertyChanged
{
	private string? _pinCode => PreferencesEx.Get<string>("PinCode", "UserContextPreferences");

	public bool IsPinCodeCreated
	{
		get
		{
			return Preferences.Get("IsPinCodeCreated", defaultValue: false, "UserContextPreferences");
		}
		set
		{
			if (IsPinCodeCreated != value)
			{
				Preferences.Set("IsPinCodeCreated", value, "UserContextPreferences");
				OnPropertyChanged("IsPinCodeCreated");
			}
		}
	}

	public int ExtraSafeState
	{
		get
		{
			return Preferences.Get("ExtraSafeState", 0, "UserContextPreferences");
		}
		set
		{
			if (ExtraSafeState != value)
			{
				Preferences.Set("ExtraSafeState", value, "UserContextPreferences");
				OnPropertyChanged("ExtraSafeState");
			}
		}
	}

	public string? PinCode
	{
		get
		{
			return _pinCode;
		}
		set
		{
			if (!string.Equals(PinCode, value, StringComparison.Ordinal))
			{
				PreferencesEx.Set("PinCode", value, "UserContextPreferences");
				OnPropertyChanged("PinCode");
			}
		}
	}

	public int CurrentAppVersion
	{
		get
		{
			return Preferences.Get("CurrentAppVersion", 0, "UserContextPreferences");
		}
		set
		{
			if (CurrentAppVersion != value)
			{
				PreferencesEx.Set("CurrentAppVersion", value, "UserContextPreferences");
				OnPropertyChanged("CurrentAppVersion");
			}
		}
	}

	public bool IsUserEnteredForeground
	{
		get
		{
			return Preferences.Get("IsUserEnteredForeground", defaultValue: false, "UserContextPreferences");
		}
		set
		{
			if (IsUserEnteredForeground != value)
			{
				Preferences.Set("IsUserEnteredForeground", value, "UserContextPreferences");
				OnPropertyChanged("IsUserEnteredForeground");
			}
		}
	}

	public DateTime UserEnteredBackground
	{
		get
		{
			return Preferences.Get("UserEnteredBackground", DateTime.Now, "UserContextPreferences");
		}
		set
		{
			if (!DateTime.Equals(UserEnteredBackground, value))
			{
				Preferences.Set("UserEnteredBackground", value, "UserContextPreferences");
				OnPropertyChanged("UserEnteredBackground");
			}
		}
	}

	public bool IsBiometryCreated
	{
		get
		{
			return Preferences.Get("IsBiometryCreated", defaultValue: false, "UserContextPreferences");
		}
		set
		{
			if (IsBiometryCreated != value)
			{
				Preferences.Set("IsBiometryCreated", value, "UserContextPreferences");
				OnPropertyChanged("IsBiometryCreated");
			}
		}
	}

	public int BiometryType
	{
		get
		{
			return Preferences.Get("BiometryType", 0, "UserContextPreferences");
		}
		set
		{
			if (BiometryType != value)
			{
				Preferences.Set("BiometryType", value, "UserContextPreferences");
				OnPropertyChanged("BiometryType");
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
