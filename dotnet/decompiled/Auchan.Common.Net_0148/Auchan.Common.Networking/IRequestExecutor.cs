using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;
using Polly.Timeout;

namespace Auchan.Common.Networking;

public interface IRequestExecutor
{
	Task<Result<T, ServiceError>> Execute<T>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class
	{
		return Execute<T, T>(func, cancellationToken, timeoutStrategy);
	}

	Task<Result<T, ServiceError>> ExecuteWithExtendedTimeout<T>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class
	{
		return ExecuteWithExtendedTimeout<T, T>(func, cancellationToken, timeoutStrategy);
	}

	Task<Result<T, ServiceError>> ExecuteWithCustomTimeout<T>(Func<CancellationToken, Task<T>> func, int timeout, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class
	{
		return ExecuteWithCustomTimeout<T, T>(func, timeout, cancellationToken, timeoutStrategy);
	}

	Task<Result<T, ServiceError>> ExecuteWithToken<T>(Func<CancellationToken, TokenModel, Task<T>> func, TokenLevel tokenNumber = TokenLevel.L80, CancellationToken cancellationToken = default(CancellationToken)) where T : class
	{
		return ExecuteWithToken<T, T>(func, tokenNumber, cancellationToken);
	}

	Task<Result<T, ServiceError>> ExecuteWithTokenAndCustomTimeout<T>(Func<CancellationToken, TokenModel, Task<T>> func, int timeoutInSeconds, TokenLevel tokenNumber = TokenLevel.L80, CancellationToken cancellationToken = default(CancellationToken)) where T : class
	{
		return ExecuteWithTokenAndCustomTimeout<T, T>(func, timeoutInSeconds, tokenNumber, cancellationToken);
	}

	Task<Result<T, ServiceError>> ExecuteWithRetryOnConnectionErrorPolicy<T>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken)) where T : class
	{
		return ExecuteWithRetryOnConnectionErrorPolicy<T, T>(func, cancellationToken);
	}

	Task<Result<T, ServiceError>> ExecuteWithToken<T, E>(Func<CancellationToken, TokenModel, Task<T>> func, TokenLevel tokenNumber = TokenLevel.L80, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class;

	Task<Result<T, ServiceError>> ExecuteWithCustomTimeout<T, E>(Func<CancellationToken, Task<T>> func, int timeout, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class;

	Task<Result<T, ServiceError>> ExecuteWithExtendedTimeout<T, E>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class;

	Task<Result<T, ServiceError>> Execute<T, E>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken), TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic) where T : class where E : class;

	Task<Result<T, ServiceError>> ExecuteWithRetryOnConnectionErrorPolicy<T, E>(Func<CancellationToken, Task<T>> func, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class;

	Task<Result<T, ServiceError>> ExecuteWithTokenAndCustomTimeout<T, E>(Func<CancellationToken, TokenModel, Task<T>> func, int timeoutInSeconds, TokenLevel tokenNumber = TokenLevel.L80, CancellationToken cancellationToken = default(CancellationToken)) where T : class where E : class;
}
