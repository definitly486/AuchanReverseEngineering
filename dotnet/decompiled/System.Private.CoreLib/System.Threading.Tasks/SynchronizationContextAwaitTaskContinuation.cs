using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace System.Threading.Tasks;

internal sealed class SynchronizationContextAwaitTaskContinuation : AwaitTaskContinuation
{
	private static readonly SendOrPostCallback s_postCallback = delegate(object state)
	{
		((Action)state)();
	};

	private static ContextCallback s_postActionCallback;

	private readonly SynchronizationContext m_syncContext;

	internal SynchronizationContextAwaitTaskContinuation(SynchronizationContext context, Action action, bool flowExecutionContext)
		: base(action, flowExecutionContext)
	{
		m_syncContext = context;
	}

	internal sealed override void Run(Task task, bool canInlineContinuationTask)
	{
		if (canInlineContinuationTask && m_syncContext == SynchronizationContext.Current)
		{
			RunCallback(AwaitTaskContinuation.GetInvokeActionCallback(), m_action, ref Task.t_currentTask);
			return;
		}
		TplEventSource log = TplEventSource.Log;
		if (log.IsEnabled())
		{
		}
		RunCallback(GetPostActionCallback(), this, ref Task.t_currentTask);
	}

	private static void PostAction(object state)
	{
		SynchronizationContextAwaitTaskContinuation synchronizationContextAwaitTaskContinuation = (SynchronizationContextAwaitTaskContinuation)state;
		TplEventSource log = TplEventSource.Log;
		if (log.IsEnabled())
		{
		}
		synchronizationContextAwaitTaskContinuation.m_syncContext.Post(s_postCallback, synchronizationContextAwaitTaskContinuation.m_action);
	}

	private static Action GetActionLogDelegate(int continuationId, Action action)
	{
		return delegate
		{
			EventSource.SetCurrentThreadActivityId(TplEventSource.CreateGuidForTaskID(continuationId), out var oldActivityThatWillContinue);
			try
			{
				action();
			}
			finally
			{
				EventSource.SetCurrentThreadActivityId(oldActivityThatWillContinue);
			}
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ContextCallback GetPostActionCallback()
	{
		return PostAction;
	}
}
