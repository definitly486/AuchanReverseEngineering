using System;
using System.Collections.Generic;
using Java.Interop;

namespace Android.Runtime;

internal class IdentityHashTargets
{
	private WeakReference<IJavaPeerable>? first;

	private List<WeakReference<IJavaPeerable>?>? rest;

	public int Count => ((first != null) ? 1 : 0) + ((rest != null) ? rest.Count : 0);

	public WeakReference<IJavaPeerable>? this[int index]
	{
		get
		{
			if (index == 0)
			{
				return first;
			}
			index--;
			if (rest == null || index >= rest.Count)
			{
				return null;
			}
			return rest[index];
		}
		set
		{
			if (index == 0)
			{
				first = value;
				return;
			}
			index--;
			if (rest != null)
			{
				rest[index] = value;
			}
		}
	}

	public static WeakReference<IJavaPeerable> CreateWeakReference(IJavaPeerable value)
	{
		return new WeakReference<IJavaPeerable>(value, trackResurrection: true);
	}

	public IdentityHashTargets(IJavaPeerable value)
	{
		first = CreateWeakReference(value);
	}

	public void Add(IJavaPeerable value)
	{
		if (first == null)
		{
			first = CreateWeakReference(value);
			return;
		}
		if (rest == null)
		{
			rest = new List<WeakReference<IJavaPeerable>>();
		}
		rest.Add(CreateWeakReference(value));
	}

	public void RemoveAt(int index)
	{
		if (index == 0)
		{
			first = null;
			List<WeakReference<IJavaPeerable>?>? list = rest;
			if (list != null && list.Count > 0)
			{
				first = rest[0];
				rest.RemoveAt(0);
			}
		}
		else
		{
			index--;
			rest?.RemoveAt(index);
		}
	}
}
