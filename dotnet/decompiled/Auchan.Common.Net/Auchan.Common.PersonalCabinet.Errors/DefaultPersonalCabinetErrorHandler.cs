using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;

namespace Auchan.Common.PersonalCabinet.Errors;

public class DefaultPersonalCabinetErrorHandler
{
	private readonly IInfoMessageService _infoMessageService;

	public DefaultPersonalCabinetErrorHandler(IInfoMessageService infoMessageService)
	{
		_infoMessageService = infoMessageService;
	}

	public bool TryHandleError(DomainError domainError)
	{
		if (!(domainError is PhoneOfAnotherAccountError))
		{
			if (!(domainError is ConnectionError))
			{
				if (!(domainError is ExpiredPinError))
				{
					if (domainError is UnknownError)
					{
						_infoMessageService.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже");
						return true;
					}
					return false;
				}
				_infoMessageService.ShowSnackbar("Ваш код устарел");
				return true;
			}
			_infoMessageService.ShowSnackbar("Нет соединения с интернетом");
			return true;
		}
		_infoMessageService.ShowSnackbar("Пользователь с таким номером уже существует");
		return true;
	}

	public void HandleError(DomainError error)
	{
		if (!TryHandleError(error))
		{
			_infoMessageService.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже");
		}
	}
}
