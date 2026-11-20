using System;

namespace Polly.CircuitBreaker;

public class BrokenCircuitException : ExecutionRejectedException
{
	internal const string DefaultMessage = "The circuit is now open and is not allowing calls.";

	public TimeSpan? RetryAfter { get; }

	public BrokenCircuitException()
		: base("The circuit is now open and is not allowing calls.")
	{
	}

	public BrokenCircuitException(TimeSpan retryAfter)
		: base($"The circuit is now open and is not allowing calls. It can be retried after '{retryAfter}'.")
	{
		RetryAfter = retryAfter;
	}

	public BrokenCircuitException(string message)
		: base(message)
	{
	}

	public BrokenCircuitException(string message, TimeSpan retryAfter)
		: base(message)
	{
		RetryAfter = retryAfter;
	}

	public BrokenCircuitException(string message, Exception inner)
		: base(message, inner)
	{
	}

	public BrokenCircuitException(string message, TimeSpan retryAfter, Exception inner)
		: base(message, inner)
	{
		RetryAfter = retryAfter;
	}
}
