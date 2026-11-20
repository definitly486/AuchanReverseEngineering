using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Service;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Networking;
using Polly;
using Polly.Retry;
using Polly.Timeout;

namespace Auchan.Common.Networking;

internal sealed class PolicyProvider : IPolicyProvider
{
	public AsyncPolicy<Result<TResult, ServiceError>> DefaultPolicy<TResult>(int seconds, TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic)
	{
		new ConnectivityChangedEventArgs(Connectivity.NetworkAccess, Connectivity.ConnectionProfiles);
		DateTime timeStamp = DateTime.UtcNow;
		AsyncRetryPolicy<Result<TResult, ServiceError>> asyncRetryPolicy = Policy.HandleResult<Result<TResult, ServiceError>>(CheckIfTimeoutIsTooLong).RetryAsync((DelegateResult<Result<TResult, ServiceError>> delegatingResult, int retryAttempt, Context context) => Task.CompletedTask);
		AsyncTimeoutPolicy<Result<TResult, ServiceError>> innerPolicy = Policy.TimeoutAsync<Result<TResult, ServiceError>>(seconds, timeoutStrategy);
		return asyncRetryPolicy.WrapAsync(innerPolicy);
		bool CheckIfTimeoutIsTooLong(Result<TResult, ServiceError> r)
		{
			bool result = false;
			new ConnectivityChangedEventArgs(Connectivity.NetworkAccess, Connectivity.ConnectionProfiles);
			bool num = r.IsFailure && r.Error is ConnectionError connectionError && connectionError.Type == ConnectionErrorType.NetworkChangedError;
			if (r.IsFailure)
			{
				_ = r.Error is CancellationError;
			}
			else
				_ = 0;
			bool flag = r.IsFailure && r.Error is VpnError;
			bool flag2 = r.IsFailure && r.Error is UnknownServiceError;
			int num2 = DeltaInSeconds();
			if (num)
			{
				result = true;
			}
			else if (flag && num2 > seconds)
			{
				result = true;
			}
			else if (flag2 && num2 > seconds)
			{
				result = true;
			}
			return result;
		}
		int DeltaInSeconds()
		{
			return (int)Math.Ceiling((DateTime.UtcNow - timeStamp).TotalSeconds);
		}
	}
}
