using System;
using Polly.Telemetry;

namespace Polly;

public abstract class ExecutionRejectedException : Exception
{
	public virtual ResilienceTelemetrySource? TelemetrySource { get; internal set; }

	protected ExecutionRejectedException()
	{
	}

	protected ExecutionRejectedException(string message)
		: base(message)
	{
	}

	protected ExecutionRejectedException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
