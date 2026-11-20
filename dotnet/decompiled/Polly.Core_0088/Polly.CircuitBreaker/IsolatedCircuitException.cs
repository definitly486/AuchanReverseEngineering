using System;

namespace Polly.CircuitBreaker;

public class IsolatedCircuitException : BrokenCircuitException
{
	public IsolatedCircuitException()
		: base("The circuit is manually held open and is not allowing calls.")
	{
	}

	public IsolatedCircuitException(string message)
		: base(message)
	{
	}

	public IsolatedCircuitException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
