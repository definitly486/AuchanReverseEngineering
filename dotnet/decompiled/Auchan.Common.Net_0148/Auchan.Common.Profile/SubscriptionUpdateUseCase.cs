using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Interactors;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile;

public class SubscriptionUpdateUseCase
{
	private readonly IUserContext _userContext;

	private readonly ProfileInteractor _profileInteractor;

	public SubscriptionUpdateUseCase(IUserContext userContext, ProfileInteractor profileInteractor)
	{
		_userContext = userContext;
		_profileInteractor = profileInteractor;
	}

	public async Task<Result<Unit, DomainError>> UpdateSubscription(SubscriptionItemViewModel item, IEnumerable<SubscriptionCommunicationModel> availableSubcriptions, bool subscribe)
	{
		ProfileModel profile = _userContext.Profile;
		SubscriptionModel subscriptionModel = profile.Subscribes.FirstOrDefault((SubscriptionModel x) => x.CommunicationType.Id == item.CommType.Id && x.Type.Id == 1);
		if (subscriptionModel == null)
		{
			subscriptionModel = CreateNewSubscription(item);
			profile.Subscribes.Add(subscriptionModel);
		}
		else if (subscribe)
		{
			profile.Subscribes.Remove(subscriptionModel);
			profile.Subscribes.Add(CreateNewSubscription(item));
		}
		else
		{
			subscriptionModel.EndDate = DateTime.UtcNow;
		}
		var (flag3, _, _, error) = await _profileInteractor.UpdateProfile(profile);
		if (!flag3)
		{
			return Result.Failure<Unit, DomainError>(error);
		}
		return Result.Success<Unit, DomainError>(Unit.Default);
	}

	private SubscriptionModel CreateNewSubscription(SubscriptionItemViewModel item)
	{
		return new SubscriptionModel
		{
			Id = null,
			Type = new SubscriptionTypeModel
			{
				Id = item.Type.Id,
				Title = item.Type.Title
			},
			StartDate = DateTime.UtcNow,
			EndDate = null,
			CommunicationType = new SubscriptionCommunicationModel(item.CommType.Id, item.CommType.Title)
		};
	}
}
