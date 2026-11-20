using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet.DTO;
using CSharpFunctionalExtensions;
using DryIoc;
using Microsoft.Maui.Networking;
using Newtonsoft.Json;
using Polly.Timeout;
using Refit;

namespace Auchan.Common.Base.Errors.Service;

public static class ApiErrorCatchExtensions
{
	public static async Task<Result<T, ServiceError>> CatchErrors<T>(this Task<T> apiCall) where T : class
	{
		try
		{
			return Result.Success<T, ServiceError>(await apiCall);
		}
		catch (Exception ex)
		{
			return await ex.ExceptionToFailure<T>();
		}
	}

	public static async Task<Result<T, ServiceError>> CatchErrors<T, E>(this Task<T> apiCall) where T : class where E : class
	{
		try
		{
			return Result.Success<T, ServiceError>(await apiCall);
		}
		catch (Exception ex)
		{
			return await ex.ExceptionToFailure<T, E>();
		}
	}

	public static async Task<Result<T, ServiceError>> ExceptionToFailure<T>(this Exception @this) where T : class
	{
		return Result.Failure<T, ServiceError>(await IdentifyServiceError<T>(@this));
	}

	public static async Task<Result<T, ServiceError>> ExceptionToFailure<T, E>(this Exception @this) where T : class where E : class
	{
		return Result.Failure<T, ServiceError>(await IdentifyServiceError<E>(@this));
	}

	private static async Task<ServiceError> IdentifyServiceError<T>(Exception ex) where T : class
	{
		ServiceError serviceError;
		if (IsCertificateProblem(ex))
		{
			serviceError = new ConnectionError(ConnectionErrorType.UntrustedCertificate)
			{
				Exception = ex,
				Message = ex.Message
			};
		}
		else
		{
			if (IsTimeoutException(ex))
			{
				return new VpnError
				{
					Exception = ex,
					Message = ex.Message
				};
			}
			if (ex is JsonException)
			{
				serviceError = new ApiContractError
				{
					Exception = ex,
					Message = ex.Message
				};
			}
			else if (ex is TaskCanceledException)
			{
				serviceError = new CancellationError
				{
					Exception = ex,
					Message = ex.Message
				};
			}
			else if (ex is NetworkChangedException)
			{
				serviceError = new ConnectionError(ConnectionErrorType.NetworkChangedError)
				{
					Exception = ex,
					Message = ex.Message
				};
			}
			else if (ex is ApiException apiEx)
			{
				if (IsQratorError(apiEx))
				{
					DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILogService>().LogInfo("ApiErrorCatchExtensions", "Ошибка Qrator", LogType.ApiRequest, SystemType.MobileApp);
					return new ConnectionError(ConnectionErrorType.QratorError)
					{
						Exception = ex,
						Message = ex.Message
					};
				}
				try
				{
					ExpiredTimeSlotResponseDto expiredTimeSlotResponseDto = await apiEx.GetContentAsAsync<ExpiredTimeSlotResponseDto>();
					ExpiredErrorDto expiredErrorDto = expiredTimeSlotResponseDto?.Errors.FirstOrDefault();
					if (expiredErrorDto != null && (expiredErrorDto.Message == "Не заполнена дата доставки" || expiredErrorDto.Message == "Не заполнена дата самовывоза"))
					{
						return new UnsuccessfulStatusCodeError<ExpiredTimeSlotResponseDto>(apiEx.StatusCode, apiEx.Content, expiredTimeSlotResponseDto)
						{
							Exception = ex,
							Message = apiEx.Content
						};
					}
				}
				catch
				{
				}
				try
				{
					GenericError genericError = await apiEx.GetContentAsAsync<GenericError>();
					if (genericError != null && genericError.Error == 102)
					{
						DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILogService>().LogInfo("ApiErrorCatchExtensions", "Токен 80 истек. Логаут", LogType.ApiRequest, SystemType.PersonalAccount);
						DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILogoutService>().RequestForLogoutDueTokenFailure();
						return new UnsuccessfulStatusCodeError<GenericError>(apiEx.StatusCode, apiEx.Content, genericError)
						{
							Exception = ex,
							Message = apiEx.Content
						};
					}
				}
				catch
				{
				}
				T content = null;
				try
				{
					content = await apiEx.GetContentAsAsync<T>();
				}
				catch
				{
				}
				serviceError = new UnsuccessfulStatusCodeError<T>(apiEx.StatusCode, apiEx.Content, content)
				{
					Exception = ex,
					Message = ex.Message
				};
				if (IsVpnException(serviceError))
				{
					return new VpnError
					{
						Exception = ex,
						Message = ex.Message
					};
				}
			}
			else
			{
				serviceError = ((Connectivity.NetworkAccess != NetworkAccess.Internet) ? new ConnectionError(ConnectionErrorType.NoInternet)
				{
					Exception = ex,
					Message = ex.Message
				} : ((!IsHostConnectionException(ex)) ? ((ServiceError)new UnknownServiceError
				{
					Exception = ex,
					Message = ex.Message
				}) : ((ServiceError)new ConnectionError(ConnectionErrorType.HostConnectionProblem)
				{
					Exception = ex,
					Message = ex.Message
				})));
			}
		}
		serviceError.Exception = ex;
		return serviceError;
	}

	private static bool IsCertificateProblem(Exception ex)
	{
		WebException obj = (ex as WebException) ?? (ex.InnerException as WebException);
		if (obj != null && obj.Status == WebExceptionStatus.TrustFailure)
		{
			return true;
		}
		if (string.IsNullOrWhiteSpace(ex.Message))
		{
			return false;
		}
		return ex.Message.Contains("pinning failure");
	}

	private static bool IsVpnException(ServiceError serviceError)
	{
		if (serviceError is UnsuccessfulStatusCodeError<AppConfigDto> unsuccessfulStatusCodeError)
		{
			AppConfigDto content = unsuccessfulStatusCodeError.Content;
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.Forbidden && content != null && content.Errors.Count > 0 && content.Errors.First().Code == "update_required")
			{
				return false;
			}
		}
		if (serviceError is UnsuccessfulStatusCodeError unsuccessfulStatusCodeError2)
		{
			return unsuccessfulStatusCodeError2.StatusCode == HttpStatusCode.Forbidden;
		}
		return false;
	}

	private static bool IsHostConnectionException(Exception ex)
	{
		if (ex is HttpRequestException ex2)
		{
			if (ex2.Message.Contains("502") || ex2.Message.Contains("503"))
			{
				return true;
			}
			if (ex2.Message.ContainsIgnoreCase("connection failure"))
			{
				return true;
			}
		}
		WebException ex3 = (ex as WebException) ?? (ex.InnerException as WebException);
		if (ex3 == null)
		{
			return false;
		}
		switch (ex3.Status)
		{
		case WebExceptionStatus.NameResolutionFailure:
		case WebExceptionStatus.ConnectFailure:
		case WebExceptionStatus.SecureChannelFailure:
		case WebExceptionStatus.ProxyNameResolutionFailure:
		case WebExceptionStatus.UnknownError:
		case WebExceptionStatus.RequestProhibitedByProxy:
			return true;
		default:
			return false;
		}
	}

	private static bool IsTimeoutException(Exception ex)
	{
		if (ex is OperationCanceledException || ex is TimeoutRejectedException)
		{
			return true;
		}
		if (ex is HttpRequestException ex2)
		{
			if (ex2.Message.Contains("timeout"))
			{
				return true;
			}
			if (ex2.InnerException is WebException ex3 && (ex3.Status == WebExceptionStatus.RequestCanceled || ex3.Status == WebExceptionStatus.Timeout))
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsQratorError(ApiException apiException)
	{
		if (apiException.StatusCode == HttpStatusCode.Forbidden && apiException.HasContent)
		{
			string[] obj = new string[5] { "Доступ к сайту", "обратитесь к администрации сайта", "Try accessing the site", "is forbidden", "Guru meditation" };
			string content = apiException.Content;
			string[] array = obj;
			foreach (string toCheck in array)
			{
				if (content.ContainsIgnoreCase(toCheck))
				{
					return true;
				}
			}
		}
		return false;
	}
}
