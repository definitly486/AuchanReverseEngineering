using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Onboardings.DTO;
using Auchan.Common.Ecom.Onboardings.Infrastructure;
using Auchan.Common.Ecom.Onboardings.Models;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Ecom.Onboardings;

internal sealed class OnboardingsService : IOnboardingsService
{
	private readonly IResolver _resolver;

	private readonly Lazy<ITokenService> _tokenService;

	private readonly Lazy<IOnbardingsApi> _onbardingsApi;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private readonly Lazy<IEcomContext> _ecomContext;

	public OnboardingsService(IResolver resolver, Lazy<ITokenService> tokenService, Lazy<IOnbardingsApi> onbardingsApi, Lazy<IRequestExecutor> requestExecutor, Lazy<IEcomContext> ecomContext)
	{
		_resolver = resolver;
		_tokenService = tokenService;
		_onbardingsApi = onbardingsApi;
		_requestExecutor = requestExecutor;
		_ecomContext = ecomContext;
	}

	public async Task<Result<IReadOnlyDictionary<ShowAt, IReadOnlyList<OnboardingModel>>, DomainError>> GetOnboardings(CancellationToken cancellationToken = default(CancellationToken))
	{
		_ = 1;
		OnboardingsRequestDto.OperatingSystemDto operatingSystem = OnboardingsRequestDto.OperatingSystemDto.Android;
		if (!(await _tokenService.Value.SavedToken80()).TryGetValue(out var tokenModel))
		{
			tokenModel = null;
		}
		Result<OnboardingsResponseDto, ServiceError> result = await _requestExecutor.Value.Execute((CancellationToken ct) => _onbardingsApi.Value.GetOnboardingsAsync(tokenModel?.Token, new OnboardingsRequestDto
		{
			Filter = new OnboardingsRequestDto.FilterDto
			{
				MerchantId = _ecomContext.Value.ActiveStore.Id,
				OperatingSystem = operatingSystem
			}
		}, ct));
		if (result.TryGetError(out var error))
		{
			return error.ToBaseDomainError();
		}
		return (Result<IReadOnlyDictionary<ShowAt, IReadOnlyList<OnboardingModel>>, DomainError>)(IReadOnlyDictionary<ShowAt, IReadOnlyList<OnboardingModel>>)(from i in (from i in result.Value.Data
				where i.IsValid()
				select i.Map(_resolver)).SelectMany((OnboardingModel onb) => onb.ShowAt.Select((ShowAt s) => new KeyValuePair<ShowAt, OnboardingModel>(s, onb)))
			group i.Value by i.Key).ToFrozenDictionary((Func<IGrouping<ShowAt, OnboardingModel>, ShowAt>)((IGrouping<ShowAt, OnboardingModel> g) => g.Key), (Func<IGrouping<ShowAt, OnboardingModel>, IReadOnlyList<OnboardingModel>>)((IGrouping<ShowAt, OnboardingModel> g) => g.OrderBy((OnboardingModel i) => i.Priority).ToImmutableList()), (IEqualityComparer<ShowAt>?)null);
	}
}
