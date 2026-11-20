using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Versioning;
using System.Threading;

namespace System.Collections.Concurrent;

[UnsupportedOSPlatform("browser")]
[DebuggerTypeProxy(typeof(BlockingCollectionDebugView<>))]
[DebuggerDisplay("Count = {Count}, Type = {_collection}")]
public class BlockingCollection<T> : IEnumerable<T>, IEnumerable, ICollection, IDisposable, IReadOnlyCollection<T>
{
	private IProducerConsumerCollection<T> _collection;

	private int _boundedCapacity;

	private SemaphoreSlim _freeNodes;

	private SemaphoreSlim _occupiedNodes;

	private bool _isDisposed;

	private CancellationTokenSource _consumersCancellationTokenSource;

	private CancellationTokenSource _producersCancellationTokenSource;

	private volatile int _currentAdders;

	public bool IsAddingCompleted
	{
		get
		{
			CheckDisposed();
			return _currentAdders == int.MinValue;
		}
	}

	public bool IsCompleted
	{
		get
		{
			CheckDisposed();
			if (IsAddingCompleted)
			{
				return _occupiedNodes.CurrentCount == 0;
			}
			return false;
		}
	}

	public int Count
	{
		get
		{
			CheckDisposed();
			return _occupiedNodes.CurrentCount;
		}
	}

	bool ICollection.IsSynchronized
	{
		get
		{
			CheckDisposed();
			return false;
		}
	}

	object ICollection.SyncRoot
	{
		get
		{
			throw new NotSupportedException("ConcurrentCollection_SyncRoot_NotSupported");
		}
	}

	public BlockingCollection()
		: this((IProducerConsumerCollection<T>)new ConcurrentQueue<T>())
	{
	}

	public BlockingCollection(IProducerConsumerCollection<T> collection)
	{
		ArgumentNullException.ThrowIfNull(collection, "collection");
		Initialize(collection, -1, collection.Count);
	}

	[MemberNotNull("_collection")]
	[MemberNotNull("_consumersCancellationTokenSource")]
	[MemberNotNull("_producersCancellationTokenSource")]
	[MemberNotNull("_occupiedNodes")]
	private void Initialize(IProducerConsumerCollection<T> collection, int boundedCapacity, int collectionCount)
	{
		_collection = collection;
		_boundedCapacity = boundedCapacity;
		_isDisposed = false;
		_consumersCancellationTokenSource = new CancellationTokenSource();
		_producersCancellationTokenSource = new CancellationTokenSource();
		if (boundedCapacity == -1)
		{
			_freeNodes = null;
		}
		else
		{
			_freeNodes = new SemaphoreSlim(boundedCapacity - collectionCount);
		}
		_occupiedNodes = new SemaphoreSlim(collectionCount);
	}

	public void Add(T item)
	{
		TryAddWithNoTimeValidation(item, -1, CancellationToken.None);
	}

	private bool TryAddWithNoTimeValidation(T item, int millisecondsTimeout, CancellationToken cancellationToken)
	{
		CheckDisposed();
		cancellationToken.ThrowIfCancellationRequested();
		if (IsAddingCompleted)
		{
			throw new InvalidOperationException("BlockingCollection_Completed");
		}
		bool flag = true;
		if (_freeNodes != null)
		{
			CancellationTokenSource cancellationTokenSource = null;
			try
			{
				flag = _freeNodes.Wait(0, default(CancellationToken));
				if (!flag && millisecondsTimeout != 0)
				{
					cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _producersCancellationTokenSource.Token);
					flag = _freeNodes.Wait(millisecondsTimeout, cancellationTokenSource.Token);
				}
			}
			catch (OperationCanceledException)
			{
				cancellationToken.ThrowIfCancellationRequested();
				throw new InvalidOperationException("BlockingCollection_Add_ConcurrentCompleteAdd");
			}
			finally
			{
				cancellationTokenSource?.Dispose();
			}
		}
		if (flag)
		{
			SpinWait spinWait = default(SpinWait);
			while (true)
			{
				int currentAdders = _currentAdders;
				if ((currentAdders & int.MinValue) != 0)
				{
					spinWait.Reset();
					while (_currentAdders != int.MinValue)
					{
						spinWait.SpinOnce();
					}
					throw new InvalidOperationException("BlockingCollection_Completed");
				}
				if (Interlocked.CompareExchange(ref _currentAdders, currentAdders + 1, currentAdders) == currentAdders)
				{
					break;
				}
				spinWait.SpinOnce(-1);
			}
			bool flag2 = false;
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				flag2 = _collection.TryAdd(item);
				if (!flag2)
				{
					throw new InvalidOperationException("BlockingCollection_Add_Failed");
				}
			}
			finally
			{
				if (flag2)
				{
					_occupiedNodes.Release();
				}
				else
				{
					_freeNodes?.Release();
				}
				Interlocked.Decrement(ref _currentAdders);
			}
		}
		return flag;
	}

	public T Take(CancellationToken cancellationToken)
	{
		if (!TryTake(out var item, -1, cancellationToken))
		{
			throw new InvalidOperationException("BlockingCollection_CantTakeWhenDone");
		}
		return item;
	}

	public bool TryTake([MaybeNullWhen(false)] out T item)
	{
		return TryTake(out item, 0, CancellationToken.None);
	}

	public bool TryTake([MaybeNullWhen(false)] out T item, int millisecondsTimeout, CancellationToken cancellationToken)
	{
		ValidateMillisecondsTimeout(millisecondsTimeout);
		return TryTakeWithNoTimeValidation(out item, millisecondsTimeout, cancellationToken, null);
	}

	private bool TryTakeWithNoTimeValidation([MaybeNullWhen(false)] out T item, int millisecondsTimeout, CancellationToken cancellationToken, CancellationTokenSource combinedTokenSource)
	{
		CheckDisposed();
		item = default(T);
		cancellationToken.ThrowIfCancellationRequested();
		if (IsCompleted)
		{
			return false;
		}
		bool flag = false;
		CancellationTokenSource cancellationTokenSource = combinedTokenSource;
		try
		{
			flag = _occupiedNodes.Wait(0);
			if (!flag && millisecondsTimeout != 0)
			{
				if (cancellationTokenSource == null)
				{
					cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _consumersCancellationTokenSource.Token);
				}
				flag = _occupiedNodes.Wait(millisecondsTimeout, cancellationTokenSource.Token);
			}
		}
		catch (OperationCanceledException)
		{
			cancellationToken.ThrowIfCancellationRequested();
			return false;
		}
		finally
		{
			if (cancellationTokenSource != null && combinedTokenSource == null)
			{
				cancellationTokenSource.Dispose();
			}
		}
		if (flag)
		{
			bool flag2 = false;
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				flag2 = _collection.TryTake(out item);
				if (!flag2)
				{
					throw new InvalidOperationException("BlockingCollection_Take_CollectionModified");
				}
			}
			finally
			{
				if (flag2)
				{
					if (_freeNodes != null)
					{
						_freeNodes.Release();
					}
				}
				else
				{
					_occupiedNodes.Release();
				}
				if (IsCompleted)
				{
					CancelWaitingConsumers();
				}
			}
		}
		return flag;
	}

	private void CancelWaitingConsumers()
	{
		_consumersCancellationTokenSource.Cancel();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			_freeNodes?.Dispose();
			_occupiedNodes.Dispose();
			_isDisposed = true;
		}
	}

	public T[] ToArray()
	{
		CheckDisposed();
		return _collection.ToArray();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		CheckDisposed();
		T[] array2 = _collection.ToArray();
		try
		{
			Array.Copy(array2, 0, array, index, array2.Length);
		}
		catch (ArgumentNullException)
		{
			throw new ArgumentNullException("array");
		}
		catch (ArgumentOutOfRangeException)
		{
			throw new ArgumentOutOfRangeException("index", index, "BlockingCollection_CopyTo_NonNegative");
		}
		catch (ArgumentException)
		{
			throw new ArgumentException("Collection_CopyTo_TooManyElems", "index");
		}
		catch (RankException)
		{
			throw new ArgumentException("BlockingCollection_CopyTo_MultiDim", "array");
		}
		catch (InvalidCastException)
		{
			throw new ArgumentException("BlockingCollection_CopyTo_IncorrectType", "array");
		}
		catch (ArrayTypeMismatchException)
		{
			throw new ArgumentException("BlockingCollection_CopyTo_IncorrectType", "array");
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		CheckDisposed();
		return _collection.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<T>)this).GetEnumerator();
	}

	private static void ValidateMillisecondsTimeout(int millisecondsTimeout)
	{
		if (millisecondsTimeout < 0 && millisecondsTimeout != -1)
		{
			throw new ArgumentOutOfRangeException("millisecondsTimeout", millisecondsTimeout, System.SR.Format(CultureInfo.InvariantCulture, "BlockingCollection_TimeoutInvalid", int.MaxValue));
		}
	}

	private void CheckDisposed()
	{
		ObjectDisposedException.ThrowIf(_isDisposed, this);
	}
}
