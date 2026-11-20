using System.Reactive.Concurrency;

namespace System.Reactive.Linq.ObservableImpl;

internal sealed class FromEventPattern
{
	public sealed class Impl<TDelegate, TEventArgs> : ClassicEventProducer<TDelegate, EventPattern<TEventArgs>>
	{
		private readonly Func<EventHandler<TEventArgs>, TDelegate>? _conversion;

		public Impl(Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler)
			: base(addHandler, removeHandler, scheduler)
		{
		}

		public Impl(Func<EventHandler<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, IScheduler scheduler)
			: base(addHandler, removeHandler, scheduler)
		{
			_conversion = conversion;
		}

		protected override TDelegate GetHandler(Action<EventPattern<TEventArgs>> onNext)
		{
			if (_conversion == null)
			{
				return ReflectionUtils.CreateDelegate<TDelegate>((Action<object, TEventArgs>)delegate(object sender, TEventArgs eventArgs)
				{
					onNext(new EventPattern<TEventArgs>(sender, eventArgs));
				}, typeof(Action<object, TEventArgs>).GetMethod("Invoke"));
			}
			return _conversion(delegate(object? sender, TEventArgs eventArgs)
			{
				onNext(new EventPattern<TEventArgs>(sender, eventArgs));
			});
		}
	}
}
