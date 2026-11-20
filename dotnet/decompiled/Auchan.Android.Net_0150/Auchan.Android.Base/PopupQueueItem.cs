using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auchan.Android.Base;

public class PopupQueueItem
{
	public Type ScreenType { get; }

	public object? Parameter { get; }

	public Func<Task>? Action { get; }

	public Func<bool>? CanShow { get; }

	public PopupQueueItem(Type type, object? parameter, Func<bool>? canShow = null)
	{
		ScreenType = type;
		Parameter = parameter;
		CanShow = canShow;
	}

	public PopupQueueItem(Func<Task> action)
	{
		Action = action;
	}

	public override bool Equals(object obj)
	{
		if (obj is PopupQueueItem popupQueueItem && ScreenType != null)
		{
			return EqualityComparer<Type>.Default.Equals(ScreenType, popupQueueItem.ScreenType);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(ScreenType);
	}
}
