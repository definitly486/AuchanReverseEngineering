using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.Tags;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Extensions;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.LoyaltyProgram.Managers;

public class LoyaltyPersonalizedGreetingManager : ILoyaltyPersonalizedGreetingsManager, INotifyPropertyChanged
{
	private const string LoyaltyGreetingShouldBeShownKey = "LoyaltyGreetingShouldBeShownKey";

	private readonly IUserContext _userContext;

	private readonly ILoyaltyPersonalizedGreetingsService _personalizedGreetingsService;

	private readonly ITagsReplacer _tagsReplacer;

	private readonly INavigationContext _navigationContext;

	private readonly LoyaltyUserCategoriesEntity _userCategories;

	private LoyaltyPersonalizedGreetingEntity _cachedGreeting;

	[CompilerGenerated]
	private bool _003CGreetingShouldBeShownNow_003Ek__BackingField;

	private bool GreetingShouldBeShownToUserCategory
	{
		get
		{
			if (!_userCategories.IsOldUser)
			{
				return _userCategories.IsRetired;
			}
			return true;
		}
	}

	private bool GreetingShouldBeShownNow
	{
		[CompilerGenerated]
		get
		{
			return _003CGreetingShouldBeShownNow_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CGreetingShouldBeShownNow_003Ek__BackingField != value)
			{
				_003CGreetingShouldBeShownNow_003Ek__BackingField = value;
				OnPropertyChanged("GreetingShouldBeShown");
				OnPropertyChanged("GreetingShouldBeShownNow");
			}
		}
	} = true;

	public ILoyaltyPersonalizedGreetingsManager.GreetingType GreetingFor
	{
		get
		{
			if (!_userCategories.IsRetired)
			{
				return ILoyaltyPersonalizedGreetingsManager.GreetingType.ExistingCustomer;
			}
			return ILoyaltyPersonalizedGreetingsManager.GreetingType.Retired;
		}
	}

	public bool GreetingShouldBeShown
	{
		get
		{
			if (IsGreetingShouldBeShown && GreetingShouldBeShownToUserCategory)
			{
				return GreetingShouldBeShownNow;
			}
			return false;
		}
	}

	private bool IsGreetingShouldBeShown => Preferences.Get("LoyaltyGreetingShouldBeShownKey", defaultValue: false);

	public event PropertyChangedEventHandler? PropertyChanged;

	public LoyaltyPersonalizedGreetingManager(IUserContext userContext, ILoyaltyPersonalizedGreetingsService personalizedGreetingsService, ITagsReplacer tagsReplacer, INavigationContext navigationContext)
	{
		_userContext = userContext;
		_personalizedGreetingsService = personalizedGreetingsService;
		_tagsReplacer = tagsReplacer;
		_userCategories = new LoyaltyUserCategoriesEntity();
		_cachedGreeting = GetDefaultGreeting();
		_navigationContext = navigationContext;
	}

	public void TrySetupGreetingForOldUsers()
	{
		bool isOldUser = _userContext.PhoneStatus != 1;
		_userCategories.IsOldUser = isOldUser;
	}

	public void TrySetupGreetingForRetiredUsers()
	{
		bool isRetired = _userContext.Profile?.IsRetiredUser() ?? false;
		_userCategories.IsRetired = isRetired;
	}

	public void SetGreetingShouldBeShown(bool shouldBeShown)
	{
		Preferences.Set("LoyaltyGreetingShouldBeShownKey", shouldBeShown);
		OnPropertyChanged("GreetingShouldBeShown");
	}

	public async Task LoadGreetingsToCacheIfNeeded()
	{
		if (_navigationContext.IsNavigating || _navigationContext.IsNavigatedFromStart)
		{
			GreetingShouldBeShownNow = false;
		}
		if (!GreetingShouldBeShown)
		{
			return;
		}
		Result<IEnumerable<LoyaltyProgramGreetingDto>, DomainError> result = await _personalizedGreetingsService.GetGreetingAsync(_userCategories);
		if (!result.IsFailure)
		{
			LoyaltyProgramGreetingDto loyaltyProgramGreetingDto = result.Value.OrderBy((LoyaltyProgramGreetingDto greeting) => greeting.Priority).FirstOrDefault();
			if (loyaltyProgramGreetingDto != null)
			{
				loyaltyProgramGreetingDto.Title = _tagsReplacer.Replace(loyaltyProgramGreetingDto.Title);
				loyaltyProgramGreetingDto.Description = _tagsReplacer.Replace(loyaltyProgramGreetingDto.Description);
				_cachedGreeting = loyaltyProgramGreetingDto.Map();
			}
		}
	}

	public LoyaltyPersonalizedGreetingEntity GetPersonalizedGreeting()
	{
		return _cachedGreeting;
	}

	private LoyaltyPersonalizedGreetingEntity GetDefaultGreeting()
	{
		return new LoyaltyPersonalizedGreetingEntity("Спасибо, что присоединились к программе лояльности", "");
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
