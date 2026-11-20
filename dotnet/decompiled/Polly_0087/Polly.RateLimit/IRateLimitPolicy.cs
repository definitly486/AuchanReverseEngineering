namespace Polly.RateLimit;

public interface IRateLimitPolicy : IsPolicy
{
}
public interface IRateLimitPolicy<TResult> : IRateLimitPolicy, IsPolicy
{
}
