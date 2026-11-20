using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Cache;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages.DTO;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.InfoPages.ServiceErrors;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.InfoPages;

public class InfoPagesRepository : IInfoPagesRepository
{
	private const string INFO_CACHE_KEY = "info_pages_cache";

	private const string FAQ_CACHE_KEY = "faq_cache_{0}";

	private const string TUTORIALS_CACHE_KEY = "tutorials_cache";

	private readonly IInfoPagesApi _api;

	private readonly IAdminToolAuthorizer _authorizer;

	private readonly IMemoryCache _cache;

	private readonly IRequestExecutor _requestExecutor;

	private readonly IUserContext _userContext;

	public InfoPagesRepository(IInfoPagesApi api, IAdminToolAuthorizer authorizer, IRequestExecutor requestExecutor, IMemoryCache cache, IUserContext userContext)
	{
		_api = api;
		_authorizer = authorizer;
		_requestExecutor = requestExecutor;
		_cache = cache;
		_userContext = userContext;
		_userContext.AfterLoggedIn += delegate
		{
			_cache.Remove("info_pages_cache");
			return Task.CompletedTask;
		};
		_userContext.AfterLoggedOut += delegate
		{
			_cache.Remove("info_pages_cache");
			return Task.CompletedTask;
		};
	}

	public async Task<Result<InfoPage, DomainError>> InfoPage(string slug)
	{
		Result<List<InfoPage>, DomainError> result = await InfoPages();
		if (result.IsFailure)
		{
			return Result.Failure<InfoPage, DomainError>(result.Error);
		}
		InfoPage infoPage = result.Value.FirstOrDefault((InfoPage x) => x.Slug == slug);
		return (infoPage == null) ? Result.Failure<InfoPage, DomainError>(new UnknownError()) : Result.Success<InfoPage, DomainError>(infoPage);
	}

	public async Task<Result<List<InfoPage>, DomainError>> InfoPages()
	{
		List<InfoResponseDto> list = await _cache.TryGet<List<InfoResponseDto>>("info_pages_cache");
		if (list.IsNotNullOrEmpty() && list != null)
		{
			return Result.Success<List<InfoPage>, DomainError>(list.Select(InfoPageMapper.ToModel).ToList());
		}
		Result<string, ServiceError> tokenResult = await _authorizer.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<List<InfoPage>, DomainError>(tokenResult.Error.ToBaseDomainError());
		}
		return (await (await _requestExecutor.Execute((CancellationToken t) => _api.InfoPages(tokenResult.Value, t))).Tap(async delegate(List<InfoResponseDto> x)
		{
			await _cache.Save("info_pages_cache", x);
		}).Tap((List<InfoResponseDto> dtos) => Task.FromResult(Result.Success<List<InfoResponseDto>, ServiceError>(dtos.Where(delegate(InfoResponseDto dto)
		{
			ProfileModel? profile = _userContext.Profile;
			return profile?.IsAudienceOf(dto.Audience) ?? (dto.Audience == AudienceType.Clients || dto.Audience == AudienceType.All);
		}).ToList())))).Map((List<InfoResponseDto> dto) => dto.Select(InfoPageMapper.ToModel).ToList(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<FAQ, DomainError>> FAQ(FAQType type = FAQType.Default)
	{
		FAQResponseDto fAQResponseDto = await _cache.TryGet<FAQResponseDto>($"faq_cache_{type.ToString()}");
		if (fAQResponseDto != null)
		{
			return Result.Success<FAQ, DomainError>(fAQResponseDto.ToModel());
		}
		Result<string, ServiceError> tokenResult = await _authorizer.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<FAQ, DomainError>(tokenResult.Error.ToNoFAQDataError());
		}
		return (await (await _requestExecutor.Execute((CancellationToken t) => _api.FAQ(tokenResult.Value, type, t))).Ensure((List<FAQResponseDto> x) => x.Count != 0, new NoFaqDataError()).Tap(async delegate(List<FAQResponseDto> x)
		{
			await _cache.Save($"faq_cache_{type.ToString()}", x.First());
		})).Map((List<FAQResponseDto> x) => x.First()).Map((FAQResponseDto dto) => dto.ToModel(), (ServiceError err) => err.ToNoFAQDataError());
	}

	public async Task<Result<List<Tutorial>, DomainError>> Tutorials()
	{
		List<TutorialDto> list = await _cache.TryGet<List<TutorialDto>>("tutorials_cache");
		if (list != null)
		{
			return Result.Success<List<Tutorial>, DomainError>(list.Select((TutorialDto x) => x.ToModel()).ToList());
		}
		Result<string, ServiceError> tokenResult = await _authorizer.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<List<Tutorial>, DomainError>(tokenResult.Error.ToNoTutorialsDataError());
		}
		return (await (await _requestExecutor.Execute((CancellationToken t) => _api.Tutorials(tokenResult.Value, t))).Ensure((List<TutorialDto> x) => x.Count != 0, new NoTutorialsDataError()).Tap(async delegate(List<TutorialDto> x)
		{
			await _cache.Save("tutorials_cache", x);
		})).Map((List<TutorialDto> dto) => dto.Select((TutorialDto x) => x.ToModel()).ToList(), (ServiceError err) => err.ToNoTutorialsDataError());
	}
}
