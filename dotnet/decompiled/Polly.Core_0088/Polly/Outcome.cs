using System;
using System.Runtime.ExceptionServices;
using Polly.Utils;

namespace Polly;

public static class Outcome
{
	internal static Outcome<VoidResult> Void => FromResult(VoidResult.Instance);

	public static Outcome<TResult> FromResult<TResult>(TResult? value)
	{
		return new Outcome<TResult>(value);
	}

	public static Outcome<TResult> FromException<TResult>(Exception exception)
	{
		Guard.NotNull(exception, "exception");
		return new Outcome<TResult>(exception);
	}

	internal static Outcome<VoidResult> FromException(Exception exception)
	{
		return FromException<VoidResult>(exception);
	}
}
public readonly struct Outcome<TResult>
{
	public Exception? Exception => ExceptionDispatchInfo?.SourceException;

	internal ExceptionDispatchInfo? ExceptionDispatchInfo { get; }

	public TResult? Result { get; }

	internal Outcome(Exception exception)
	{
		this = default(Outcome<TResult>);
		ExceptionDispatchInfo = System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(Guard.NotNull(exception, "exception"));
	}

	internal Outcome(TResult? result)
	{
		this = default(Outcome<TResult>);
		Result = result;
	}

	public override string ToString()
	{
		object obj;
		if (ExceptionDispatchInfo == null)
		{
			TResult result = Result;
			obj = ((result != null) ? result.ToString() : null);
			if (obj == null)
			{
				return string.Empty;
			}
		}
		else
		{
			obj = Exception.Message;
		}
		return (string)obj;
	}

	internal TResult GetResultOrRethrow()
	{
		ExceptionDispatchInfo?.Throw();
		return Result;
	}
}
