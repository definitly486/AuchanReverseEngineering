using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.DynamicFeedback.Dto;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.DynamicFeedback.Services;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Interactors;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile;

public class UserAccountDeletionService : IUserAccountDeletionService
{
	private readonly DynamicFeedbackService _dynamicFeedbackService;

	private readonly IUserContext _userContext;

	private readonly LogoutInteractor _logoutInteractor;

	private readonly IEnvironmentManager _environmentManager;

	private readonly IInfoMessageService _infoMessageService;

	public UserAccountDeletionService(DynamicFeedbackService dynamicFeedbackService, IUserContext userContext, LogoutInteractor logoutInteractor, IEnvironmentManager environmentManager, IInfoMessageService infoMessageService)
	{
		_dynamicFeedbackService = dynamicFeedbackService;
		_userContext = userContext;
		_logoutInteractor = logoutInteractor;
		_environmentManager = environmentManager;
		_infoMessageService = infoMessageService;
	}

	public async Task<DeletionResult> DeleteAccount()
	{
		Result<IsFeedbackActiveDto, DomainError> isFeedbackActive = await _dynamicFeedbackService.IsFeedbackActive();
		Result<FeedbackCategoriesResponse, DomainError> categoriesResult = await _dynamicFeedbackService.GetCategories();
		if (isFeedbackActive.IsFailure || categoriesResult.IsFailure)
		{
			return DeletionResult.Failure;
		}
		if (!(await AskUserAboutDeletion()))
		{
			return DeletionResult.DeclinedByUser;
		}
		List<FeedbackCategoryDto> categories = categoriesResult.Value.Categories;
		Result<FeedbackRespondResponse, DomainError> result = await DeleteAccount(categories);
		if (result.IsFailure)
		{
			return DeletionResult.Failure;
		}
		string caseNumber = result.Value.CaseNumber ?? string.Empty;
		await ShowYourApplicationIsRegisteredDialog(caseNumber);
		return (await LogoutEverywhere()) ? DeletionResult.Success : DeletionResult.Failure;
	}

	private async Task<bool> AskUserAboutDeletion()
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync("Вы уверены, что хотите удалить аккаунт?", "После удаления ваши баллы АШАН сгорят, личный кабинет заблокируется, а история покупок станет недоступна. Аккаунт будет удален в течение 5 дней. Восстановление данных будет невозможно.", new AlertButton[2]
		{
			new AlertButton
			{
				Title = "Удалить",
				Action = delegate
				{
				},
				Type = ActionType.Positive
			},
			new AlertButton
			{
				Title = "Отменить",
				Action = delegate
				{
				},
				Type = ActionType.Destructive
			}
		});
		return (object)obj != null && obj.Type == ActionType.Positive;
	}

	private async Task<Result<FeedbackRespondResponse, DomainError>> DeleteAccount(List<FeedbackCategoryDto>? feedbackCategories)
	{
		if (feedbackCategories == null)
		{
			feedbackCategories = new List<FeedbackCategoryDto>();
		}
		string deleteServiceCrmId = ((_environmentManager.CurrentEnvironment == Environment.Production) ? "e888f4c1-70fe-403a-aa89-9e0f9d1b0c13" : "5321d97c-7947-4d5a-8f92-b80c55019d8d");
		long? topic_id = feedbackCategories.SelectMany((FeedbackCategoryDto category) => (category.Topics ?? new List<FeedbackTopicDto>()).Where((FeedbackTopicDto topic) => topic.ServiceCrmId.ToString() == deleteServiceCrmId)).FirstOrDefault()?.Id;
		if (!topic_id.HasValue)
		{
			return Result.Failure<FeedbackRespondResponse, DomainError>(new UnknownError());
		}
		var body = new
		{
			topic_id = topic_id,
			KmkIsPresonalData = true,
			GivenName = _userContext.Profile.FirstName,
			MobilePhone = _userContext.Profile.Phone,
			Symptoms = "Прошу удалить мои персональные данные. Номер телефона " + _userContext.Profile.Phone + " " + $"номер клиента в мобильном приложении {_userContext.Profile.MagentoAccountId}",
			contactSource = "ФОС МП",
			contactCMDId = _userContext.Profile.ClientAccountId
		};
		return await _dynamicFeedbackService.Respond(body);
	}

	private async Task ShowYourApplicationIsRegisteredDialog(string caseNumber)
	{
		await _infoMessageService.ShowDialogAsync(string.Empty, "Ваше обращение " + caseNumber + " зафиксировано", new AlertButton[1]
		{
			new AlertButton
			{
				Title = "ОК",
				Action = delegate
				{
				},
				Type = ActionType.Positive
			}
		});
	}

	private async Task<bool> LogoutEverywhere()
	{
		if (!(await _logoutInteractor.Logout(fromAll: true)).IsSuccess)
		{
			return false;
		}
		return (await _logoutInteractor.Logout()).IsSuccess;
	}
}
