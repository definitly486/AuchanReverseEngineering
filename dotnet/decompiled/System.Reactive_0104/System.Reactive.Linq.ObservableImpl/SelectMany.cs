using System.Collections.Generic;
using System.Reactive.Disposables;

namespace System.Reactive.Linq.ObservableImpl;

internal static class SelectMany<TSource, TResult>
{
	internal class ObservableSelector : Producer<TResult, ObservableSelector._>
	{
		internal class @_ : Sink<TSource, TResult>
		{
			private sealed class InnerObserver : SafeObserver<TResult>
			{
				private readonly @_ _parent;

				public InnerObserver(@_ parent)
				{
					_parent = parent;
				}

				public override void OnNext(TResult value)
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

			protected readonly object _gate = new object();

			private readonly Func<TSource, IObservable<TResult>> _selector;

			private readonly CompositeDisposable _group = new CompositeDisposable();

			private volatile bool _isStopped;

			public _(ObservableSelector parent, IObserver<TResult> observer)
				: base(observer)
			{
				_selector = parent._selector;
			}

			public override void OnNext(TSource value)
			{
				IObservable<TResult> inner;
				try
				{
					inner = _selector(value);
				}
				catch (Exception error)
				{
					lock (_gate)
					{
						ForwardOnError(error);
						return;
					}
				}
				SubscribeInner(inner);
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
				Final();
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_group.Dispose();
				}
			}

			protected void Final()
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

			protected void SubscribeInner(IObservable<TResult> inner)
			{
				InnerObserver innerObserver = new InnerObserver(this);
				_group.Add(innerObserver);
				innerObserver.SetResource(inner.SubscribeSafe(innerObserver));
			}
		}

		protected readonly IObservable<TSource> _source;

		protected readonly Func<TSource, IObservable<TResult>> _selector;

		public ObservableSelector(IObservable<TSource> source, Func<TSource, IObservable<TResult>> selector)
		{
			_source = source;
			_selector = selector;
		}

		protected override @_ CreateSink(IObserver<TResult> observer)
		{
			return new @_(this, observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_source);
		}
	}

	internal sealed class EnumerableSelector : Producer<TResult, EnumerableSelector._>
	{
		internal sealed class @_ : Sink<TSource, TResult>
		{
			private readonly Func<TSource, IEnumerable<TResult>> _selector;

			public _(EnumerableSelector parent, IObserver<TResult> observer)
				: base(observer)
			{
				_selector = parent._selector;
			}

			public override void OnNext(TSource value)
			{
				IEnumerable<TResult> enumerable;
				try
				{
					enumerable = _selector(value);
				}
				catch (Exception error)
				{
					ForwardOnError(error);
					return;
				}
				IEnumerator<TResult> enumerator;
				try
				{
					enumerator = enumerable.GetEnumerator();
				}
				catch (Exception error2)
				{
					ForwardOnError(error2);
					return;
				}
				using (enumerator)
				{
					bool flag = true;
					while (flag)
					{
						TResult value2 = default(TResult);
						try
						{
							flag = enumerator.MoveNext();
							if (flag)
							{
								value2 = enumerator.Current;
							}
						}
						catch (Exception error3)
						{
							ForwardOnError(error3);
							break;
						}
						if (flag)
						{
							ForwardOnNext(value2);
						}
					}
				}
			}
		}

		private readonly IObservable<TSource> _source;

		private readonly Func<TSource, IEnumerable<TResult>> _selector;

		public EnumerableSelector(IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		{
			_source = source;
			_selector = selector;
		}

		protected override @_ CreateSink(IObserver<TResult> observer)
		{
			return new @_(this, observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_source);
		}
	}
}
