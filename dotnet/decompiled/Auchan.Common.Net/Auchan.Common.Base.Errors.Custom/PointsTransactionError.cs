using System.Linq;
using System.Net;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.LoyaltyProgram.Dtos;

namespace Auchan.Common.Base.Errors.Custom;

public class PointsTransactionError
{
	public string Message { get; set; } = "";

	public string Title => "Невозможно осуществить перевод";

	public bool IncorrectPhone { get; set; }

	public PointsTransactionError(ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<PointsTransferResponseDto> unsuccessfulStatusCodeError)
		{
			Error error = unsuccessfulStatusCodeError.Content?.Errors?.FirstOrDefault();
			if (error != null && unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.BadRequest)
			{
				if (error.Code == "PhoneCheckError")
				{
					IncorrectPhone = true;
				}
				Message = error.Message ?? "";
				return;
			}
		}
		Message = "Сервис скоро будет восстановлен";
	}
}
