using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.DynamicFeedback.Dto;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.DynamicFeedback.Services;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Reviews;

public class ReviewReportService
{
	private readonly DynamicFeedbackService _dynamicFeedbackService;

	private readonly IEnvironmentManager _environmentManager;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IUserContext _userContext;

	public ReviewReportService(DynamicFeedbackService dynamicFeedbackService, IEnvironmentManager environmentManager, IInfoMessageService infoMessageService, IUserContext userContext)
	{
		_dynamicFeedbackService = dynamicFeedbackService;
		_environmentManager = environmentManager;
		_infoMessageService = infoMessageService;
		_userContext = userContext;
	}

	public async Task Report(int reviewId, string reason)
	{
		Result<IsFeedbackActiveDto, DomainError> isFeedbackActive = await _dynamicFeedbackService.IsFeedbackActive();
		Result<FeedbackCategoriesResponse, DomainError> result = await _dynamicFeedbackService.GetCategories();
		string reportCategoryId = ((_environmentManager.CurrentEnvironment == Environment.Production) ? "dd3cf815-703c-4756-9ebe-49789eef7bb5" : "5c0d1904-fab0-4eb5-a2ea-b50df4320b05");
		if (!isFeedbackActive.IsFailure && !result.IsFailure && !result.Value.Categories.IsNullOrEmpty())
		{
			FeedbackTopicDto feedbackTopicDto = result.Value.Categories.SelectMany((FeedbackCategoryDto c) => c.Topics ?? new List<FeedbackTopicDto>()).FirstOrDefault((FeedbackTopicDto t) => t.ServiceCrmId.ToString() == reportCategoryId);
			if (feedbackTopicDto != null)
			{
				var body = new
				{
					topic_id = feedbackTopicDto.Id,
					KmkIsPresonalData = true,
					GivenName = _userContext.Profile.FirstName,
					MobilePhone = _userContext.Profile.Phone,
					Symptoms = $"Идентификатор отзыва: {reviewId} Жалоба: {reason}",
					contactSource = "ФОС МП",
					contactCMDId = _userContext.Profile.ClientAccountId,
					siteCRMId = _userContext.Profile.ClientAccountId
				};
				if ((await _dynamicFeedbackService.Respond(body)).IsSuccess)
				{
					_infoMessageService.ShowSnackbar("Спасибо за обратную связь!", SnackbarStyle.Success);
				}
				else
				{
					_infoMessageService.ShowSnackbar("Не удалось отправить сообщение");
				}
				return;
			}
		}
		_infoMessageService.ShowSnackbar("Не удалось отправить сообщение");
	}
}
