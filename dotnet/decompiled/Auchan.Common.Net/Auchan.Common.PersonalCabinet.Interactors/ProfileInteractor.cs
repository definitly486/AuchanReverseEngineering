using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Errors;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet.Interactors;

public class ProfileInteractor
{
	private readonly Lazy<ITokenService> _tokenService;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IPersonalCabinetService> _personalCabinetService;

	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	public ProfileInteractor(Lazy<ITokenService> tokenService, Lazy<IUserContext> userContext, Lazy<IPersonalCabinetService> personalCabinetService, Lazy<ILoyaltyManager> loyaltyManager)
	{
		_tokenService = tokenService;
		_userContext = userContext;
		_personalCabinetService = personalCabinetService;
		_loyaltyManager = loyaltyManager;
	}

	public async Task<Result<ProfileModel, DomainError>> GetProfile(string token80)
	{
		Result<ProfileModel, DomainError> serviceResult = await _personalCabinetService.Value.GetProfile(token80);
		if (serviceResult.IsSuccess)
		{
			_userContext.Value.Profile = serviceResult.Value;
			await _loyaltyManager.Value.UpdateSocialStatus(updateProfile: false);
		}
		return serviceResult;
	}

	public async Task<Result<SubscriptionsListModel, DomainError>> GetSubscriptionTypes()
	{
		Result<TokenModel, DomainError> result = await _tokenService.Value.SavedToken80();
		if (result.IsFailure)
		{
			return Result.Failure<SubscriptionsListModel, DomainError>(result.Error);
		}
		return await _personalCabinetService.Value.GetSubscriptionTypes(result.Value);
	}

	public async Task<Result<ProfileModel, DomainError>> RequestMailConfirmation()
	{
		Result<TokenModel, DomainError> result = await _tokenService.Value.SavedToken80();
		if (result.IsFailure)
		{
			return result.Error;
		}
		return await _personalCabinetService.Value.UpdateProfile(_userContext.Value.Profile, result.Value);
	}

	public async Task<Result<Unit, DomainError>> UpdateWithSubscriptionsOn(ProfileModel profileModel)
	{
		Result<SubscriptionsListModel, DomainError> result = await GetSubscriptionTypes();
		if (result.TryGetError(out var error))
		{
			return error;
		}
		TurnSubscriptionsOn(profileModel, result.Value);
		return Unit.Default;
	}

	public static void TurnSubscriptionsOn(ProfileModel profileModel, SubscriptionsListModel subscriptions)
	{
		SubscriptionTypeModel activeType = subscriptions.SubscriptionTypes.FirstOrDefault((SubscriptionTypeModel x) => x.Id == 1) ?? new SubscriptionTypeModel
		{
			Id = 1,
			Title = "Общая"
		};
		IEnumerable<SubscriptionModel> collection = from sct in subscriptions.SubscriptionCommTypes
			join pms in profileModel.Subscribes on sct.Id equals pms.CommunicationType.Id
			where pms.Type.Id != 1
			select new SubscriptionModel
			{
				Id = null,
				Type = activeType,
				StartDate = DateTime.UtcNow,
				EndDate = null,
				CommunicationType = new SubscriptionCommunicationModel(sct.Id, sct.Title)
			};
		IEnumerable<SubscriptionModel> collection2 = from commType in subscriptions.SubscriptionCommTypes
			where !profileModel.Subscribes.Any((SubscriptionModel x) => x.CommunicationType.Id == commType.Id)
			select new SubscriptionModel
			{
				Id = null,
				Type = activeType,
				StartDate = DateTime.UtcNow,
				EndDate = null,
				CommunicationType = new SubscriptionCommunicationModel(commType.Id, commType.Title)
			};
		List<SubscriptionModel> subscribes = profileModel.Subscribes;
		List<SubscriptionModel> list = new List<SubscriptionModel>();
		list.AddRange(collection);
		list.AddRange(collection2);
		subscribes.AddRange(new _003C_003Ez__ReadOnlyList<SubscriptionModel>(list));
	}

	public async Task<Result<ProfileModel, DomainError>> UpdateProfile(ProfileModel profileModel)
	{
		Result<TokenModel, DomainError> result = await _tokenService.Value.SavedToken80();
		if (result.IsFailure)
		{
			return Result.Failure<ProfileModel, DomainError>(result.Error);
		}
		Result<ProfileModel, DomainError> result2 = await _personalCabinetService.Value.UpdateProfile(profileModel, result.Value.Token);
		if (result2.TryGetValue(out var value))
		{
			WriteProfile(value);
		}
		return result2;
	}

	public async Task<Result<Unit, DomainError>> SyncProfile()
	{
		Result<TokenModel, DomainError> result = await _tokenService.Value.SavedToken80();
		if (result.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result.Error);
		}
		Result<ProfileModel, DomainError> result2 = await _personalCabinetService.Value.GetProfile(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result2.Error);
		}
		if (result2.IsSuccess && string.IsNullOrEmpty(result2.Value.LoymaxLoyaltyId))
		{
			return Result.Failure<Unit, DomainError>(new SessionExpiredError());
		}
		WriteProfile(result2.Value);
		return Result.Success<Unit, DomainError>(Unit.Default);
	}

	private void WriteProfile(ProfileModel profileModel)
	{
		profileModel.IsConfirmedSocialStatus = _userContext.Value.Profile?.IsConfirmedSocialStatus ?? false;
		_userContext.Value.UpdateProfileWithNotify(profileModel);
	}

	public async Task<Result<bool, DomainError>> CheckIfProfileIsDeleted()
	{
		Result<TokenModel, DomainError> result = await _tokenService.Value.SavedToken80();
		if (result.IsFailure)
		{
			return Result.Success<bool, DomainError>(value: true);
		}
		Result<ProfileModel, DomainError> result2 = await _personalCabinetService.Value.GetProfile(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<bool, DomainError>(result2.Error);
		}
		ProfileModel value = result2.Value;
		string phone = value.Phone;
		string text = value.MagentoAccountId.ToString();
		return Result.Success<bool, DomainError>(phone == text);
	}
}
