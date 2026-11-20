using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading;

namespace System.Reactive.Subjects;

public sealed class ReplaySubject<T> : SubjectBase<T>
{
	private abstract class ReplayBase : SubjectBase<T>
	{
		private sealed class Subscription : IDisposable
		{
			private ReplayBase _subject;

			private IScheduledObserver<T>? _observer;

			public Subscription(ReplayBase subject, IScheduledObserver<T> observer)
			{
				_subject = subject;
				_observer = observer;
			}

			public void Dispose()
			{
				IScheduledObserver<T> scheduledObserver = Interlocked.Exchange(ref _observer, null);
				if (scheduledObserver != null)
				{
					scheduledObserver.Dispose();
					_subject.Unsubscribe(scheduledObserver);
					_subject = null;
				}
			}
		}

		private readonly object _gate = new object();

		private ImmutableList<IScheduledObserver<T>> _observers;

		private bool _isStopped;

		private Exception? _error;

		private bool _isDisposed;

		protected ReplayBase()
		{
			_observers = ImmutableList<IScheduledObserver<T>>.Empty;
			_isStopped = false;
			_error = null;
		}

		public override void OnNext(T value)
		{
			IScheduledObserver<T>[] array = null;
			lock (_gate)
			{
				CheckDisposed();
				if (!_isStopped)
				{
					Next(value);
					Trim();
					array = _observers.Data;
					IScheduledObserver<T>[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].OnNext(value);
					}
				}
			}
			if (array != null)
			{
				IScheduledObserver<T>[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].EnsureActive();
				}
			}
		}

		public override void OnError(Exception error)
		{
			IScheduledObserver<T>[] array = null;
			lock (_gate)
			{
				CheckDisposed();
				if (!_isStopped)
				{
					_isStopped = true;
					_error = error;
					Trim();
					array = _observers.Data;
					IScheduledObserver<T>[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].OnError(error);
					}
					_observers = ImmutableList<IScheduledObserver<T>>.Empty;
				}
			}
			if (array != null)
			{
				IScheduledObserver<T>[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].EnsureActive();
				}
			}
		}

		public override void OnCompleted()
		{
			IScheduledObserver<T>[] array = null;
			lock (_gate)
			{
				CheckDisposed();
				if (!_isStopped)
				{
					_isStopped = true;
					Trim();
					array = _observers.Data;
					IScheduledObserver<T>[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].OnCompleted();
					}
					_observers = ImmutableList<IScheduledObserver<T>>.Empty;
				}
			}
			if (array != null)
			{
				IScheduledObserver<T>[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].EnsureActive();
				}
			}
		}

		public override IDisposable Subscribe(IObserver<T> observer)
		{
			IScheduledObserver<T> scheduledObserver = CreateScheduledObserver(observer);
			int num = 0;
			IDisposable result = Disposable.Empty;
			lock (_gate)
			{
				CheckDisposed();
				Trim();
				num = Replay(scheduledObserver);
				if (_error != null)
				{
					num++;
					scheduledObserver.OnError(_error);
				}
				else if (_isStopped)
				{
					num++;
					scheduledObserver.OnCompleted();
				}
				if (!_isStopped)
				{
					result = new Subscription(this, scheduledObserver);
					_observers = _observers.Add(scheduledObserver);
				}
			}
			scheduledObserver.EnsureActive(num);
			return result;
		}

		public override void Dispose()
		{
			lock (_gate)
			{
				_isDisposed = true;
				_observers = null;
				DisposeCore();
			}
		}

		protected abstract void DisposeCore();

		protected abstract void Next(T value);

		protected abstract int Replay(IObserver<T> observer);

		protected abstract void Trim();

		protected abstract IScheduledObserver<T> CreateScheduledObserver(IObserver<T> observer);

		private void CheckDisposed()
		{
			if (_isDisposed)
			{
				throw new ObjectDisposedException(string.Empty);
			}
		}

		private void Unsubscribe(IScheduledObserver<T> observer)
		{
			lock (_gate)
			{
				if (!_isDisposed)
				{
					_observers = _observers.Remove(observer);
				}
			}
		}
	}

	private sealed class ReplayOne : ReplayBufferBase
	{
		private bool _hasValue;

		private T? _value;

		protected override void Trim()
		{
		}

		protected override void Next(T value)
		{
			_hasValue = true;
			_value = value;
		}

		protected override int Replay(IObserver<T> observer)
		{
			int result = 0;
			if (_hasValue)
			{
				result = 1;
				observer.OnNext(_value);
			}
			return result;
		}

		protected override void DisposeCore()
		{
			_value = default(T);
		}
	}

	private sealed class ReplayMany : ReplayManyBase
	{
		private readonly int _bufferSize;

		public ReplayMany(int bufferSize)
			: base(bufferSize)
		{
			_bufferSize = bufferSize;
		}

		protected override void Trim()
		{
			while (_queue.Count > _bufferSize)
			{
				_queue.Dequeue();
			}
		}
	}

	private sealed class ReplayAll : ReplayManyBase
	{
		public ReplayAll()
			: base(0)
		{
		}

		protected override void Trim()
		{
		}
	}

	private abstract class ReplayBufferBase : ReplayBase
	{
		protected override IScheduledObserver<T> CreateScheduledObserver(IObserver<T> observer)
		{
			return new FastImmediateObserver<T>(observer);
		}

		protected override void DisposeCore()
		{
		}
	}

	private abstract class ReplayManyBase : ReplayBufferBase
	{
		protected readonly Queue<T> _queue;

		protected ReplayManyBase(int queueSize)
		{
			_queue = new Queue<T>(Math.Min(queueSize, 64));
		}

		protected override void Next(T value)
		{
			_queue.Enqueue(value);
		}

		protected override int Replay(IObserver<T> observer)
		{
			int count = _queue.Count;
			foreach (T item in _queue)
			{
				observer.OnNext(item);
			}
			return count;
		}

		protected override void DisposeCore()
		{
			_queue.Clear();
		}
	}

	private readonly SubjectBase<T> _implementation;

	public ReplaySubject()
		: this(int.MaxValue)
	{
	}

	public ReplaySubject(int bufferSize)
	{
		_implementation = bufferSize switch
		{
			1 => new ReplayOne(), 
			int.MaxValue => new ReplayAll(), 
			_ => new ReplayMany(bufferSize), 
		};
	}

	public override void OnNext(T value)
	{
		_implementation.OnNext(value);
	}

	public override void OnError(Exception error)
	{
		if (error == null)
		{
			throw new ArgumentNullException("error");
		}
		_implementation.OnError(error);
	}

	public override void OnCompleted()
	{
		_implementation.OnCompleted();
	}

	public override IDisposable Subscribe(IObserver<T> observer)
	{
		if (observer == null)
		{
			throw new ArgumentNullException("observer");
		}
		return _implementation.Subscribe(observer);
	}

	public override void Dispose()
	{
		_implementation.Dispose();
	}
}
