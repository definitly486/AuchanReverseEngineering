using System.Threading;

namespace System.Reactive.Concurrency;

internal static class SynchronizationContextExtensions
{
	public static void PostWithStartComplete(this SynchronizationContext context, Action action)
	{
		context.OperationStarted();
		context.Post(delegate
		{
			try
			{
				action();
			}
			finally
			{
				context.OperationCompleted();
			}
		}, null);
	}
}
