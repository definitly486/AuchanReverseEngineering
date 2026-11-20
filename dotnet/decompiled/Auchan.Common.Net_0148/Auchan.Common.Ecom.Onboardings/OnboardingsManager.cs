using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Onboardings.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Ecom.Onboardings;

internal sealed class OnboardingsManager : IOnboardingsManager
{
	private const string OnboardingsCacheSharedKey = "OnboardingShowCount";

	private const string OnboardingsShownKey = "OnboardingShown-{0}";

	private const string OnboardingsShowCountCacheKey = "OnboardingShowCount-{0}";

	private readonly IOnboardingsRepository _repository;

	private readonly IEcomContext _ecomContext;

	private readonly INavigationContext _navigationContext;

	private readonly IUniversalLinksService _universalLinksService;

	private Dictionary<string, bool> _onboardingsShownMap = new Dictionary<string, bool>();

	public OnboardingsManager(IOnboardingsRepository repository, IEcomContext ecomContext, IUserContext userContext, INavigationContext navigationContext, IUniversalLinksService universalLinksService)
	{
		_repository = repository;
		_ecomContext = ecomContext;
		_navigationContext = navigationContext;
		_universalLinksService = universalLinksService;
		ecomContext.OnPropertyChanges((IEcomContext ec) => ec.ActiveStore).Subscribe(delegate
		{
			ResetShownStatus();
		});
		ecomContext.OnPropertyChanges((IEcomContext ec) => ec.ReceivingMethod).Subscribe(delegate
		{
			ResetShownStatus();
		});
		userContext.AfterLoggedIn += delegate
		{
			ResetShownStatus();
			ResetShowCount();
			return Task.CompletedTask;
		};
	}

	public void PrefetchOnboardings()
	{
		_repository.PrefetchOnboardings();
	}

	public async Task<Result<IReadOnlyList<OnboardingModel>, DomainError>> GetOnboardings(ShowAt position)
	{
		Result<IReadOnlyList<OnboardingModel>, DomainError> result = await _repository.GetOnboardings(position);
		if (result.TryGetValue(out var value))
		{
			IEnumerable<OnboardingModel> source = value.Where((OnboardingModel o) => GetShowCount(o.Id) < o.ShowCount);
			ReceivingMethod receivingMethod = ((_ecomContext.ReceivingMethod != ReceivingMethod.RegionDefault) ? _ecomContext.ReceivingMethod : ReceivingMethod.Pickup);
			if (position != ShowAt.BeforeAuth)
			{
				source = source.Where((OnboardingModel o) => o.ReceivingMethods.Contains(receivingMethod));
			}
			if (value.Any())
			{
				return (Result<IReadOnlyList<OnboardingModel>, DomainError>)(IReadOnlyList<OnboardingModel>)source.ToImmutableList();
			}
			return new NoDataError();
		}
		return result;
	}

	public async Task<bool> ShouldShowOnboardings(ShowAt position)
	{
		if (_navigationContext.IsNavigatedFromStart || _navigationContext.IsNavigating || _navigationContext.IsAwaitingDelayedNavigation || _universalLinksService.IsNavigating || _universalLinksService.IsPreloadingSharedCart)
		{
			return false;
		}
		string key = StringExtensions.Format("OnboardingShown-{0}", position.ToString());
		if (_onboardingsShownMap.ContainsKey(key) && _onboardingsShownMap[key])
		{
			return false;
		}
		Result<IReadOnlyList<OnboardingModel>, DomainError> result = await GetOnboardings(position);
		return result.IsSuccess && result.Value.Any();
	}

	public void OnboardingShown(int id, ShowAt position)
	{
		_onboardingsShownMap[StringExtensions.Format("OnboardingShown-{0}", position.ToString())] = true;
		Preferences.Set($"OnboardingShowCount-{id}", GetShowCount(id) + 1, "OnboardingShowCount");
	}

	private int GetShowCount(int id)
	{
		return Preferences.Get($"OnboardingShowCount-{id}", 0, "OnboardingShowCount");
	}

	private void ResetShownStatus()
	{
		ShowAt[] values = Enum.GetValues<ShowAt>();
		for (int i = 0; i < values.Length; i++)
		{
			ShowAt showAt = values[i];
			_onboardingsShownMap.Remove(StringExtensions.Format("OnboardingShown-{0}", showAt.ToString()));
		}
	}

	private void ResetShowCount()
	{
		Preferences.Clear("OnboardingShowCount");
	}
}
