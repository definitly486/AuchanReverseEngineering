using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Cache;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet.DomainModels;
using DryIoc;
using Microsoft.Maui.Storage;

namespace Auchan.Common.PersonalCabinet;

public class UserContext : IUserContext, INotifyPropertyChanged
{
	private const string IS_DRIVE_ONBOARDING_SHOWED_CACHE_KEY = "IS_DRIVE_ONBOARDING_SHOWED_CACHE_KEY";

	private const string IS_ONBOARDING_SHOWED_CACHE_KEY = "IS_ONBOARDING_SHOWED_CACHE_KEY";

	private ProfileModel? _profile = PreferencesEx.Get<ProfileModel>("Profile", "UserContextPreferences");

	private readonly Lazy<ICache> _cache;

	[CompilerGenerated]
	private bool _003CIsJustRegistered_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAuthorizedAcrossRegistration_003Ek__BackingField;

	public bool Authorized
	{
		get
		{
			return Preferences.Get("Authorized", defaultValue: false, "UserContextPreferences");
		}
		set
		{
			if (Authorized != value)
			{
				Preferences.Set("Authorized", value, "UserContextPreferences");
				OnPropertyChanged("Authorized");
			}
		}
	}

	public bool IsSignupWasShown
	{
		get
		{
			return Preferences.Get("IsSignupWasShown", defaultValue: false, "UserContextPreferences");
		}
		set
		{
			if (IsSignupWasShown != value)
			{
				Preferences.Set("IsSignupWasShown", value, "UserContextPreferences");
				OnPropertyChanged("IsSignupWasShown");
			}
		}
	}

	public bool IsFirstTimeLogin
	{
		get
		{
			return Preferences.Get("IsFirstTimeLogin", defaultValue: true);
		}
		set
		{
			if (IsFirstTimeLogin != value)
			{
				Preferences.Set("IsFirstTimeLogin", value);
				OnPropertyChanged("IsFirstTimeLogin");
			}
		}
	}

	public bool IsJustRegistered
	{
		[CompilerGenerated]
		get
		{
			return _003CIsJustRegistered_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsJustRegistered_003Ek__BackingField != value)
			{
				_003CIsJustRegistered_003Ek__BackingField = value;
				OnPropertyChanged("IsJustRegistered");
			}
		}
	}

	public ProfileModel? Profile
	{
		get
		{
			return _profile;
		}
		set
		{
			if (!object.Equals(_profile, value))
			{
				_profile = PreferencesEx.Set("Profile", value, "UserContextPreferences");
				OnPropertyChanged("Profile");
			}
		}
	}

	public int LoyaltyTriggersTimesShown
	{
		get
		{
			return Preferences.Get("LoyaltyTriggersTimesShown", 0, "UserContextPreferences");
		}
		set
		{
			if (LoyaltyTriggersTimesShown != value)
			{
				Preferences.Set("LoyaltyTriggersTimesShown", value, "UserContextPreferences");
				OnPropertyChanged("LoyaltyTriggersTimesShown");
			}
		}
	}

	public int PhoneStatus
	{
		get
		{
			return Preferences.Get("PhoneStatus", -1, "UserContextPreferences");
		}
		set
		{
			if (PhoneStatus != value)
			{
				Preferences.Set("PhoneStatus", value, "UserContextPreferences");
				OnPropertyChanged("PhoneStatus");
			}
		}
	}

	public LoyaltyCardEntity? LoyaltyCard
	{
		get
		{
			return PreferencesEx.Get<LoyaltyCardEntity>("LoyaltyCard", "UserContextPreferences");
		}
		set
		{
			if (!object.Equals(LoyaltyCard, value))
			{
				PreferencesEx.Set("LoyaltyCard", value, "UserContextPreferences");
				OnPropertyChanged("LoyaltyCard");
			}
		}
	}

	public List<string>? LoyaltyProgramSegments
	{
		get
		{
			return PreferencesEx.Get<List<string>>("LoyaltyProgramSegments", "UserContextPreferences");
		}
		set
		{
			if (!object.Equals(LoyaltyProgramSegments, value))
			{
				PreferencesEx.Set("LoyaltyProgramSegments", value, "UserContextPreferences");
				OnPropertyChanged("LoyaltyProgramSegments");
			}
		}
	}

	public string UserGUID => PreferencesEx.Get<string>("UserGUID", "UserContextPreferences") ?? GenerateUserGUID();

	public string SessionId => PreferencesEx.Get<string>("SessionId", "UserContextPreferences") ?? GenerateSessionId();

	public bool IsAuthorizedAcrossRegistration
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAuthorizedAcrossRegistration_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsAuthorizedAcrossRegistration_003Ek__BackingField != value)
			{
				_003CIsAuthorizedAcrossRegistration_003Ek__BackingField = value;
				OnPropertyChanged("IsAuthorizedAcrossRegistration");
			}
		}
	}

	public event Func<Task> AfterLoggedIn = () => Task.CompletedTask;

	public event Func<Task> AfterLoggedOut = () => Task.CompletedTask;

	public event Func<Task> BeforeLoggedOut = () => Task.CompletedTask;

	public event PropertyChangedEventHandler? PropertyChanged;

	public UserContext(Lazy<ICache> cache)
	{
		_cache = cache;
		GenerateSessionId();
	}

	public void UpdateProfileWithNotify(ProfileModel? profile, bool needUpdateEmployeeStatus = false)
	{
		ProfileModel? profile2 = _profile;
		if (profile2 != null && profile2.IsAuchanEmployee && profile != null && !needUpdateEmployeeStatus)
		{
			profile.IsAuchanEmployee = true;
		}
		_profile = PreferencesEx.Set("Profile", profile, "UserContextPreferences");
		OnPropertyChanged("Profile");
	}

	public async Task LogIn()
	{
		AppAnalytics.AppMetrica.TrackEvent("authorisationSuccess");
		Authorized = true;
		GenerateSessionId();
		await Task.WhenAll((from t in this.AfterLoggedIn.GetInvocationList().OfType<Func<Task>>()
			select t()).ToArray());
		await CleanCache();
	}

	public async Task LogOut()
	{
		Preferences.Set("IS_DRIVE_ONBOARDING_SHOWED_CACHE_KEY", value: false);
		Preferences.Set("IS_ONBOARDING_SHOWED_CACHE_KEY", value: false);
		await Task.WhenAll((from t in this.BeforeLoggedOut.GetInvocationList().OfType<Func<Task>>()
			select t()).ToArray());
		Authorized = false;
		LoyaltyCard = new LoyaltyCardEntity
		{
			CardNumber = null,
			CardStatus = LoyaltyCardStatus.None,
			Cvc = null,
			EPointsAmount = 0m,
			StampsAmount = 0m,
			PointsAmount = 0m,
			QrCode = null
		};
		Preferences.Clear("UserContextPreferences");
		await CleanCache();
		ITokenService tokenService = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ITokenService>();
		IPriceCheckerContext priceCheckerContext = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IPriceCheckerContext>();
		await Task.WhenAll(tokenService.ClearTokens(), priceCheckerContext.CleanDeinitialize());
		_profile = null;
		IsJustRegistered = false;
		await Task.WhenAll((from t in this.AfterLoggedOut.GetInvocationList().OfType<Func<Task>>()
			select t()).ToArray());
	}

	private Task CleanCache()
	{
		return _cache.Value.Remove("CachedPhone", "CachedEmail", "CachedSignUpData", "CachedPurchaseHistory", "CachedLoyaltyCardEntity");
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private string GenerateUserGUID()
	{
		return PreferencesEx.Set("UserGUID", $"0:{((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToBase36()}:{Guid.NewGuid()}", TimeSpan.FromDays(365), "UserContextPreferences");
	}

	private string GenerateSessionId()
	{
		return PreferencesEx.Set("SessionId", Guid.NewGuid().ToString(), TimeSpan.FromMinutes(30L), "UserContextPreferences");
	}
}
