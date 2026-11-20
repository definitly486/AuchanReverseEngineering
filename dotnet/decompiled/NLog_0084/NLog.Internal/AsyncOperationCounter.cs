using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;

namespace NLog.Internal;

internal sealed class AsyncOperationCounter
{
	private int _pendingOperationCounter;

	private readonly LinkedList<AsyncContinuation?> _pendingCompletionList = new LinkedList<AsyncContinuation>();

	public void BeginOperation()
	{
		Interlocked.Increment(ref _pendingOperationCounter);
	}

	public void CompleteOperation(Exception? exception)
	{
		NotifyCompletion(exception);
	}

	private int NotifyCompletion(Exception? exception)
	{
		int result = Interlocked.Decrement(ref _pendingOperationCounter);
		if (_pendingCompletionList.Count > 0)
		{
			lock (_pendingCompletionList)
			{
				LinkedListNode<AsyncContinuation> linkedListNode = _pendingCompletionList.First;
				while (linkedListNode != null)
				{
					AsyncContinuation value = linkedListNode.Value;
					linkedListNode = linkedListNode.Next;
					value?.Invoke(exception);
				}
			}
		}
		return result;
	}

	public AsyncContinuation RegisterCompletionNotification(AsyncContinuation asyncContinuation)
	{
		int remainingCompletionCounter = Interlocked.Increment(ref _pendingOperationCounter);
		if (remainingCompletionCounter <= 1)
		{
			if (NotifyCompletion(null) < 0)
			{
				Interlocked.Exchange(ref _pendingOperationCounter, 0);
			}
			return asyncContinuation;
		}
		lock (_pendingCompletionList)
		{
			if (NotifyCompletion(null) <= 0)
			{
				return asyncContinuation;
			}
			LinkedListNode<AsyncContinuation?> pendingCompletion = new LinkedListNode<AsyncContinuation>(null);
			_pendingCompletionList.AddLast(pendingCompletion);
			remainingCompletionCounter = Interlocked.Increment(ref _pendingOperationCounter);
			if (remainingCompletionCounter <= 0)
			{
				remainingCompletionCounter = 1;
			}
			pendingCompletion.Value = delegate(Exception? ex)
			{
				if (Interlocked.Decrement(ref remainingCompletionCounter) == 0)
				{
					lock (_pendingCompletionList)
					{
						_pendingCompletionList.Remove(pendingCompletion);
						NotifyCompletion(ex);
					}
					asyncContinuation(ex);
				}
			};
			return pendingCompletion.Value;
		}
	}

	public void Clear()
	{
		_pendingCompletionList.Clear();
		Interlocked.Exchange(ref _pendingOperationCounter, 0);
	}
}
