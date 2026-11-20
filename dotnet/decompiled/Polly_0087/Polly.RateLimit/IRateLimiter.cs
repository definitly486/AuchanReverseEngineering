using System;

namespace Polly.RateLimit;

internal interface IRateLimiter
{
	(bool PermitExecution, TimeSpan RetryAfter) PermitExecution();
}
