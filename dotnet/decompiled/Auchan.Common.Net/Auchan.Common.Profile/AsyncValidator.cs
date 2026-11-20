using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Profile;

internal sealed class AsyncValidator<TResult> : IDisposable
{
	private int _requestId;

	private CancellationTokenSource? _cts;

	private readonly Func<CancellationToken, Task<TResult>> _validateAsync;

	private readonly Action<TResult> _setter;

	public AsyncValidator(Func<CancellationToken, Task<TResult>> validateAsync, Action<TResult> setter)
	{
		_validateAsync = validateAsync;
		_setter = setter;
	}

	public async Task ValidateAsync()
	{
		int rid = Interlocked.Increment(ref _requestId);
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		CancellationTokenSource? cancellationTokenSource2 = Interlocked.Exchange(ref _cts, cancellationTokenSource);
		cancellationTokenSource2?.Cancel();
		cancellationTokenSource2?.Dispose();
		TResult obj;
		try
		{
			obj = await _validateAsync(cancellationTokenSource.Token);
		}
		catch (TaskCanceledException)
		{
			return;
		}
		if (rid == _requestId)
		{
			_setter(obj);
		}
	}

	public void Dispose()
	{
		_cts?.Cancel();
		_cts?.Dispose();
		_cts = null;
	}
}
