using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalOffers.DTO;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers;

public class PersonalOffersService
{
	private IRequestExecutor _requestExecutor;

	private IPersonalOffersApi _api;

	private IAdminContext _adminContext;

	public PersonalOffersService(IRequestExecutor executor, IPersonalOffersApi api, IAdminContext adminContext)
	{
		_requestExecutor = executor;
		_api = api;
		_adminContext = adminContext;
	}

	public async Task<Result<List<PersOfferItemViewModel>, DomainError>> PersonalOffers()
	{
		string bodyJson = JsonConvert.SerializeObject(new PersonalOffersRequestDto
		{
			Page = 1L,
			PerPage = 50L
		});
		Task<Result<PersonalOffersResponseDto, ServiceError>> offersTask = _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.PersonalOffers(accessToken.Token, bodyJson));
		Task<Result<AIlOffersResponseDto, ServiceError>> aiOffersTask = _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.AIPersonalOffers(accessToken.Token));
		await Task.WhenAll(offersTask, aiOffersTask);
		Result<List<PersOfferItemViewModel>, DomainError> result = offersTask.Result.Map((PersonalOffersResponseDto dto) => dto.Items.Select((PersonalOfferDto x) => new PersOfferItemViewModel(x, _adminContext)).ToList(), (ServiceError err) => err.ToBaseDomainError());
		Result<List<PersOfferItemViewModel>, DomainError> result2 = aiOffersTask.Result.Map((AIlOffersResponseDto dto) => dto.Items.Select((AIPersOfferDto x) => new PersOfferItemViewModel(x, _adminContext)).ToList(), (ServiceError err) => err.ToBaseDomainError());
		if (result.IsFailure && result2.IsFailure)
		{
			return Result.Failure<List<PersOfferItemViewModel>, DomainError>(result2.Error);
		}
		bool num = result.IsSuccess && result.Value.Any();
		bool flag = result2.IsSuccess && result2.Value.Any();
		if (!num && !flag && (result.IsFailure || result2.IsFailure))
		{
			return result2.IsFailure ? Result.Failure<List<PersOfferItemViewModel>, DomainError>(result2.Error) : Result.Failure<List<PersOfferItemViewModel>, DomainError>(result.Error);
		}
		List<PersOfferItemViewModel> list = new List<PersOfferItemViewModel>();
		if (result.IsSuccess)
		{
			list.AddCollection(result.Value);
		}
		if (result2.IsSuccess)
		{
			list.AddCollection(result2.Value);
		}
		return Result.Success<List<PersOfferItemViewModel>, DomainError>(list);
	}

	public async Task<Result<PersOfferItemViewModel, DomainError>> PersonalOfferDetails(string code)
	{
		Result<PersonalOfferDto, DomainError> result = (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.PersonalOfferDetails(accessToken.Token, code))).Map((PersonalOfferDetailsResponseDto dto) => dto.Item, (ServiceError err) => err.ToBaseDomainError());
		if (result.IsFailure)
		{
			return Result.Failure<PersOfferItemViewModel, DomainError>(result.Error);
		}
		return Result.Success<PersOfferItemViewModel, DomainError>(new PersOfferItemViewModel(result.Value, _adminContext));
	}

	public async Task<Result<PersOfferItemViewModel, DomainError>> AIPersonalOfferDetails(string code)
	{
		Result<AIOfferDetailsResponseDto, DomainError> result = (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.AIPersonalOfferDetails(accessToken.Token, code))).Map((AIOfferDetailsResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
		if (result.IsFailure)
		{
			return Result.Failure<PersOfferItemViewModel, DomainError>(result.Error);
		}
		AIPersOfferDto aIPersOfferDto = result.Value.Items.FirstOrDefault();
		if (aIPersOfferDto == null)
		{
			return Result.Failure<PersOfferItemViewModel, DomainError>(new NoDataError());
		}
		return Result.Success<PersOfferItemViewModel, DomainError>(new PersOfferItemViewModel(aIPersOfferDto, _adminContext));
	}

	public async Task<Result<object, DomainError>> ActivatePersonalOffer(string loymaxId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.ActivatePersonalOffer(accessToken.Token, new ActivatePersonalOfferRequestDto(loymaxId)))).Map((object dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
