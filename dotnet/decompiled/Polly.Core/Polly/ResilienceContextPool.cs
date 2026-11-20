using System.Threading;
using Polly.Utils;

namespace Polly;

public abstract class ResilienceContextPool
{
	private sealed class SharedPool : ResilienceContextPool
	{
		private readonly ObjectPool<ResilienceContext> _pool = new ObjectPool<ResilienceContext>(() => new ResilienceContext(), (ResilienceContext c) => c.Reset());

		public override ResilienceContext Get(ResilienceContextCreationArguments arguments)
		{
			ResilienceContext resilienceContext = _pool.Get();
			resilienceContext.OperationKey = arguments.OperationKey;
			resilienceContext.CancellationToken = arguments.CancellationToken;
			resilienceContext.ContinueOnCapturedContext = arguments.ContinueOnCapturedContext == true;
			return resilienceContext;
		}

		public override void Return(ResilienceContext context)
		{
			_pool.Return(Guard.NotNull(context, "context"));
		}
	}

	public static ResilienceContextPool Shared { get; } = new SharedPool();

	public ResilienceContext Get(string? operationKey, bool? continueOnCapturedContext, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Get(new ResilienceContextCreationArguments(operationKey, continueOnCapturedContext, cancellationToken));
	}

	public abstract ResilienceContext Get(ResilienceContextCreationArguments arguments);

	public abstract void Return(ResilienceContext context);
}
