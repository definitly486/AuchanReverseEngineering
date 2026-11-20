using System;

namespace Polly.CircuitBreaker;

public class BrokenCircuitException<TResult> : BrokenCircuitException
{
	public TResult Result { get; }

	public BrokenCircuitException(TResult result)
	{
		Result = result;
	}

	public BrokenCircuitException(string message, TResult result)
		: base(message)
	{
		Result = result;
	}

	public BrokenCircuitException(string message, Exception inner, TResult result)
		: base(message, inner)
	{
		Result = result;
	}
}
