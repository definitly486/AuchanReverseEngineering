using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Interactors;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile;

public class SubscriptionsService
{
	private readonly IUserContext _userContext;

	private readonly ProfileInteractor _profileInteractor;

	private readonly IInfoMessageService _messageService;

	private readonly SubscriptionUpdateUseCase _subscriptionUpdateUseCase;

	private readonly List<SubscriptionCommunicationModel> _availableSubscriptionModels = new List<SubscriptionCommunicationModel>();

	private readonly List<SubscriptionItemViewModel> _subscriptionsViewModels = new List<SubscriptionItemViewModel>();

	public SubscriptionsService(IUserContext userContext, ProfileInteractor profileInteractor, IInfoMessageService messageService, SubscriptionUpdateUseCase subscriptionUpdateUseCase)
	{
		_userContext = userContext;
		_profileInteractor = profileInteractor;
		_messageService = messageService;
		_subscriptionUpdateUseCase = subscriptionUpdateUseCase;
	}

	public void SetSubscriptions(SubscriptionsListModel subscriptionListModel)
	{
		_availableSubscriptionModels.Clear();
		_availableSubscriptionModels.AddRange(subscriptionListModel.SubscriptionCommTypes);
		IEnumerable<SubscriptionItemViewModel> collection = subscriptionListModel.SubscriptionCommTypes.Select((SubscriptionCommunicationModel commType) => new SubscriptionItemViewModel
		{
			CommType = commType,
			Type = (subscriptionListModel.SubscriptionTypes.FirstOrDefault((SubscriptionTypeModel type) => type.Id == 1) ?? new SubscriptionTypeModel
			{
				Id = 1,
				Title = "Общая"
			}),
			Enabled = (_userContext.Profile?.Subscribes.Any((SubscriptionModel sub) => sub.CommunicationType.Id == commType.Id && !sub.EndDate.HasValue && sub.Type.Id == 1) ?? false)
		});
		_subscriptionsViewModels.Clear();
		_subscriptionsViewModels.AddRange(collection);
	}

	public IEnumerable<SubscriptionCommunicationModel> GetSubscriptionsModels()
	{
		return _availableSubscriptionModels;
	}

	public IEnumerable<SubscriptionItemViewModel> GetSubscriptionsViewModels()
	{
		return _subscriptionsViewModels;
	}

	public bool IsAvailable(string subscriptionTitle)
	{
		return _availableSubscriptionModels.Any((SubscriptionCommunicationModel x) => x.Title == subscriptionTitle);
	}

	public async Task<bool> UpdateEReceiptSubscription(bool enabled, Func<bool, Task> onEmailUpdated)
	{
		if (!_userContext.Profile.HasEmail)
		{
			if (!(await AskForEmail()))
			{
				return false;
			}
			await onEmailUpdated(arg: true);
		}
		ProfileModel profile = _userContext.Profile;
		profile.EReceiptEnabled = enabled;
		var (flag3, _, _, domainError2) = await _profileInteractor.UpdateProfile(profile);
		if (!flag3)
		{
			_messageService.ShowSnackbar(domainError2.Message);
			return false;
		}
		return true;
	}

	public async Task<bool> UpdatePollsSubscription(bool enabled)
	{
		SubscriptionItemViewModel subscriptionItemViewModel = _subscriptionsViewModels.FirstOrDefault((SubscriptionItemViewModel x) => x.CommType.Title == "email_polls");
		if (subscriptionItemViewModel == null)
		{
			return false;
		}
		Result<Unit, DomainError> result = await _subscriptionUpdateUseCase.UpdateSubscription(subscriptionItemViewModel, _availableSubscriptionModels, enabled);
		if (result.IsSuccess)
		{
			return true;
		}
		_messageService.ShowSnackbar(result.Error.Message);
		return false;
	}

	private async Task<bool> AskForEmail()
	{
		(AlertButton, string) tuple = await _messageService.ShowTextFieldAlertAsync("Укажите ваш e-mail", "Электронные чеки будут приходить на указанный адрес почты", new AlertButton[2]
		{
			new AlertButton
			{
				Title = "Отмена",
				Type = ActionType.Negative
			},
			new AlertButton
			{
				Title = "Сохранить",
				Type = ActionType.Positive
			}
		});
		var (alertButton, _) = tuple;
		if ((object)alertButton == null || alertButton.Type != ActionType.Positive)
		{
			return false;
		}
		bool result = false;
		if (!string.IsNullOrEmpty(tuple.Item2) && AuthValidationHelper.IsValidEmail(tuple.Item2))
		{
			result = await UpdateEmail(tuple.Item2);
		}
		else
		{
			_messageService.ShowSnackbar("E-mail введен некорректно");
		}
		return result;
	}

	private async Task<bool> UpdateEmail(string newEmail)
	{
		ProfileModel requestProfile = _userContext.Profile;
		requestProfile.Email = newEmail;
		var (flag3, _, _, domainError2) = await _profileInteractor.UpdateProfile(requestProfile);
		if (!flag3)
		{
			_messageService.ShowSnackbar(domainError2.Message);
			requestProfile.Email = string.Empty;
			return false;
		}
		return true;
	}
}
