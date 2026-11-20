using System;
using System.Collections.Generic;
using System.Linq;
using Polly.Retry;

namespace Polly;

public static class RetrySyntax
{
	public static RetryPolicy Retry(this PolicyBuilder policyBuilder)
	{
		return policyBuilder.Retry(1);
	}

	public static RetryPolicy Retry(this PolicyBuilder policyBuilder, int retryCount)
	{
		return policyBuilder.Retry(retryCount, (Action<Exception, int>)delegate
		{
		});
	}

	public static RetryPolicy Retry(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
	{
		return policyBuilder.Retry(1, onRetry);
	}

	public static RetryPolicy Retry(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int> onRetry)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.Retry(retryCount, delegate(Exception outcome, int i, Context _)
		{
			onRetry(outcome, i);
		});
	}

	public static RetryPolicy Retry(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
	{
		return policyBuilder.Retry(1, onRetry);
	}

	public static RetryPolicy Retry(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int, Context> onRetry)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan _, int i, Context ctx)
		{
			onRetry(outcome, i, ctx);
		}, retryCount);
	}

	public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder)
	{
		return policyBuilder.RetryForever((Action<Exception>)delegate
		{
		});
	}

	public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryForever(delegate(Exception outcome, Context _)
		{
			onRetry(outcome);
		});
	}

	public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryForever(delegate(Exception outcome, int i, Context _)
		{
			onRetry(outcome, i);
		});
	}

	public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan _, int _, Context ctx)
		{
			onRetry(outcome, ctx);
		});
	}

	public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan _, int i, Context ctx)
		{
			onRetry(outcome, i, ctx);
		});
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, EmptyHandlerWithContext);
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(Exception outcome, TimeSpan span, int _, Context _)
		{
			onRetry(outcome, span);
		});
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(Exception outcome, TimeSpan span, int _, Context ctx)
		{
			onRetry(outcome, span, ctx);
		});
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		IEnumerable<TimeSpan> sleepDurationsEnumerable = Enumerable.Range(1, retryCount).Select(sleepDurationProvider);
		return new RetryPolicy(policyBuilder, onRetry, retryCount, sleepDurationsEnumerable);
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, EmptyHandlerWithContext);
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(Exception outcome, TimeSpan span, int _, Context ctx)
		{
			onRetry(outcome, span, ctx);
		});
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		return policyBuilder.WaitAndRetry(retryCount, (int i, Exception _, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, onRetry, retryCount, null, sleepDurationProvider);
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations)
	{
		return policyBuilder.WaitAndRetry(sleepDurations, EmptyHandler);
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetry(sleepDurations, delegate(Exception outcome, TimeSpan span, int _, Context _)
		{
			onRetry(outcome, span);
		});
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetry(sleepDurations, delegate(Exception outcome, TimeSpan span, int _, Context ctx)
		{
			onRetry(outcome, span, ctx);
		});
	}

	public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (sleepDurations == null)
		{
			throw new ArgumentNullException("sleepDurations");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, onRetry, int.MaxValue, sleepDurations);
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetryForever(sleepDurationProvider, EmptyHandler);
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetryForever(sleepDurationProvider, (Action<Exception, TimeSpan, Context>)delegate
		{
		});
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryForever((int retryCount, Context _) => sleepDurationProvider(retryCount), delegate(Exception exception, TimeSpan timespan, Context _)
		{
			onRetry(exception, timespan);
		});
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryForever((int retryCount, Exception _, Context _) => sleepDurationProvider(retryCount), delegate(Exception exception, int i, TimeSpan timespan, Context _)
		{
			onRetry(exception, i, timespan);
		});
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		return policyBuilder.WaitAndRetryForever((int i, Exception _, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		return policyBuilder.WaitAndRetryForever((int i, Exception _, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan timespan, int _, Context ctx)
		{
			onRetry(outcome, timespan, ctx);
		}, int.MaxValue, null, sleepDurationProvider);
	}

	public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return new RetryPolicy(policyBuilder, delegate(Exception exception, TimeSpan timespan, int i, Context ctx)
		{
			onRetry(exception, i, timespan, ctx);
		}, int.MaxValue, null, sleepDurationProvider);
	}

	private static void EmptyHandler(Exception exception, TimeSpan retryAfter)
	{
	}

	private static void EmptyHandlerWithContext(Exception exception, TimeSpan retryAfter, int attempts, Context context)
	{
	}
}
