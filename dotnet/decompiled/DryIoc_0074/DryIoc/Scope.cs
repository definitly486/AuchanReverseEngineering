using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public class Scope : IScope, IEnumerable<IScope>, IEnumerable, IDisposable
{
	internal sealed class WithParentAndName : Scope
	{
		public override IScope Parent { get; }

		public override object Name { get; }

		internal WithParentAndName(IScope parent, object name)
		{
			Parent = parent;
			Name = name;
		}

		internal WithParentAndName(IScope parent, object name, ImMap<object>[] maps, ImHashMap<Type, object> used, ImMap<ImList<IDisposable>> disposables)
			: base(maps, used, disposables)
		{
			Parent = parent;
			Name = name;
		}

		public override IScope Clone(bool withDisposables)
		{
			return new WithParentAndName(Parent?.Clone(withDisposables), Name, _maps.CopyNonEmpty(), _used, withDisposables ? _disposables : CreateEmptyDisposables());
		}
	}

	private int _disposed;

	private ImMap<ImList<IDisposable>> _disposables;

	private ImHashMap<Type, object> _used;

	internal const int MAP_COUNT = 16;

	internal const int MAP_COUNT_SUFFIX_MASK = 15;

	internal ImMap<object>[] _maps;

	internal static readonly object NoItem = new object();

	private static ImMap<object>[] _emptyMaps = CreateEmptyMaps();

	internal static readonly MethodInfo GetOrAddViaFactoryDelegateMethod = typeof(IScope).GetMethod("GetOrAddViaFactoryDelegate");

	internal static readonly MethodInfo GetOrAddViaFactoryDelegateWithDisposalOrderMethod = typeof(IScope).GetMethod("GetOrAddViaFactoryDelegateWithDisposalOrder");

	public static uint WaitForScopedServiceIsCreatedTimeoutTicks = 3000u;

	internal static readonly MethodInfo TrackDisposableOpenGenericMethod = typeof(IScope).GetMethod("TrackDisposable");

	public virtual IScope Parent => null;

	public virtual object Name => null;

	public bool IsDisposed => _disposed == 1;

	private static ImMap<object>[] CreateEmptyMaps()
	{
		ImMap<object>[] array = new ImMap<object>[16];
		ImMap<object> empty = ImMap<object>.Empty;
		for (int i = 0; i < 16; i++)
		{
			array[i] = empty;
		}
		return array;
	}

	private static ImMap<ImList<IDisposable>> CreateEmptyDisposables()
	{
		return ImMap.Entry(0, ImList<IDisposable>.Empty);
	}

	internal ImMap<object>[] CloneMaps()
	{
		return _maps.CopyNonEmpty();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IScope Of(IScope parent, object name)
	{
		if (parent != null || name != null)
		{
			return new WithParentAndName(parent, name);
		}
		return new Scope();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IScope Of(IScope parent)
	{
		if (parent != null)
		{
			return new WithParentAndName(parent, null);
		}
		return new Scope();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IScope Of(object name)
	{
		if (name != null)
		{
			return new WithParentAndName(null, name);
		}
		return new Scope();
	}

	public Scope()
		: this(CreateEmptyMaps(), ImHashMap<Type, object>.Empty, CreateEmptyDisposables())
	{
	}

	protected Scope(ImMap<object>[] maps, ImHashMap<Type, object> used, ImMap<ImList<IDisposable>> disposables)
	{
		_disposables = disposables;
		_used = used;
		_maps = maps;
	}

	public virtual IScope Clone(bool withDisposables)
	{
		return new Scope(_maps.CopyNonEmpty(), _used, withDisposables ? _disposables : CreateEmptyDisposables());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public object GetOrAddViaFactoryDelegate(int id, FactoryDelegate createValue, IResolverContext r)
	{
		ImMapEntry<object> entryOrDefault = _maps[id & 0xF].GetEntryOrDefault(id);
		if (entryOrDefault == null)
		{
			return TryGetOrAddViaFactoryDelegate(id, createValue, r);
		}
		if (entryOrDefault.Value == NoItem)
		{
			return WaitForItemIsSet(entryOrDefault);
		}
		return entryOrDefault.Value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public object GetOrAddViaFactoryDelegateWithDisposalOrder(int id, FactoryDelegate createValue, IResolverContext r, int disposalOrder)
	{
		ImMapEntry<object> entryOrDefault = _maps[id & 0xF].GetEntryOrDefault(id);
		if (entryOrDefault == null)
		{
			return TryGetOrAddViaFactoryDelegate(id, createValue, r, disposalOrder);
		}
		if (entryOrDefault.Value == NoItem)
		{
			return WaitForItemIsSet(entryOrDefault);
		}
		return entryOrDefault.Value;
	}

	internal object TryGetOrAddViaFactoryDelegate(int id, FactoryDelegate createValue, IResolverContext r, int disposalOrder = 0)
	{
		if (_disposed == 1)
		{
			Throw.ScopeIsDisposed(this, r);
		}
		ImMapEntry<object> imMapEntry = new ImMapEntry<object>(id, NoItem);
		ref ImMap<object> reference = ref _maps[id & 0xF];
		ImMap<object> imMap = reference;
		ImMap<object> imMap2 = imMap.AddOrGetEntry(imMapEntry);
		if (imMap2 is ImMapEntry<object> imMapEntry2 && imMapEntry2 != imMapEntry)
		{
			if (imMapEntry2.Value == NoItem)
			{
				return WaitForItemIsSet(imMapEntry2);
			}
			return imMapEntry2.Value;
		}
		if (Interlocked.CompareExchange(ref reference, imMap2, imMap) != imMap)
		{
			imMap2 = Ref.SwapAndGetNewValue(ref reference, imMapEntry, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrKeepEntry(i));
			ImMapEntry<object> surePresentEntry = imMap2.GetSurePresentEntry(id);
			if (surePresentEntry != imMapEntry)
			{
				if (surePresentEntry.Value == NoItem)
				{
					return WaitForItemIsSet(surePresentEntry);
				}
				return surePresentEntry.Value;
			}
		}
		object obj = null;
		obj = (imMapEntry.Value = createValue(r));
		if (obj is IDisposable disposable && disposable != this)
		{
			AddDisposable(disposable, disposalOrder);
		}
		return obj;
	}

	internal static object WaitForItemIsSet(ImMapEntry<object> itemRef)
	{
		uint tickCount = (uint)Environment.TickCount;
		uint num = tickCount;
		SpinWait spinWait = default(SpinWait);
		while (itemRef.Value == NoItem)
		{
			spinWait.SpinOnce();
			if (tickCount - num > WaitForScopedServiceIsCreatedTimeoutTicks)
			{
				Throw.WithDetails(itemRef.Key, Error.WaitForScopedServiceIsCreatedTimeoutExpired, WaitForScopedServiceIsCreatedTimeoutTicks);
			}
			tickCount = (uint)Environment.TickCount;
		}
		return itemRef.Value;
	}

	public object TryGetOrAddWithoutClosure(int id, IResolverContext resolveContext, Expression expr, Func<IResolverContext, Expression, object> createValue, int disposalOrder = 0)
	{
		if (_disposed == 1)
		{
			Throw.ScopeIsDisposed(this, resolveContext);
		}
		ImMapEntry<object> imMapEntry = new ImMapEntry<object>(id, NoItem);
		ref ImMap<object> reference = ref _maps[id & 0xF];
		ImMap<object> imMap = reference;
		ImMap<object> imMap2 = imMap.AddOrKeepEntry(imMapEntry);
		if (Interlocked.CompareExchange(ref reference, imMap2, imMap) != imMap)
		{
			imMap2 = Ref.SwapAndGetNewValue(ref reference, imMapEntry, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrKeepEntry(i));
			ImMapEntry<object> surePresentEntry = imMap2.GetSurePresentEntry(id);
			if (surePresentEntry != imMapEntry)
			{
				if (surePresentEntry.Value == NoItem)
				{
					return WaitForItemIsSet(surePresentEntry);
				}
				return surePresentEntry.Value;
			}
		}
		else if (imMap2 == imMap)
		{
			ImMapEntry<object> surePresentEntry2 = imMap2.GetSurePresentEntry(id);
			if (surePresentEntry2.Value == NoItem)
			{
				return WaitForItemIsSet(surePresentEntry2);
			}
			return surePresentEntry2.Value;
		}
		object obj = null;
		obj = (imMapEntry.Value = createValue(resolveContext, expr));
		if (obj is IDisposable disposable && disposable != this)
		{
			AddDisposable(disposable, disposalOrder);
		}
		return obj;
	}

	public void SetOrAdd(int id, object item)
	{
		if (_disposed == 1)
		{
			Throw.ScopeIsDisposed(this, null);
		}
		ImMapEntry<object> imMapEntry = new ImMapEntry<object>(id, item);
		ref ImMap<object> reference = ref _maps[id & 0xF];
		ImMap<object> imMap = reference;
		ImMap<object> value = imMap.AddOrUpdateEntry(imMapEntry);
		if (Interlocked.CompareExchange(ref reference, value, imMap) != imMap)
		{
			Ref.Swap(ref reference, imMapEntry, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrUpdateEntry(i));
		}
		if (item is IDisposable disposable && disposable != this)
		{
			AddUnorderedDisposable(disposable);
		}
	}

	internal void AddDisposable(IDisposable disposable, int disposalOrder = 0)
	{
		if (disposalOrder == 0)
		{
			AddUnorderedDisposable(disposable);
			return;
		}
		ImMapEntry<ImList<IDisposable>> imMapEntry = _disposables.GetEntryOrDefault(disposalOrder) ?? AddDisposableEntry(disposalOrder);
		ImList<IDisposable> value = imMapEntry.Value;
		if (Interlocked.CompareExchange(ref imMapEntry.Value, value.Push(disposable), value) != value)
		{
			Ref.Swap(ref imMapEntry.Value, disposable, (ImList<IDisposable> x, IDisposable d) => x.Push(d));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void AddUnorderedDisposable(IDisposable disposable)
	{
		ImMapEntry<ImList<IDisposable>> entryOrDefault = _disposables.GetEntryOrDefault(0);
		ImList<IDisposable> value = entryOrDefault.Value;
		if (Interlocked.CompareExchange(ref entryOrDefault.Value, value.Push(disposable), value) != value)
		{
			Ref.Swap(ref entryOrDefault.Value, disposable, (ImList<IDisposable> x, IDisposable d) => x.Push(d));
		}
	}

	private ImMapEntry<ImList<IDisposable>> AddDisposableEntry(int disposableOrder)
	{
		Ref.Swap(ref _disposables, disposableOrder, (ImMap<ImList<IDisposable>> x, int o) => x.AddOrKeep(o, ImList<IDisposable>.Empty));
		return _disposables.GetSurePresentEntry(disposableOrder);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGet(out object item, int id)
	{
		ImMapEntry<object> entryOrDefault = _maps[id & 0xF].GetEntryOrDefault(id);
		if (entryOrDefault != null && entryOrDefault.Value != NoItem)
		{
			item = entryOrDefault.Value;
			return true;
		}
		item = null;
		return false;
	}

	public T TrackDisposable<T>(T item, int disposalOrder = 0) where T : IDisposable
	{
		if ((object)item != this)
		{
			AddDisposable(item, disposalOrder);
		}
		return item;
	}

	public void SetUsed(int hash, Type type, object instance)
	{
		if (_disposed == 1)
		{
			Throw.It(Error.ScopeIsDisposed, ToString());
		}
		ImHashMap<Type, object> used = _used;
		if (Interlocked.CompareExchange(ref _used, used.AddOrUpdate(hash, type, instance), used) != used)
		{
			Ref.Swap(ref _used, hash, type, instance, (ImHashMap<Type, object> x, int h, Type t, object i) => x.AddOrUpdate(h, t, i));
		}
	}

	public bool TryGetUsed(int hash, Type type, out object used)
	{
		if (_disposed != 1)
		{
			if (!_used.IsEmpty)
			{
				ImHashMapEntry<Type, object> entryOrDefaultByReferenceEquals = _used.GetEntryOrDefaultByReferenceEquals(hash, type);
				if (entryOrDefaultByReferenceEquals != null)
				{
					used = entryOrDefaultByReferenceEquals.Value;
					return true;
				}
			}
			IScope parent = Parent;
			if (parent != null)
			{
				return parent.TryGetUsed(hash, type, out used);
			}
		}
		used = null;
		return false;
	}

	public IEnumerator<IScope> GetEnumerator()
	{
		for (IScope scope = this; scope != null; scope = scope.Parent)
		{
			yield return scope;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Dispose()
	{
		if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 1)
		{
			return;
		}
		ImMap<ImList<IDisposable>> disposables = _disposables;
		if (disposables is ImMapEntry<ImList<IDisposable>> { Value: var imList })
		{
			while (imList.Tail != null)
			{
				imList.Head.Dispose();
				imList = imList.Tail;
			}
		}
		else if (!disposables.IsEmpty)
		{
			SafelyDisposeOrderedDisposables(disposables);
		}
		_disposables = ImMap<ImList<IDisposable>>.Empty;
		_used = ImHashMap<Type, object>.Empty;
		_maps = _emptyMaps;
	}

	private static void SafelyDisposeOrderedDisposables(ImMap<ImList<IDisposable>> disposables)
	{
		disposables.ForEach(delegate(ImMapEntry<ImList<IDisposable>> e, int _)
		{
			try
			{
				ImList<IDisposable> imList = e.Value;
				while (!imList.IsEmpty)
				{
					imList.Head.Dispose();
					imList = imList.Tail;
				}
			}
			catch (ContainerException)
			{
				throw;
			}
			catch (Exception)
			{
			}
		});
	}

	public override string ToString()
	{
		return "{" + (IsDisposed ? "IsDisposed=true, " : "") + ((Name != null) ? ("Name=" + Name) : "Name=null") + ((Parent != null) ? (", Parent=" + Parent) : "") + "}";
	}
}
