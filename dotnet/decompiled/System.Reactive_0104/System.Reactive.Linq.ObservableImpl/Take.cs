namespace System.Reactive.Linq.ObservableImpl;

internal static class Take<TSource>
{
	internal sealed class Count : Producer<TSource, Count._>
	{
		internal sealed class @_ : IdentitySink<TSource>
		{
			private int _remaining;

			public _(int count, IObserver<TSource> observer)
				: base(observer)
			{
				_remaining = count;
			}

			public override void OnNext(TSource value)
			{
				if (_remaining > 0)
				{
					_remaining--;
					ForwardOnNext(value);
					if (_remaining == 0)
					{
						ForwardOnCompleted();
					}
				}
			}
		}

		private readonly IObservable<TSource> _source;

		private readonly int _count;

		public Count(IObservable<TSource> source, int count)
		{
			_source = source;
			_count = count;
		}

		public IObservable<TSource> Combine(int count)
		{
			if (_count <= count)
			{
				return this;
			}
			return new Count(_source, count);
		}

		protected override @_ CreateSink(IObserver<TSource> observer)
		{
			return new @_(_count, observer);
		}

		protected override void Run(@_ sink)
		{
			sink.Run(_source);
		}
	}
}
