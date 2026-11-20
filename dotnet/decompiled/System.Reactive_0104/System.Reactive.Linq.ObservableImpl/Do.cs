namespace System.Reactive.Linq.ObservableImpl;

internal static class Do<TSource>
{
	internal sealed class OnNext : Producer<TSource, OnNext._>
	{
		internal sealed class @_ : IdentitySink<TSource>
		{
			private readonly Action<TSource> _onNext;

			public _(Action<TSource> onNext, IObserver<TSource> observer)
				: base(observer)
			{
				_onNext = onNext;
			}

			public override void OnNext(TSource value)
			{
				try
				{
					_onNext(value);
				}
				catch (Exception error)
				{
					ForwardOnError(error);
					return;
				}
				ForwardOnNext(value);
			}
		}

		private readonly IObservable<TSource> _source;

		private readonly Action<TSource> _onNext;

		public OnNext(IObservable<TSource> source, Action<TSource> onNext)
		{
			_source = source;
			_onNext = onNext;
		}

		protected override @_ CreateSink(IObserver<TSource> observer)
		{
			return new @_(_onNext, observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_source);
		}
	}
}
