using System;
using System.Threading;
using Polly.Utilities;

namespace Polly.CircuitBreaker;

internal abstract class CircuitStateController<TResult> : ICircuitController<TResult>
{
	protected readonly TimeSpan DurationOfBreak;

	protected readonly Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> OnBreak;

	protected readonly Action<Context> OnReset;

	protected readonly Action OnHalfOpen;

	protected readonly object Lock = new object();

	protected long BlockedTill;

	protected CircuitState InternalCircuitState;

	protected DelegateResult<TResult> LastOutcome;

	public CircuitState CircuitState
	{
		get
		{
			if (InternalCircuitState != CircuitState.Open)
			{
				return InternalCircuitState;
			}
			using (TimedLock.Lock(Lock))
			{
				if (InternalCircuitState == CircuitState.Open && !IsInAutomatedBreak_NeedsLock)
				{
					InternalCircuitState = CircuitState.HalfOpen;
					OnHalfOpen();
				}
				return InternalCircuitState;
			}
		}
	}

	public Exception LastException
	{
		get
		{
			using (TimedLock.Lock(Lock))
			{
				return LastOutcome?.Exception;
			}
		}
	}

	public TResult LastHandledResult
	{
		get
		{
			using (TimedLock.Lock(Lock))
			{
				return (LastOutcome != null) ? LastOutcome.Result : default(TResult);
			}
		}
	}

	protected bool IsInAutomatedBreak_NeedsLock => SystemClock.UtcNow().Ticks < BlockedTill;

	protected CircuitStateController(TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
	{
		DurationOfBreak = durationOfBreak;
		OnBreak = onBreak;
		OnReset = onReset;
		OnHalfOpen = onHalfOpen;
		InternalCircuitState = CircuitState.Closed;
		Reset();
	}

	public void Isolate()
	{
		using (TimedLock.Lock(Lock))
		{
			LastOutcome = new DelegateResult<TResult>(new IsolatedCircuitException("The circuit is manually held open and is not allowing calls."));
			BreakFor_NeedsLock(TimeSpan.MaxValue, Context.None());
			InternalCircuitState = CircuitState.Isolated;
		}
	}

	protected void Break_NeedsLock(Context context)
	{
		BreakFor_NeedsLock(DurationOfBreak, context);
	}

	private void BreakFor_NeedsLock(TimeSpan durationOfBreak, Context context)
	{
		ulong ticks = (ulong)SystemClock.UtcNow().Ticks;
		ulong ticks2 = (ulong)durationOfBreak.Ticks;
		BlockedTill = (long)Math.Min(ticks + ticks2, (ulong)DateTime.MaxValue.Ticks);
		CircuitState internalCircuitState = InternalCircuitState;
		InternalCircuitState = CircuitState.Open;
		OnBreak(LastOutcome, internalCircuitState, durationOfBreak, context);
	}

	public void Reset()
	{
		OnCircuitReset(Context.None());
	}

	protected void ResetInternal_NeedsLock(Context context)
	{
		BlockedTill = DateTime.MinValue.Ticks;
		LastOutcome = null;
		CircuitState internalCircuitState = InternalCircuitState;
		InternalCircuitState = CircuitState.Closed;
		if (internalCircuitState != CircuitState.Closed)
		{
			OnReset(context);
		}
	}

	protected bool PermitHalfOpenCircuitTest()
	{
		long blockedTill = BlockedTill;
		if (SystemClock.UtcNow().Ticks < blockedTill)
		{
			return false;
		}
		return Interlocked.CompareExchange(ref BlockedTill, SystemClock.UtcNow().Ticks + DurationOfBreak.Ticks, blockedTill) == blockedTill;
	}

	private BrokenCircuitException GetBreakingException()
	{
		DelegateResult<TResult> lastOutcome = LastOutcome;
		if (lastOutcome == null)
		{
			return new BrokenCircuitException("The circuit is now open and is not allowing calls.");
		}
		if (lastOutcome.Exception != null)
		{
			return new BrokenCircuitException("The circuit is now open and is not allowing calls.", lastOutcome.Exception);
		}
		return new BrokenCircuitException<TResult>("The circuit is now open and is not allowing calls.", lastOutcome.Result);
	}

	public void OnActionPreExecute()
	{
		switch (CircuitState)
		{
		case CircuitState.HalfOpen:
			if (!PermitHalfOpenCircuitTest())
			{
				throw GetBreakingException();
			}
			break;
		case CircuitState.Open:
			throw GetBreakingException();
		case CircuitState.Isolated:
			throw new IsolatedCircuitException("The circuit is manually held open and is not allowing calls.");
		default:
			throw new InvalidOperationException("Unhandled CircuitState.");
		case CircuitState.Closed:
			break;
		}
	}

	public abstract void OnActionSuccess(Context context);

	public abstract void OnActionFailure(DelegateResult<TResult> outcome, Context context);

	public abstract void OnCircuitReset(Context context);
}
