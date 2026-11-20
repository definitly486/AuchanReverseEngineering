using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal sealed class HttpConnectionWaiter<T> : TaskCompletionSourceWithCancellation<T> where T : HttpConnectionBase
{
	public CancellationTokenSource ConnectionCancellationTokenSource;

	public bool CancelledByOriginatingRequestCompletion { get; set; }

	public ValueTask<T> WaitForConnectionAsync(HttpRequestMessage request, HttpConnectionPool pool, bool async, CancellationToken requestCancellationToken)
	{
		HttpTelemetry.Log.IsEnabled();
		if (false)
		{
		}
		if (false)
		{
		}
		if (0 == 0)
		{
			return WaitWithCancellationAsync(async, requestCancellationToken);
		}
		return WaitForConnectionWithTelemetryAsync(request, pool, async, requestCancellationToken);
	}

	private async ValueTask<T> WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, bool async, CancellationToken requestCancellationToken)
	{
		Stopwatch.GetTimestamp();
		using Activity waitForConnectionActivity = ConnectionSetupDistributedTracing.StartWaitForConnectionActivity(pool.OriginAuthority);
		try
		{
			return await WaitWithCancellationAsync(async, requestCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception exception) when (waitForConnectionActivity != null)
		{
			ConnectionSetupDistributedTracing.ReportError(waitForConnectionActivity, exception);
			throw;
		}
		finally
		{
			HttpTelemetry.Log.IsEnabled();
			if (0 == 0)
			{
			}
		}
	}

	public bool TrySignal(T connection)
	{
		if (TrySetResult(connection))
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return true;
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return false;
	}

	public void SetTimeoutToPendingConnectionAttempt(HttpConnectionPool pool, bool requestCancelled)
	{
		int pendingConnectionTimeoutOnRequestCompletion = GlobalHttpSettings.SocketsHttpHandler.PendingConnectionTimeoutOnRequestCompletion;
		if (ConnectionCancellationTokenSource == null || pendingConnectionTimeoutOnRequestCompletion == -1 || (pool.Settings._connectTimeout != Timeout.InfiniteTimeSpan && pendingConnectionTimeoutOnRequestCompletion > (int)pool.Settings._connectTimeout.TotalMilliseconds))
		{
			return;
		}
		lock (this)
		{
			if (ConnectionCancellationTokenSource != null)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				CancelledByOriginatingRequestCompletion = true;
				if (pendingConnectionTimeoutOnRequestCompletion > 0)
				{
					ConnectionCancellationTokenSource.CancelAfter(pendingConnectionTimeoutOnRequestCompletion);
				}
				else
				{
					ConnectionCancellationTokenSource.Cancel();
				}
			}
		}
	}
}
