namespace System.Reactive.Linq.ObservableImpl;

internal static class LastOrDefaultAsync<TSource>
{
	internal sealed class Sequence : Producer<TSource?, Sequence._>
	{
		internal sealed class @_ : Sink<TSource, TSource?>
		{
			private TSource? _value;

			public _(IObserver<TSource?> observer)
				: base(observer)
			{
			}

			public override void OnNext(TSource value)
			{
				_value = value;
			}

			public override void OnError(Exception error)
			{
				_value = default(TSource);
				ForwardOnError(error);
			}

			public override void OnCompleted()
			{
				TSource value = _value;
				_value = default(TSource);
				ForwardOnNext(value);
				ForwardOnCompleted();
			}
		}

		private readonly IObservable<TSource> _source;

		public Sequence(IObservable<TSource> source)
		{
			_source = source;
		}

		protected override @_ CreateSink(IObserver<TSource?> observer)
		{
			return new @_(observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_source);
		}
	}
}
