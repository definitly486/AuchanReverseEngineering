using System;
using System.Threading;
using Polly.Utilities;

namespace Polly.RateLimit;

internal sealed class LockFreeTokenBucketRateLimiter : IRateLimiter
{
	private readonly long _addTokenTickInterval;

	private readonly long _bucketCapacity;

	private long _currentTokens;

	private long _addNextTokenAtTicks;

	private SpinWait _spinner;

	public LockFreeTokenBucketRateLimiter(TimeSpan onePer, long bucketCapacity)
	{
		_addTokenTickInterval = onePer.Ticks;
		_bucketCapacity = bucketCapacity;
		_currentTokens = bucketCapacity;
		_addNextTokenAtTicks = SystemClock.DateTimeOffsetUtcNow().Ticks + _addTokenTickInterval;
	}

	public (bool PermitExecution, TimeSpan RetryAfter) PermitExecution()
	{
		long num3;
		while (true)
		{
			if (Interlocked.Decrement(ref _currentTokens) >= 0)
			{
				return (PermitExecution: true, RetryAfter: TimeSpan.Zero);
			}
			long ticks = SystemClock.DateTimeOffsetUtcNow().Ticks;
			long num = Interlocked.Read(ref _addNextTokenAtTicks);
			long num2 = num - ticks;
			if (num2 > 0)
			{
				return (PermitExecution: false, RetryAfter: TimeSpan.FromTicks(num2));
			}
			long val = 1 + -num2 / _addTokenTickInterval;
			num3 = Math.Min(_bucketCapacity, val);
			long val2 = num + num3 * _addTokenTickInterval;
			val2 = Math.Max(val2, ticks + _addTokenTickInterval);
			if (Interlocked.CompareExchange(ref _addNextTokenAtTicks, val2, num) == num)
			{
				break;
			}
			_spinner.SpinOnce();
		}
		Interlocked.Exchange(ref _currentTokens, num3 - 1);
		return (PermitExecution: true, RetryAfter: TimeSpan.Zero);
	}
}
