using System.Reactive.Disposables;

namespace System.Reactive.Linq.ObservableImpl;

internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, TResult> : Producer<TResult, CombineLatest<T1, T2, T3, T4, T5, T6, TResult>._>
{
	internal sealed class @_ : CombineLatestSink<TResult>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, TResult> _resultSelector;

		private readonly CombineLatestObserver<T1> _observer1;

		private readonly CombineLatestObserver<T2> _observer2;

		private readonly CombineLatestObserver<T3> _observer3;

		private readonly CombineLatestObserver<T4> _observer4;

		private readonly CombineLatestObserver<T5> _observer5;

		private readonly CombineLatestObserver<T6> _observer6;

		public _(Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector, IObserver<TResult> observer)
			: base(6, observer)
		{
			_resultSelector = resultSelector;
			_observer1 = new CombineLatestObserver<T1>(_gate, this, 0);
			_observer2 = new CombineLatestObserver<T2>(_gate, this, 1);
			_observer3 = new CombineLatestObserver<T3>(_gate, this, 2);
			_observer4 = new CombineLatestObserver<T4>(_gate, this, 3);
			_observer5 = new CombineLatestObserver<T5>(_gate, this, 4);
			_observer6 = new CombineLatestObserver<T6>(_gate, this, 5);
		}

		public void Run(IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6)
		{
			IDisposable[] disposables = new IDisposable[6] { _observer1, _observer2, _observer3, _observer4, _observer5, _observer6 };
			_observer1.SetResource(source1.SubscribeSafe(_observer1));
			_observer2.SetResource(source2.SubscribeSafe(_observer2));
			_observer3.SetResource(source3.SubscribeSafe(_observer3));
			_observer4.SetResource(source4.SubscribeSafe(_observer4));
			_observer5.SetResource(source5.SubscribeSafe(_observer5));
			_observer6.SetResource(source6.SubscribeSafe(_observer6));
			SetUpstream(StableCompositeDisposable.CreateTrusted(disposables));
		}

		protected override TResult GetResult()
		{
			return _resultSelector(_observer1.Value, _observer2.Value, _observer3.Value, _observer4.Value, _observer5.Value, _observer6.Value);
		}
	}

	private readonly IObservable<T1> _source1;

	private readonly IObservable<T2> _source2;

	private readonly IObservable<T3> _source3;

	private readonly IObservable<T4> _source4;

	private readonly IObservable<T5> _source5;

	private readonly IObservable<T6> _source6;

	private readonly Func<T1, T2, T3, T4, T5, T6, TResult> _resultSelector;

	public CombineLatest(IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
	{
		_source1 = source1;
		_source2 = source2;
		_source3 = source3;
		_source4 = source4;
		_source5 = source5;
		_source6 = source6;
		_resultSelector = resultSelector;
	}

	protected override @_ CreateSink(IObserver<TResult> observer)
	{
		return new @_(_resultSelector, observer);
	}

	protected override void Run(@_ sink)
	{
		sink.Run(_source1, _source2, _source3, _source4, _source5, _source6);
	}
}
