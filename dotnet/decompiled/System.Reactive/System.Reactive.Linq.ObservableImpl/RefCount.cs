using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace System.Reactive.Linq.ObservableImpl;

internal static class RefCount<TSource>
{
	internal sealed class Eager : Producer<TSource, Eager._>
	{
		internal sealed class @_ : IdentitySink<TSource>
		{
			private readonly Eager _parent;

			private RefConnection? _targetConnection;

			public _(IObserver<TSource> observer, Eager parent)
				: base(observer)
			{
				_parent = parent;
			}

			public void Run()
			{
				RefConnection refConnection;
				bool flag;
				lock (_parent._gate)
				{
					refConnection = _parent._connection;
					if (refConnection == null)
					{
						refConnection = new RefConnection();
						_parent._connection = refConnection;
					}
					flag = ++refConnection._count == _parent._minObservers;
					_targetConnection = refConnection;
				}
				Run(_parent._source);
				if (flag && !refConnection._disposable.IsDisposed)
				{
					refConnection._disposable.Disposable = _parent._source.Connect();
				}
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (!disposing)
				{
					return;
				}
				RefConnection targetConnection = _targetConnection;
				_targetConnection = null;
				lock (_parent._gate)
				{
					if (targetConnection != _parent._connection || --targetConnection._count != 0)
					{
						return;
					}
					_parent._connection = null;
				}
				targetConnection._disposable.Dispose();
			}
		}

		private sealed class RefConnection
		{
			internal int _count;

			internal SingleAssignmentDisposableValue _disposable;
		}

		private readonly IConnectableObservable<TSource> _source;

		private readonly object _gate = new object();

		private RefConnection? _connection;

		private readonly int _minObservers;

		public Eager(IConnectableObservable<TSource> source, int minObservers)
		{
			_source = source;
			_minObservers = minObservers;
		}

		protected override @_ CreateSink(IObserver<TSource> observer)
		{
			return new @_(observer, this);
		}

		protected override void Run(@_ sink)
		{
			sink.Run();
		}
	}
}
