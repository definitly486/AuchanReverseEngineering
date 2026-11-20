using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Common.Binding;

public class UICommand : IObservable<Unit>
{
	private readonly Subject<Unit> _subjectCommand = new Subject<Unit>();

	private IObservable<Unit> ObservableCommand => _subjectCommand.Debounce();

	public IDisposable Subscribe(IObserver<Unit> observer)
	{
		return ObservableCommand.Subscribe(observer);
	}

	public async Task TriggerAsync()
	{
		_subjectCommand.OnNext(Unit.Default);
		await _subjectCommand.LastOrDefaultAsync();
	}

	public void Trigger()
	{
		_subjectCommand.OnNext(Unit.Default);
	}
}
public class UICommand<TSubject> : IObservable<TSubject>
{
	private Maybe<TSubject> _subject;

	private readonly Subject<TSubject> _subjectCommand = new Subject<TSubject>();

	private IObservable<TSubject> ObservableCommand => _subjectCommand.Debounce();

	public UICommand()
	{
		_subject = Maybe<TSubject>.None;
	}

	public UICommand(TSubject subject)
	{
		_subject = subject;
	}

	public IDisposable Subscribe(IObserver<TSubject> observer)
	{
		return ObservableCommand.Subscribe(observer);
	}

	public IObservable<TSubject> TriggerAsync(TSubject subject)
	{
		_subjectCommand.OnNext(subject);
		return _subjectCommand;
	}

	public void Trigger(TSubject subject)
	{
		_subjectCommand.OnNext(subject);
	}

	public IObservable<TSubject> TriggerAsync()
	{
		TSubject valueOrThrow = _subject.GetValueOrThrow("UICommand is used w/o proper initialization (Read constructor comments)");
		_subjectCommand.OnNext(valueOrThrow);
		return _subjectCommand;
	}

	public void Trigger()
	{
		TSubject valueOrThrow = _subject.GetValueOrThrow("UICommand is used w/o proper initialization (Read constructor comments)");
		_subjectCommand.OnNext(valueOrThrow);
	}
}
public class UICommand<TSubject, P1> : IObservable<TSubject>
{
	private Func<P1, TSubject> _onTrigger;

	private readonly Subject<TSubject> _subjectCommand = new Subject<TSubject>();

	private IObservable<TSubject> ObservableCommand => _subjectCommand.Debounce();

	public UICommand(Func<P1, TSubject> onTrigger)
	{
		_onTrigger = onTrigger;
	}

	public IDisposable Subscribe(IObserver<TSubject> observer)
	{
		return ObservableCommand.Subscribe(observer);
	}

	public IObservable<TSubject> TriggerAsync(P1 parameter)
	{
		_subjectCommand.OnNext(_onTrigger(parameter));
		return _subjectCommand;
	}

	public void Trigger(P1 parameter)
	{
		_subjectCommand.OnNext(_onTrigger(parameter));
	}
}
public class UICommand<TSubject, P1, P2> : IObservable<TSubject>
{
	private Func<P1, P2, TSubject> _onTrigger;

	private readonly Subject<TSubject> _subjectCommand = new Subject<TSubject>();

	private IObservable<TSubject> ObservableCommand => _subjectCommand.Debounce();

	public UICommand(Func<P1, P2, TSubject> onTrigger)
	{
		_onTrigger = onTrigger;
	}

	public IDisposable Subscribe(IObserver<TSubject> observer)
	{
		return ObservableCommand.Subscribe(observer);
	}

	public IObservable<TSubject> TriggerAsync(P1 p1, P2 p2)
	{
		_subjectCommand.OnNext(_onTrigger(p1, p2));
		return _subjectCommand;
	}

	public void Trigger(P1 p1, P2 p2)
	{
		_subjectCommand.OnNext(_onTrigger(p1, p2));
	}
}
public class UICommand<TSubject, P1, P2, P3> : IObservable<TSubject>
{
	private Func<P1, P2, P3, TSubject> _onTrigger;

	private readonly Subject<TSubject> _subjectCommand = new Subject<TSubject>();

	private IObservable<TSubject> ObservableCommand => _subjectCommand.Debounce();

	public UICommand(Func<P1, P2, P3, TSubject> onTrigger)
	{
		_onTrigger = onTrigger;
	}

	public IDisposable Subscribe(IObserver<TSubject> observer)
	{
		return ObservableCommand.Subscribe(observer);
	}

	public IObservable<TSubject> TriggerAsync(P1 p1, P2 p2, P3 p3)
	{
		_subjectCommand.OnNext(_onTrigger(p1, p2, p3));
		return _subjectCommand;
	}

	public void Trigger(P1 p1, P2 p2, P3 p3)
	{
		_subjectCommand.OnNext(_onTrigger(p1, p2, p3));
	}
}
public class UICommand<TSubject, P1, P2, P3, P4> : IObservable<TSubject>
{
	private Func<P1, P2, P3, P4, TSubject> _onTrigger;

	private readonly Subject<TSubject> _subjectCommand = new Subject<TSubject>();

	private IObservable<TSubject> ObservableCommand => _subjectCommand.Debounce();

	public UICommand(Func<P1, P2, P3, P4, TSubject> onTrigger)
	{
		_onTrigger = onTrigger;
	}

	public IDisposable Subscribe(IObserver<TSubject> observer)
	{
		return ObservableCommand.Subscribe(observer);
	}

	public IObservable<TSubject> TriggerAsync(P1 p1, P2 p2, P3 p3, P4 p4)
	{
		_subjectCommand.OnNext(_onTrigger(p1, p2, p3, p4));
		return _subjectCommand;
	}

	public void Trigger(P1 p1, P2 p2, P3 p3, P4 p4)
	{
		_subjectCommand.OnNext(_onTrigger(p1, p2, p3, p4));
	}
}
