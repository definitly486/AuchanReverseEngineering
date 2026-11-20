using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Reviews;

public class ReviewCheckAddingService
{
	private const string ErrorTitle = "Произошла ошибка";

	private const string ErrorNoProduct = "Поделиться мнением о товаре\nможно после его покупки\nс применением карты лояльности Ашан";

	private const string ErrorAlreadyReviewed = "Вы уже написали отзыв. Поделиться мнением можно только один раз.";

	private const string ErrorCloseButtonText = "Закрыть";

	private ReviewsEcomService _reviewsEcomService;

	private IInfoMessageService _infoMessageService;

	public ReviewCheckAddingService(ReviewsEcomService reviewsEcomService, IInfoMessageService infoMessageService)
	{
		_reviewsEcomService = reviewsEcomService;
		_infoMessageService = infoMessageService;
	}

	public async Task<bool> CanAddReview(string? gimaId, Channel channel = Channel.Online)
	{
		if (gimaId == null)
		{
			gimaId = string.Empty;
		}
		if (!int.TryParse(gimaId, out var result))
		{
			ShowErrorDialog("Произошла ошибка", string.Empty).SafeFireAndForget((Action<Exception>)null, false);
			return false;
		}
		Result<CheckAddingResponseDto, DomainError> result2 = await _reviewsEcomService.CheckAdding(result, (channel == Channel.Online) ? "online" : "offline");
		if (result2.IsSuccess)
		{
			CheckAddingResponseDto value = result2.Value;
			if (value != null)
			{
				CheckAddingDataDto data = value.Data;
				if (data != null)
				{
					CheckAddingStatus? result3 = data.Result;
					if (result3.HasValue && result3 == CheckAddingStatus.CanReview)
					{
						return true;
					}
				}
			}
		}
		string text;
		if (!result2.IsSuccess)
		{
			text = "Поделиться мнением о товаре\nможно после его покупки\nс применением карты лояльности Ашан";
		}
		else
		{
			CheckAddingResponseDto value2 = result2.Value;
			if (value2 != null && value2.Data?.Result == CheckAddingStatus.NoProduct)
			{
				text = "Поделиться мнением о товаре\nможно после его покупки\nс применением карты лояльности Ашан";
			}
			else
			{
				CheckAddingResponseDto value3 = result2.Value;
				text = ((value3 == null || value3.Data?.Result != CheckAddingStatus.AlreadyReviewed) ? string.Empty : "Вы уже написали отзыв. Поделиться мнением можно только один раз.");
			}
		}
		string message = text;
		ShowErrorDialog(string.Empty, message).SafeFireAndForget((Action<Exception>)null, false);
		return false;
	}

	private async Task ShowErrorDialog(string title, string message)
	{
		await _infoMessageService.ShowDialogAsync(title, message, new AlertButton[1]
		{
			new AlertButton
			{
				Title = "Закрыть",
				Action = null,
				Type = ActionType.Positive
			}
		});
	}
}
