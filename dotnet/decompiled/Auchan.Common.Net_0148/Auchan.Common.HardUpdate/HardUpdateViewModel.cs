using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet;
using EBind;

namespace Auchan.Common.HardUpdate;

public class HardUpdateViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string? Message { get; }

		public Parameter(string? message)
		{
			Message = message;
		}
	}

	private readonly Subject<string> _openQrCode = new Subject<string>();

	private bool _isUserAuthorized;

	private readonly Parameter _parameter;

	private readonly IUserContext _userContext;

	private readonly Lazy<IUpdateService> _updateService;

	private string DefaultMessage => "Ваша версия приложения больше не поддерживается, пожалуйста, обновите приложение";

	public bool IsShowQrCodeVisible
	{
		get
		{
			if (_isUserAuthorized)
			{
				return _userContext.Profile?.ClientAccountId != null;
			}
			return false;
		}
	}

	public string HardUpdateMessageText
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(_parameter.Message))
			{
				return _parameter.Message;
			}
			return "Ваша версия приложения больше не поддерживается, пожалуйста, обновите приложение";
		}
	}

	public string HardUpdateHintText => "Пожалуйста, обновите приложение";

	public string ShowQrCodeButtonText => "Показать карту лояльности";

	public string UpdateButtonText => "Обновить";

	public IObservable<string> ShowQrCodeClickCommand => _openQrCode.Debounce();

	public HardUpdateViewModel(Parameter parameter, IUserContext userContext, Lazy<IUpdateService> updateService)
	{
		_parameter = parameter;
		_userContext = userContext;
		_updateService = updateService;
		_isUserAuthorized = _userContext.Authorized;
		_userContext.AfterLoggedIn += new DisposableDelegate<Func<Task>>(delegate
		{
			_isUserAuthorized = _userContext.Authorized;
			return Task.CompletedTask;
		}, delegate(Func<Task> d)
		{
			_userContext.AfterLoggedIn -= d;
		}).AddTo(base.CloseDisposable);
		_userContext.AfterLoggedOut += new DisposableDelegate<Func<Task>>(delegate
		{
			_isUserAuthorized = _userContext.Authorized;
			return Task.CompletedTask;
		}, delegate(Func<Task> d)
		{
			_userContext.AfterLoggedOut -= d;
		}).AddTo(base.CloseDisposable);
	}

	public void UpdateClick()
	{
		_updateService.Value.NavigateToStoreAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void ShowQrCodeClick()
	{
		_openQrCode.OnNext(_userContext.Profile.CashbackQrCode);
	}
}
