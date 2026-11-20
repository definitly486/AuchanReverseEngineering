using System.Reactive.Disposables;

namespace System.Reactive.Linq.ObservableImpl;

internal static class Merge<TSource>
{
	internal sealed class Observables : Producer<TSource, Observables._>
	{
		internal sealed class @_ : Sink<IObservable<TSource>, TSource>
		{
			private sealed class InnerObserver : SafeObserver<TSource>
			{
				private readonly @_ _parent;

				public InnerObserver(@_ parent)
				{
					_parent = parent;
				}

				public override void OnNext(TSource value)
				{
					lock (_parent._gate)
					{
						_parent.ForwardOnNext(value);
					}
				}

				public override void OnError(Exception error)
				{
					lock (_parent._gate)
					{
						_parent.ForwardOnError(error);
					}
				}

				public override void OnCompleted()
				{
					_parent._group.Remove(this);
					if (_parent._isStopped && _parent._group.Count == 0)
					{
						lock (_parent._gate)
						{
							_parent.ForwardOnCompleted();
						}
					}
				}
			}

			private readonly object _gate = new object();

			private readonly CompositeDisposable _group = new CompositeDisposable();

			private volatile bool _isStopped;

			public _(IObserver<TSource> observer)
				: base(observer)
			{
			}

			public override void OnNext(IObservable<TSource> value)
			{
				InnerObserver innerObserver = new InnerObserver(this);
				_group.Add(innerObserver);
				innerObserver.SetResource(value.SubscribeSafe(innerObserver));
			}

			public override void OnError(Exception error)
			{
				lock (_gate)
				{
					ForwardOnError(error);
				}
			}

			public override void OnCompleted()
			{
				_isStopped = true;
				if (_group.Count == 0)
				{
					lock (_gate)
					{
						ForwardOnCompleted();
						return;
					}
				}
				DisposeUpstream();
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_group.Dispose();
				}
			}
		}

		private readonly IObservable<IObservable<TSource>> _sources;

		public Observables(IObservable<IObservable<TSource>> sources)
		{
			_sources = sources;
		}

		protected override @_ CreateSink(IObserver<TSource> observer)
		{
			return new @_(observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_sources);
		}
	}
}
