using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace AsyncAwaitBestPractices;

internal static class EventManagerService
{
	private static readonly Lock _lock = new Lock();

	internal static void AddEventHandler(in string eventName, in object? handlerTarget, in MethodInfo methodInfo, in Dictionary<string, List<Subscription>> eventHandlers)
	{
		using (_lock.EnterScope())
		{
			if (!eventHandlers.TryGetValue(eventName, out List<Subscription> value) || value == null)
			{
				value = new List<Subscription>();
				eventHandlers.Add(eventName, value);
			}
			if (handlerTarget == null)
			{
				value.Add(new Subscription((WeakReference)null, in methodInfo));
			}
			else
			{
				value.Add(new Subscription(new WeakReference(handlerTarget), in methodInfo));
			}
		}
	}

	internal static void RemoveEventHandler(in string eventName, in object? handlerTarget, in MemberInfo methodInfo, in Dictionary<string, List<Subscription>> eventHandlers)
	{
		using (_lock.EnterScope())
		{
			if (!eventHandlers.TryGetValue(eventName, out List<Subscription> value) || value == null)
			{
				return;
			}
			for (int num = value.Count - 1; num >= 0; num--)
			{
				Subscription subscription = value[num];
				if (subscription.Subscriber?.Target == handlerTarget && !(subscription.Handler.Name != methodInfo?.Name))
				{
					value.RemoveAt(num);
					break;
				}
			}
		}
	}

	internal static void HandleEvent(in string eventName, in object? sender, in object? eventArgs, in Dictionary<string, List<Subscription>> eventHandlers)
	{
		AddRemoveEvents(in eventName, in eventHandlers, out List<(object, MethodInfo)> toRaise);
		for (int i = 0; i < toRaise.Count; i++)
		{
			try
			{
				var (obj, methodInfo) = toRaise[i];
				if (methodInfo is DynamicMethod dynamicMethod)
				{
					dynamicMethod.Invoke(obj, new object[2] { sender, eventArgs });
				}
				else
				{
					methodInfo.Invoke(obj, new object[2] { sender, eventArgs });
				}
			}
			catch (TargetParameterCountException targetParameterCountException)
			{
				throw new InvalidHandleEventException("Parameter count mismatch. If invoking an `event Action` use `HandleEvent(string eventName)` or if invoking an `event Action<T>` use `HandleEvent(object eventArgs, string eventName)`instead.", targetParameterCountException);
			}
		}
	}

	internal static void HandleEvent(in string eventName, in object? actionEventArgs, in Dictionary<string, List<Subscription>> eventHandlers)
	{
		AddRemoveEvents(in eventName, in eventHandlers, out List<(object, MethodInfo)> toRaise);
		for (int i = 0; i < toRaise.Count; i++)
		{
			try
			{
				var (obj, methodInfo) = toRaise[i];
				if (methodInfo is DynamicMethod dynamicMethod)
				{
					dynamicMethod.Invoke(obj, new object[1] { actionEventArgs });
				}
				else
				{
					methodInfo.Invoke(obj, new object[1] { actionEventArgs });
				}
			}
			catch (TargetParameterCountException targetParameterCountException)
			{
				throw new InvalidHandleEventException("Parameter count mismatch. If invoking an `event EventHandler` use `HandleEvent(object sender, TEventArgs eventArgs, string eventName)` or if invoking an `event Action` use `HandleEvent(string eventName)`instead.", targetParameterCountException);
			}
		}
	}

	private static void AddRemoveEvents(in string eventName, in Dictionary<string, List<Subscription>> eventHandlers, out List<(object? Instance, MethodInfo EventHandler)> toRaise)
	{
		List<Subscription> list = new List<Subscription>();
		toRaise = new List<(object, MethodInfo)>();
		if (!eventHandlers.TryGetValue(eventName, out List<Subscription> value) || value == null)
		{
			return;
		}
		for (int i = 0; i < value.Count; i++)
		{
			Subscription item = value[i];
			if (item.Subscriber == null)
			{
				toRaise.Add((null, item.Handler));
				continue;
			}
			object obj = item.Subscriber?.Target;
			if (obj == null)
			{
				list.Add(item);
			}
			else
			{
				toRaise.Add((obj, item.Handler));
			}
		}
		foreach (Subscription item2 in list)
		{
			value.Remove(item2);
		}
	}
}
