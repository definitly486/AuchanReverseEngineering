using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Common;

public sealed class ReferenceCounter<T> where T : class
{
	private sealed class Mark
	{
	}

	private readonly object _lock = new object();

	private readonly ConditionalWeakTable<T, Mark> _refs = new ConditionalWeakTable<T, Mark>();

	private readonly Mark _mark = new Mark();

	private readonly string _typeName;

	public static ReferenceCounter<T> Instance { get; } = new ReferenceCounter<T>();

	private ReferenceCounter()
	{
		Type typeFromHandle = typeof(T);
		_typeName = typeFromHandle.FullName ?? typeFromHandle.Name;
	}

	[Conditional("DEBUG")]
	public void Add(T reference)
	{
		lock (_lock)
		{
			_refs.Add(reference, _mark);
		}
	}

	public int Count()
	{
		int num = 0;
		lock (_lock)
		{
			return _refs.Count();
		}
	}

	public int Count(Func<T, bool> predicate)
	{
		int num = 0;
		lock (_lock)
		{
			return _refs.Count<KeyValuePair<T, Mark>>((KeyValuePair<T, Mark> i) => predicate(i.Key));
		}
	}

	[Conditional("DEBUG")]
	public void AddAndPrintCounter(T reference)
	{
	}

	[Conditional("DEBUG")]
	public void PrintCounter()
	{
	}

	[Conditional("DEBUG")]
	public void PrintCounter(string filterName, Func<T, bool> predicate)
	{
	}
}
public static class ReferenceCounter
{
	[Conditional("DEBUG")]
	public static void Add<T>(T reference) where T : class
	{
	}

	public static int Count<T>() where T : class
	{
		return ReferenceCounter<T>.Instance.Count();
	}

	public static int Count<T>(Func<T, bool> predicate) where T : class
	{
		return ReferenceCounter<T>.Instance.Count(predicate);
	}

	[Conditional("DEBUG")]
	public static void AddAndPrintCounter<T>(T reference) where T : class
	{
	}

	[Conditional("DEBUG")]
	public static void PrintCounter<T>() where T : class
	{
	}

	[Conditional("DEBUG")]
	public static void PrintCounter<T>(string filterName, Func<T, bool> predicate) where T : class
	{
	}

	[Conditional("DEBUG")]
	public static void InvokeGC()
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
	}
}
