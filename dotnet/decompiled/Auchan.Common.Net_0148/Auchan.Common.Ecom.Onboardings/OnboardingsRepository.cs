using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Onboardings.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Onboardings;

internal sealed class OnboardingsRepository : IOnboardingsRepository
{
	private readonly IOnboardingsService _onboardingsService;

	private volatile Task<Result<IReadOnlyDictionary<ShowAt, IReadOnlyList<OnboardingModel>>, DomainError>>? _prefetch;

	private IReadOnlyDictionary<ShowAt, IReadOnlyList<OnboardingModel>> _onboardings = FrozenDictionary<ShowAt, IReadOnlyList<OnboardingModel>>.Empty;

	public OnboardingsRepository(IOnboardingsService onboardingsService, IEcomContext ecomContext, IUserContext userContext, IHomeScreenTracker homeScreenTracker)
	{
		_onboardingsService = onboardingsService;
		homeScreenTracker.OnShown += delegate
		{
			_prefetch = null;
		};
		ecomContext.OnPropertyChanges((IEcomContext ec) => ec.ActiveStore).Subscribe(delegate
		{
			_onboardings = FrozenDictionary<ShowAt, IReadOnlyList<OnboardingModel>>.Empty;
		});
		userContext.AfterLoggedIn += delegate
		{
			_onboardings = FrozenDictionary<ShowAt, IReadOnlyList<OnboardingModel>>.Empty;
			return Task.CompletedTask;
		};
	}

	public void PrefetchOnboardings()
	{
		_prefetch = Task.Run(() => _onboardingsService.GetOnboardings());
	}

	public async Task<Result<IReadOnlyList<OnboardingModel>, DomainError>> GetOnboardings(ShowAt showAt)
	{
		if (_onboardings.Any() && _onboardings.TryGetValue(showAt, out IReadOnlyList<OnboardingModel> value))
		{
			return Result.Success<IReadOnlyList<OnboardingModel>, DomainError>(value);
		}
		if ((await (_prefetch ?? _onboardingsService.GetOnboardings())).TryGetValue(out var value2))
		{
			_onboardings = value2;
			if (value2.TryGetValue(showAt, out value))
			{
				return Result.Success<IReadOnlyList<OnboardingModel>, DomainError>(value);
			}
		}
		return Result.Success<IReadOnlyList<OnboardingModel>, DomainError>(Array.Empty<OnboardingModel>());
	}
}
