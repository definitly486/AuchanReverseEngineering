using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AsyncAwaitBestPractices;

public class WeakEventManager<TEventArgs>
{
	private readonly Dictionary<string, List<Subscription>> _eventHandlers = new Dictionary<string, List<Subscription>>();

	public void AddEventHandler([NotNull] EventHandler<TEventArgs>? handler, [CallerMemberName][NotNull] string eventName = "")
	{
		AddEventHandler(in handler, in eventName);
	}

	public void AddEventHandler([NotNull] Action<TEventArgs>? action, [CallerMemberName][NotNull] string eventName = "")
	{
		AddEventHandler(in action, in eventName);
	}

	public void RemoveEventHandler([NotNull] EventHandler<TEventArgs>? handler, [CallerMemberName][NotNull] string eventName = "")
	{
		RemoveEventHandler(in handler, in eventName);
	}

	public void RemoveEventHandler([NotNull] Action<TEventArgs>? action, [CallerMemberName][NotNull] string eventName = "")
	{
		RemoveEventHandler(in action, in eventName);
	}

	public void RaiseEvent(object? sender, TEventArgs eventArgs, string eventName)
	{
		RaiseEvent(in sender, in eventArgs, in eventName);
	}

	public void RaiseEvent(TEventArgs eventArgs, string eventName)
	{
		RaiseEvent(in eventArgs, in eventName);
	}

	public void AddEventHandler([NotNull] in EventHandler<TEventArgs>? handler, [CallerMemberName][NotNull] in string eventName = "")
	{
		if (string.IsNullOrWhiteSpace(eventName))
		{
			throw new ArgumentNullException("eventName");
		}
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		EventManagerService.AddEventHandler(in eventName, handler.Target, handler.GetMethodInfo(), in _eventHandlers);
	}

	public void AddEventHandler([NotNull] in Action<TEventArgs>? action, [CallerMemberName][NotNull] in string eventName = "")
	{
		if (string.IsNullOrWhiteSpace(eventName))
		{
			throw new ArgumentNullException("eventName");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		EventManagerService.AddEventHandler(in eventName, action.Target, action.GetMethodInfo(), in _eventHandlers);
	}

	public void RemoveEventHandler([NotNull] in EventHandler<TEventArgs>? handler, [CallerMemberName][NotNull] in string eventName = "")
	{
		if (string.IsNullOrWhiteSpace(eventName))
		{
			throw new ArgumentNullException("eventName");
		}
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		EventManagerService.RemoveEventHandler(in eventName, handler.Target, (MemberInfo)handler.GetMethodInfo(), in _eventHandlers);
	}

	public void RemoveEventHandler([NotNull] in Action<TEventArgs>? action, [CallerMemberName][NotNull] in string eventName = "")
	{
		if (string.IsNullOrWhiteSpace(eventName))
		{
			throw new ArgumentNullException("eventName");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		EventManagerService.RemoveEventHandler(in eventName, action.Target, (MemberInfo)action.GetMethodInfo(), in _eventHandlers);
	}

	public void RaiseEvent(in object? sender, in TEventArgs eventArgs, in string eventName)
	{
		EventManagerService.HandleEvent(in eventName, in sender, (object)eventArgs, in _eventHandlers);
	}

	public void RaiseEvent(in TEventArgs eventArgs, in string eventName)
	{
		EventManagerService.HandleEvent(in eventName, (object)eventArgs, in _eventHandlers);
	}
}
