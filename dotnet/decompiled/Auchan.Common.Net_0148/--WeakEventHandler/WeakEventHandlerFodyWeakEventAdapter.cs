using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace _003C_003EWeakEventHandler;

[GeneratedCode("WeakEventHandler.Fody", "1.0")]
internal class WeakEventHandlerFodyWeakEventAdapter<TSource, TTarget, TEventArgs, TEventHandler> where TSource : class where TTarget : class where TEventArgs : EventArgs where TEventHandler : Delegate
{
	private readonly WeakReference<TTarget> _weakTarget;

	private readonly Action<TTarget, object, TEventArgs> _targetDelegate;

	private readonly Action<TSource, TEventHandler> _addDelegate;

	private readonly Action<TSource, TEventHandler> _removeDelegate;

	private List<TSource> _subscriptions = new List<TSource>();

	private readonly TEventHandler _eventDelegate;

	public WeakEventHandlerFodyWeakEventAdapter(TTarget targetObject, Action<TTarget, object, TEventArgs> targetDelegate, Action<TSource, TEventHandler> addDelegate, Action<TSource, TEventHandler> removeDelegate)
	{
		_weakTarget = new WeakReference<TTarget>(targetObject);
		_targetDelegate = targetDelegate;
		_addDelegate = addDelegate;
		_removeDelegate = removeDelegate;
		MethodInfo method = new Action<object, TEventArgs>(OnEvent).Method;
		_eventDelegate = (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, method);
	}

	private void OnEvent(object sender, TEventArgs e)
	{
		if (!_weakTarget.TryGetTarget(out var target))
		{
			Release();
		}
		else
		{
			_targetDelegate(target, sender, e);
		}
	}

	public void Subscribe(TSource source)
	{
		List<TSource> list = Volatile.Read(in _subscriptions);
		while (true)
		{
			List<TSource> value = new List<TSource>(list) { source };
			if (Interlocked.CompareExchange(ref _subscriptions, value, list) == list)
			{
				break;
			}
			list = Volatile.Read(in _subscriptions);
		}
		_addDelegate(source, _eventDelegate);
	}

	public void Unsubscribe(TSource source)
	{
		List<TSource> list = Volatile.Read(in _subscriptions);
		while (true)
		{
			List<TSource> list2 = new List<TSource>(list);
			list2.Remove(source);
			if (Interlocked.CompareExchange(ref _subscriptions, list2, list) == list)
			{
				break;
			}
			list = Volatile.Read(in _subscriptions);
		}
		_removeDelegate(source, _eventDelegate);
	}

	public void Release()
	{
		foreach (TSource subscription in _subscriptions)
		{
			_removeDelegate(subscription, _eventDelegate);
		}
	}
}
