using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace System.Reactive.Linq;

internal sealed class GroupedObservable<TKey, TElement> : ObservableBase<TElement>, IGroupedObservable<TKey, TElement>, IObservable<TElement>
{
	private readonly IObservable<TElement> _subject;

	private readonly RefCountDisposable? _refCount;

	public GroupedObservable(TKey key, ISubject<TElement> subject, RefCountDisposable refCount)
	{
		_003CKey_003Ek__BackingField = key;
		_subject = subject;
		_refCount = refCount;
	}

	protected override IDisposable SubscribeCore(IObserver<TElement> observer)
	{
		if (_refCount != null)
		{
			IDisposable disposable = _refCount.GetDisposable();
			IDisposable disposable2 = _subject.Subscribe(observer);
			return StableCompositeDisposable.Create(disposable, disposable2);
		}
		return _subject.Subscribe(observer);
	}
}
