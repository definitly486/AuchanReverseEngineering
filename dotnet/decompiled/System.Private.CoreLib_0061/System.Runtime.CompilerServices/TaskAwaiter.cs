using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices;

public readonly struct TaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion, ITaskAwaiter
{
	internal readonly Task m_task;

	public bool IsCompleted => m_task.IsCompleted;

	internal TaskAwaiter(Task task)
	{
		m_task = task;
	}

	public void OnCompleted(Action continuation)
	{
		OnCompletedInternal(m_task, continuation, continueOnCapturedContext: true, flowExecutionContext: true);
	}

	public void UnsafeOnCompleted(Action continuation)
	{
		OnCompletedInternal(m_task, continuation, continueOnCapturedContext: true, flowExecutionContext: false);
	}

	[StackTraceHidden]
	public void GetResult()
	{
		ValidateEnd(m_task);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[StackTraceHidden]
	internal static void ValidateEnd(Task task, ConfigureAwaitOptions options = ConfigureAwaitOptions.None)
	{
		if (task.IsWaitNotificationEnabledOrNotRanToCompletion)
		{
			HandleNonSuccessAndDebuggerNotification(task, options);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[StackTraceHidden]
	private static void HandleNonSuccessAndDebuggerNotification(Task task, ConfigureAwaitOptions options)
	{
		if (!task.IsCompleted)
		{
			task.InternalWait(-1, default(CancellationToken));
		}
		task.NotifyDebuggerOfWaitCompletionIfNecessary();
		if (!task.IsCompletedSuccessfully)
		{
			if ((options & ConfigureAwaitOptions.SuppressThrowing) == 0)
			{
				ThrowForNonSuccess(task);
			}
			task.MarkExceptionsAsHandled();
		}
	}

	[StackTraceHidden]
	private static void ThrowForNonSuccess(Task task)
	{
		switch (task.Status)
		{
		case TaskStatus.Canceled:
			task.GetCancellationExceptionDispatchInfo()?.Throw();
			throw new TaskCanceledException(task);
		case TaskStatus.Faulted:
		{
			List<ExceptionDispatchInfo> exceptionDispatchInfos = task.GetExceptionDispatchInfos();
			if (exceptionDispatchInfos.Count > 0)
			{
				exceptionDispatchInfos[0].Throw();
				break;
			}
			throw task.Exception;
		}
		}
	}

	internal static void OnCompletedInternal(Task task, Action continuation, bool continueOnCapturedContext, bool flowExecutionContext)
	{
		ArgumentNullException.ThrowIfNull(continuation, "continuation");
		TplEventSource.Log.IsEnabled();
		if (Task.s_asyncDebuggingEnabled)
		{
		}
		task.SetContinuationForAwait(continuation, continueOnCapturedContext, flowExecutionContext);
	}

	internal static void UnsafeOnCompletedInternal(Task task, IAsyncStateMachineBox stateMachineBox, bool continueOnCapturedContext)
	{
		TplEventSource.Log.IsEnabled();
		if (Task.s_asyncDebuggingEnabled)
		{
		}
		task.UnsafeSetContinuationForAwait(stateMachineBox, continueOnCapturedContext);
	}

	private static Action OutputWaitEtwEvents(Task task, Action continuation)
	{
		if (Task.s_asyncDebuggingEnabled)
		{
		}
		TplEventSource log = TplEventSource.Log;
		if (log.IsEnabled())
		{
		}
		return AsyncMethodBuilderCore.CreateContinuationWrapper(continuation, delegate(Action innerContinuation, Task innerTask)
		{
			if (Task.s_asyncDebuggingEnabled)
			{
			}
			TplEventSource log2 = TplEventSource.Log;
			Guid oldActivityThatWillContinue = default(Guid);
			bool num = log2.IsEnabled();
			if (num)
			{
				Task internalCurrent = Task.InternalCurrent;
				log2.TaskWaitEnd(internalCurrent?.m_taskScheduler.Id ?? TaskScheduler.Default.Id, internalCurrent?.Id ?? 0, innerTask.Id);
				if (log2.TasksSetActivityIds && (innerTask.Options & (TaskCreationOptions)1024) != TaskCreationOptions.None)
				{
					EventSource.SetCurrentThreadActivityId(TplEventSource.CreateGuidForTaskID(innerTask.Id), out oldActivityThatWillContinue);
				}
			}
			innerContinuation();
			if (num)
			{
				log2.TaskWaitContinuationComplete(innerTask.Id);
				if (log2.TasksSetActivityIds && (innerTask.Options & (TaskCreationOptions)1024) != TaskCreationOptions.None)
				{
					EventSource.SetCurrentThreadActivityId(oldActivityThatWillContinue);
				}
			}
		}, task);
	}
}
public readonly struct TaskAwaiter<TResult> : ICriticalNotifyCompletion, INotifyCompletion, ITaskAwaiter
{
	private readonly Task<TResult> m_task;

	public bool IsCompleted => m_task.IsCompleted;

	internal TaskAwaiter(Task<TResult> task)
	{
		m_task = task;
	}

	public void OnCompleted(Action continuation)
	{
		TaskAwaiter.OnCompletedInternal(m_task, continuation, continueOnCapturedContext: true, flowExecutionContext: true);
	}

	public void UnsafeOnCompleted(Action continuation)
	{
		TaskAwaiter.OnCompletedInternal(m_task, continuation, continueOnCapturedContext: true, flowExecutionContext: false);
	}

	[StackTraceHidden]
	public TResult GetResult()
	{
		TaskAwaiter.ValidateEnd(m_task);
		return m_task.ResultOnSuccess;
	}
}
