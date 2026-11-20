using Auchan.Common.Base.Errors.Service;
using CSharpFunctionalExtensions;
using Polly;
using Polly.Timeout;

namespace Auchan.Common.Networking;

public interface IPolicyProvider
{
	AsyncPolicy<Result<TResult, ServiceError>> DefaultPolicy<TResult>(int seconds, TimeoutStrategy timeoutStrategy = TimeoutStrategy.Optimistic);
}
