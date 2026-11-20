using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Akavache;

internal abstract class KeyedOperation
{
	public string Key { get; set; }

	public int Id { get; set; }

	protected KeyedOperation(string key, int id)
	{
		Key = key;
		Id = id;
	}

	public abstract IObservable<Unit> EvaluateFunc();
}
internal class KeyedOperation<T> : KeyedOperation
{
	public Func<IObservable<T>> Func { get; }

	public ReplaySubject<T> Result { get; }

	public KeyedOperation(Func<IObservable<T>> func, string key, int id)
	{
		Func = func;
		Result = new ReplaySubject<T>();
		base._002Ector(key, id);
	}

	public override IObservable<Unit> EvaluateFunc()
	{
		IConnectableObservable<T> connectableObservable = Func().Multicast(Result);
		connectableObservable.Connect();
		return connectableObservable.Select((T _) => Unit.Default);
	}
}
