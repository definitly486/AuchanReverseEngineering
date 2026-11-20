using System.Collections;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Subjects;

namespace Akavache.Sqlite3;

internal class OperationQueueItem
{
	public OperationType OperationType { get; set; }

	public IEnumerable? Parameters { get; set; }

	public object Completion { get; set; }

	public IEnumerable<CacheElement>? ParametersAsElements => (IEnumerable<CacheElement>)Parameters;

	public IEnumerable<string>? ParametersAsKeys => (IEnumerable<string>)Parameters;

	public AsyncSubject<Unit> CompletionAsUnit => (AsyncSubject<Unit>)Completion;

	public AsyncSubject<IEnumerable<CacheElement>> CompletionAsElements => (AsyncSubject<IEnumerable<CacheElement>>)Completion;

	public AsyncSubject<IEnumerable<string>> CompletionAsKeys => (AsyncSubject<IEnumerable<string>>)Completion;

	public OperationQueueItem(object completion, IEnumerable? parameters)
	{
		Parameters = parameters;
		Completion = completion;
		base._002Ector();
	}

	public static OperationQueueItem CreateInsert(OperationType opType, IEnumerable<CacheElement> toInsert, AsyncSubject<Unit>? completion = null)
	{
		return new OperationQueueItem(completion ?? new AsyncSubject<Unit>(), toInsert)
		{
			OperationType = opType
		};
	}

	public static OperationQueueItem CreateInvalidate(OperationType opType, IEnumerable<string> toInvalidate, AsyncSubject<Unit>? completion = null)
	{
		return new OperationQueueItem(completion ?? new AsyncSubject<Unit>(), toInvalidate)
		{
			OperationType = opType
		};
	}

	public static OperationQueueItem CreateSelect(OperationType opType, IEnumerable<string> toSelect, AsyncSubject<IEnumerable<CacheElement>>? completion = null)
	{
		return new OperationQueueItem(completion ?? new AsyncSubject<IEnumerable<CacheElement>>(), toSelect)
		{
			OperationType = opType
		};
	}

	public static OperationQueueItem CreateUnit(OperationType opType, AsyncSubject<Unit>? completion = null)
	{
		return new OperationQueueItem(completion ?? new AsyncSubject<Unit>(), null)
		{
			OperationType = opType
		};
	}

	public static OperationQueueItem CreateGetAllKeys()
	{
		return new OperationQueueItem(new AsyncSubject<IEnumerable<string>>(), null)
		{
			OperationType = OperationType.GetKeysSqliteOperation
		};
	}
}
