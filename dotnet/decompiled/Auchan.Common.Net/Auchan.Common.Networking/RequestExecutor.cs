using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;
using Polly;
using Polly.Timeout;

namespace Auchan.Common.Networking;

public class RequestExecutor : IRequestExecutor
{
	private readonly ITokenService _tokenService;

	private readonly IPolicyProvider _policyProvider;

	public RequestExecutor(ITokenService tokenService, IPolicyProvider policyProvider)
	{
		_tokenService = tokenService;
		_policyProvider = policyProvider;
	}

	public Task<Result<T, ServiceError>> Execute<T, E>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class
	{
		return Task.Run(() => Execute<T, E>(func, 15, cancellationToken, timeoutStrategy));
	}

	public Task<Result<T, ServiceError>> ExecuteWithExtendedTimeout<T, E>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class
	{
		return Task.Run(() => Execute<T, E>(func, 20, cancellationToken, timeoutStrategy));
	}

	public Task<Result<T, ServiceError>> ExecuteWithCustomTimeout<T, E>(Func<CancellationToken, Task<T>> func, int timeout, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class
	{
		return Task.Run(() => Execute<T, E>(func, timeout, cancellationToken, timeoutStrategy));
	}

	private Task<Result<T, ServiceError>> Execute<T, E>(Func<CancellationToken, Task<T>> func, int timeout, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class
	{
		AppAnalytics.AppMetrica.WarmStartEnd().SafeFireAndForget((Action<Exception>)null, false);
		return timeoutStrategy switch
		{
			TimeoutStrategy.Optimistic => ExecuteOptimistic<T, E>(func, timeout, cancellationToken), 
			TimeoutStrategy.Pessimistic => ExecutePessimistic<T, E>(func, timeout, cancellationToken), 
			_ => throw new NotImplementedException(), 
		};
	}

	private async Task<Result<T, ServiceError>> ExecuteOptimistic<T, E>(Func<CancellationToken, Task<T>> func, int timeout, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class
	{
		return await _policyProvider.DefaultPolicy<T>(timeout).ExecuteAsync((CancellationToken t) => func(t).CatchErrors<T, E>(), cancellationToken);
	}

	private async Task<Result<T, ServiceError>> ExecutePessimistic<T, E>(Func<CancellationToken, Task<T>> func, int timeout, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class
	{
		try
		{
			return await _policyProvider.DefaultPolicy<T>(timeout, TimeoutStrategy.Pessimistic).ExecuteAsync((CancellationToken t) => func(t).CatchErrors<T, E>(), cancellationToken);
		}
		catch (Exception ex)
		{
			return await ex.ExceptionToFailure<T, E>();
		}
	}

	public async Task<Result<T, ServiceError>> ExecuteWithToken<T, E>(Func<CancellationToken, TokenModel, Task<T>> func, TokenLevel tokenNumber = TokenLevel.L80, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class
	{
		Result<TokenModel, ServiceError> token = await Task.Run(async () => await GetTokenByNumber(tokenNumber, _tokenService));
		if (token.IsFailure)
		{
			return Result.Failure<T, ServiceError>(token.Error);
		}
		return await Task.Run(async () => await _policyProvider.DefaultPolicy<T>(15).ExecuteAsync((CancellationToken t) => func(t, token.Value).CatchErrors<T, E>(), cancellationToken));
	}

	public async Task<Result<T, ServiceError>> ExecuteWithTokenAndCustomTimeout<T, E>(Func<CancellationToken, TokenModel, Task<T>> func, int timeoutInSeconds, TokenLevel tokenNumber = TokenLevel.L80, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class
	{
		Result<TokenModel, ServiceError> token = await Task.Run(async () => await GetTokenByNumber(tokenNumber, _tokenService));
		if (token.IsFailure)
		{
			return Result.Failure<T, ServiceError>(token.Error);
		}
		return await Task.Run(async () => await _policyProvider.DefaultPolicy<T>(timeoutInSeconds).ExecuteAsync((CancellationToken t) => func(t, token.Value).CatchErrors<T, E>(), cancellationToken));
	}

	private static async Task<Result<TokenModel, ServiceError>> GetTokenByNumber(TokenLevel tokenNumber, ITokenService tokenService)
	{
		return (tokenNumber switch
		{
			TokenLevel.L20 => await tokenService.Token20(), 
			TokenLevel.L80 => await tokenService.SavedToken80(), 
			_ => Result.Failure<TokenModel, DomainError>(new UnknownError
			{
				Message = "Invalid value of tokenNumber"
			}), 
		}).Map((TokenModel x) => x, (DomainError x) => x.WrapIntoServiceError());
	}

	public async Task<Result<T, ServiceError>> ExecuteWithRetryOnConnectionErrorPolicy<T, E>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class
	{
		return await Task.Run(() => Policy.HandleResult((Result<T, ServiceError> r) => r.IsFailure && r.Error is Auchan.Common.Base.Errors.Service.ConnectionError).RetryAsync(3).WrapAsync(_policyProvider.DefaultPolicy<T>(5))
			.ExecuteAsync((CancellationToken t) => func(t).CatchErrors<T, E>(), cancellationToken));
	}
}
