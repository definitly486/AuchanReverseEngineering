using System;
using Java.Lang;

namespace Java.Interop;

public static class EventHelper
{
	public static void AddEventHandler<TInterface, TImplementor>(ref WeakReference? implementor, Func<TImplementor> creator, Action<TInterface> setListener, Action<TImplementor> add) where TImplementor : Java.Lang.Object, TInterface
	{
		TImplementor val = null;
		if (implementor == null || (val = (TImplementor)implementor.Target) == null)
		{
			val = creator();
			implementor = new WeakReference(val, trackResurrection: true);
			setListener((TInterface)(object)val);
		}
		add(val);
	}

	public static void RemoveEventHandler<TInterface, TImplementor>(ref WeakReference? implementor, Func<TImplementor, bool> empty, Action<TInterface> unsetListener, Action<TImplementor> remove) where TImplementor : Java.Lang.Object, TInterface
	{
		TImplementor val = null;
		if (implementor != null && (val = (TImplementor)implementor.Target) != null)
		{
			remove(val);
			if (empty(val))
			{
				unsetListener((TInterface)(object)val);
				val = null;
				implementor.Target = null;
				implementor = null;
			}
		}
	}
}
