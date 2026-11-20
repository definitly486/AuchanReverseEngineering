using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Common;

public sealed class LogoutService : ILogoutService
{
	private readonly IUserContext _userContext;

	private readonly IRestartService _restartService;

	private readonly IInfoMessageService _infoMessageService;

	private volatile int _logoutRequestId;

	public LogoutService(IUserContext userContext, IRestartService restartService, IInfoMessageService infoMessageService)
	{
		_userContext = userContext;
		_restartService = restartService;
		_infoMessageService = infoMessageService;
	}

	public async Task LogoutAsync()
	{
		await _userContext.LogOut();
		_restartService.Restart();
	}

	public async void RequestForLogoutDueTokenFailure()
	{
		int id = Interlocked.Increment(ref _logoutRequestId);
		await Task.Delay(1000);
		if (id == _logoutRequestId)
		{
			await _infoMessageService.ShowDialogAsync("Сессия устарела!", "Вы будете перенаправлены на окно авторизации.", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "Ok",
					Type = ActionType.Positive
				}
			});
			await LogoutAsync();
		}
	}
}
