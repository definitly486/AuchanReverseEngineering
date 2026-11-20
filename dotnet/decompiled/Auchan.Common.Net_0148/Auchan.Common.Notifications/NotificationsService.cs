using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Networking;
using Auchan.Common.Notifications.DTO;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Notifications;

public class NotificationsService
{
	private readonly IRequestExecutor _requestExecutor;

	private readonly INotificationsApi _api;

	public NotificationsService(IRequestExecutor requestExecutor, INotificationsApi api)
	{
		_requestExecutor = requestExecutor;
		_api = api;
	}

	public async Task<Result<NotificationsListResponseDto, DomainError>> GetNotifications()
	{
		if (NotificationsMockProvider.UseMock)
		{
			await NotificationsMockProvider.SimulateDelay();
			if (NotificationsMockProvider.ForceError)
			{
				return Result.Failure<NotificationsListResponseDto, DomainError>(new UnknownError());
			}
			return Result.Success<NotificationsListResponseDto, DomainError>(NotificationsMockProvider.BuildResponse());
		}
		try
		{
			Result<NotificationsListResponseDto, ServiceError> result = await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.GetNotifications(accessToken.Token, cancellationToken));
			if (result.IsFailure)
			{
				return Result.Failure<NotificationsListResponseDto, DomainError>(result.Error.ToBaseDomainError());
			}
			return Result.Success<NotificationsListResponseDto, DomainError>(result.Value);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<Result<NotificationViewResponseDto, DomainError>> MarkAsViewed(string uuid)
	{
		if (NotificationsMockProvider.UseMock)
		{
			return Result.Success<NotificationViewResponseDto, DomainError>(NotificationsMockProvider.BuildViewResponse());
		}
		Result<NotificationViewResponseDto, ServiceError> result = await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => _api.MarkAsViewed(accessToken.Token, new NotificationViewRequestDto(uuid), cancellationToken));
		if (result.IsFailure)
		{
			return Result.Failure<NotificationViewResponseDto, DomainError>(result.Error.ToBaseDomainError());
		}
		return Result.Success<NotificationViewResponseDto, DomainError>(result.Value);
	}
}
