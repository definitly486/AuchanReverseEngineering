using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polly.Retry;

namespace Polly;

public static class AsyncRetrySyntax
{
	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder)
	{
		return policyBuilder.RetryAsync(1);
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount)
	{
		return policyBuilder.RetryAsync(retryCount, (Action<Exception, int, Context>)EmptyHandler);
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
	{
		return policyBuilder.RetryAsync(1, async delegate(Exception outcome, int i, Context _)
		{
			onRetry(outcome, i);
		});
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Task> onRetryAsync)
	{
		return policyBuilder.RetryAsync(1, (Exception outcome, int i, Context _) => onRetryAsync(outcome, i));
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryAsync(retryCount, async delegate(Exception outcome, int i, Context _)
		{
			onRetry(outcome, i);
		});
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<Exception, int, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.RetryAsync(retryCount, (Exception outcome, int i, Context _) => onRetryAsync(outcome, i));
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
	{
		return policyBuilder.RetryAsync(1, onRetry);
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Context, Task> onRetryAsync)
	{
		return policyBuilder.RetryAsync(1, onRetryAsync);
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryAsync(retryCount, async delegate(Exception outcome, int i, Context ctx)
		{
			onRetry(outcome, i, ctx);
		});
	}

	public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<Exception, int, Context, Task> onRetryAsync)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan _, int i, Context ctx) => onRetryAsync(outcome, i, ctx), retryCount);
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder)
	{
		return policyBuilder.RetryForeverAsync((Action<Exception>)delegate
		{
		});
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, Context _)
		{
			onRetry(outcome);
		});
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, int i, Context _)
		{
			onRetry(outcome, i);
		});
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.RetryForeverAsync((Exception outcome, Context _) => onRetryAsync(outcome));
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.RetryForeverAsync((Exception outcome, int i, Context _) => onRetryAsync(outcome, i));
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, Context ctx)
		{
			onRetry(outcome, ctx);
		});
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, int i, Context ctx)
		{
			onRetry(outcome, i, ctx);
		});
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, Context, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan _, int _, Context ctx) => onRetryAsync(outcome, ctx));
	}

	public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Context, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan _, int i, Context ctx) => onRetryAsync(outcome, i, ctx));
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Action<Exception, TimeSpan>)EmptyHandler);
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan span, int _, Context _)
		{
			onRetry(outcome, span);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Exception outcome, TimeSpan span, int _, Context _) => onRetryAsync(outcome, span));
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan span, int _, Context ctx)
		{
			onRetry(outcome, span, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Exception outcome, TimeSpan timespan, int _, Context ctx) => onRetryAsync(outcome, timespan, ctx));
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
		{
			onRetry(outcome, timespan, i, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		IEnumerable<TimeSpan> sleepDurationsEnumerable = Enumerable.Range(1, retryCount).Select(sleepDurationProvider);
		return new AsyncRetryPolicy(policyBuilder, onRetryAsync, retryCount, sleepDurationsEnumerable);
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan span, int _, Context ctx)
		{
			onRetry(outcome, span, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Exception outcome, TimeSpan timespan, int _, Context ctx) => onRetryAsync(outcome, timespan, ctx));
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
		{
			onRetry(outcome, timespan, i, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		return policyBuilder.WaitAndRetryAsync(retryCount, (int i, Exception _, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
	{
		if (retryCount < 0)
		{
			throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
		}
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, onRetryAsync, retryCount, null, sleepDurationProvider);
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations)
	{
		return policyBuilder.WaitAndRetryAsync(sleepDurations, (Action<Exception, TimeSpan, Context>)EmptyHandlerWithContext);
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(Exception outcome, TimeSpan timespan, int _, Context _)
		{
			onRetry(outcome, timespan);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<Exception, TimeSpan, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryAsync(sleepDurations, (Exception outcome, TimeSpan timespan, int _, Context _) => onRetryAsync(outcome, timespan));
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(Exception outcome, TimeSpan timespan, int _, Context ctx)
		{
			onRetry(outcome, timespan, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
	{
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryAsync(sleepDurations, (Exception outcome, TimeSpan timespan, int _, Context ctx) => onRetryAsync(outcome, timespan, ctx));
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, int, Context> onRetry)
	{
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
		{
			onRetry(outcome, timespan, i, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
	{
		if (sleepDurations == null)
		{
			throw new ArgumentNullException("sleepDurations");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, onRetryAsync, int.MaxValue, sleepDurations);
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, (Action<Exception, TimeSpan>)EmptyHandler);
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider)
	{
		return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, (Action<Exception, TimeSpan, Context>)EmptyHandlerWithContext);
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context _) => sleepDurationProvider(retryCount), delegate(Exception exception, TimeSpan timespan, Context _)
		{
			onRetry(exception, timespan);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context _) => sleepDurationProvider(retryCount), delegate(Exception exception, int i, TimeSpan timespan, Context _)
		{
			onRetry(exception, i, timespan);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context _) => sleepDurationProvider(retryCount), (Exception exception, TimeSpan timespan, Context _) => onRetryAsync(exception, timespan));
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, int, TimeSpan, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context _) => sleepDurationProvider(retryCount), (Exception exception, int i, TimeSpan timespan, Context _) => onRetryAsync(exception, i, timespan));
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, async delegate(Exception exception, TimeSpan timespan, Context ctx)
		{
			onRetry(exception, timespan, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan, Context> onRetry)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetry == null)
		{
			throw new ArgumentNullException("onRetry");
		}
		return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, async delegate(Exception exception, int i, TimeSpan timespan, Context ctx)
		{
			onRetry(exception, i, timespan, ctx);
		});
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		return policyBuilder.WaitAndRetryForeverAsync((int i, Exception _, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, int, TimeSpan, Context, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		return policyBuilder.WaitAndRetryForeverAsync((int i, Exception _, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan timespan, int _, Context ctx) => onRetryAsync(outcome, timespan, ctx), int.MaxValue, null, sleepDurationProvider);
	}

	public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Func<Exception, int, TimeSpan, Context, Task> onRetryAsync)
	{
		if (sleepDurationProvider == null)
		{
			throw new ArgumentNullException("sleepDurationProvider");
		}
		if (onRetryAsync == null)
		{
			throw new ArgumentNullException("onRetryAsync");
		}
		return new AsyncRetryPolicy(policyBuilder, (Exception exception, TimeSpan timespan, int i, Context ctx) => onRetryAsync(exception, i, timespan, ctx), int.MaxValue, null, sleepDurationProvider);
	}

	private static void EmptyHandler(Exception exception, int retryCount, Context context)
	{
	}

	private static void EmptyHandler(Exception exception, TimeSpan duration)
	{
	}

	private static void EmptyHandlerWithContext(Exception exception, TimeSpan duration, Context context)
	{
	}
}
