using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using NLog.Internal;

namespace NLog;

public static class ScopeContext
{
	private sealed class ScopeContextPropertiesCollapsed : IDisposable
	{
		private readonly IScopeContextAsyncState? _parent;

		private readonly IScopeContextPropertiesAsyncState _collapsed;

		private bool _disposed;

		public ScopeContextPropertiesCollapsed(IScopeContextAsyncState? parent, IScopeContextPropertiesAsyncState collapsed)
		{
			_parent = parent;
			_collapsed = collapsed;
		}

		public static Dictionary<string, object?>? BuildCollapsedDictionary(IScopeContextAsyncState? parent, int initialCapacity)
		{
			if (parent is IScopeContextPropertiesAsyncState { Parent: IScopeContextPropertiesAsyncState parent2, NestedState: null } && parent2.NestedState == null)
			{
				List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
				IReadOnlyCollection<KeyValuePair<string, object>> readOnlyCollection = new ScopeContextPropertyCollector(list).StartCaptureProperties(parent);
				if (list.Count > 0 && readOnlyCollection is Dictionary<string, object> result)
				{
					return result;
				}
				Dictionary<string, object> dictionary = new Dictionary<string, object>(readOnlyCollection.Count + initialCapacity, DefaultComparer);
				ScopeContextPropertyEnumerator<object>.CopyScopePropertiesToDictionary(readOnlyCollection, dictionary);
				return dictionary;
			}
			return null;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				SetAsyncLocalContext(_parent);
			}
		}

		public override string ToString()
		{
			return _collapsed.ToString();
		}
	}

	internal static readonly IEqualityComparer<string> DefaultComparer = StringComparer.OrdinalIgnoreCase;

	private static readonly AsyncLocal<IScopeContextAsyncState?> AsyncNestedDiagnosticsContext = new AsyncLocal<IScopeContextAsyncState>();

	public static IDisposable PushNestedStateProperties(object? nestedState, IReadOnlyCollection<KeyValuePair<string, object?>>? properties)
	{
		properties = (IReadOnlyCollection<KeyValuePair<string, object?>>?)(((object)properties) ?? ((object)ArrayHelper.Empty<KeyValuePair<string, object>>()));
		if (properties.Count > 0 || nestedState == null)
		{
			IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
			if (nestedState == null)
			{
				Dictionary<string, object> dictionary = ScopeContextPropertiesCollapsed.BuildCollapsedDictionary(asyncLocalContext, properties.Count);
				if (dictionary != null)
				{
					ScopeContextPropertyEnumerator<object>.CopyScopePropertiesToDictionary(properties, dictionary);
					ScopeContextPropertiesAsyncState<object> scopeContextPropertiesAsyncState = new ScopeContextPropertiesAsyncState<object>(asyncLocalContext?.Parent?.Parent, dictionary, nestedState);
					SetAsyncLocalContext(scopeContextPropertiesAsyncState);
					return new ScopeContextPropertiesCollapsed(asyncLocalContext, scopeContextPropertiesAsyncState);
				}
			}
			ScopeContextPropertiesAsyncState<object> scopeContextPropertiesAsyncState2 = new ScopeContextPropertiesAsyncState<object>(asyncLocalContext, properties, nestedState);
			SetAsyncLocalContext(scopeContextPropertiesAsyncState2);
			return scopeContextPropertiesAsyncState2;
		}
		return PushNestedState(nestedState);
	}

	public static IDisposable PushProperties(IReadOnlyCollection<KeyValuePair<string, object?>> properties)
	{
		return ScopeContext.PushProperties<object>(properties);
	}

	public static IDisposable PushProperties<TValue>(IReadOnlyCollection<KeyValuePair<string, TValue?>> properties)
	{
		IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
		Dictionary<string, object> dictionary = ScopeContextPropertiesCollapsed.BuildCollapsedDictionary(asyncLocalContext, properties.Count);
		if (dictionary != null)
		{
			ScopeContextPropertyEnumerator<TValue>.CopyScopePropertiesToDictionary(properties, dictionary);
			ScopeContextPropertiesAsyncState<object> scopeContextPropertiesAsyncState = new ScopeContextPropertiesAsyncState<object>(asyncLocalContext?.Parent?.Parent, dictionary);
			SetAsyncLocalContext(scopeContextPropertiesAsyncState);
			return new ScopeContextPropertiesCollapsed(asyncLocalContext, scopeContextPropertiesAsyncState);
		}
		ScopeContextPropertiesAsyncState<TValue> scopeContextPropertiesAsyncState2 = new ScopeContextPropertiesAsyncState<TValue>(asyncLocalContext, properties);
		SetAsyncLocalContext(scopeContextPropertiesAsyncState2);
		return scopeContextPropertiesAsyncState2;
	}

	public static IDisposable PushProperty<TValue>(string key, TValue? value)
	{
		Guard.ThrowIfNull(key, "key");
		IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
		Dictionary<string, object> dictionary = ScopeContextPropertiesCollapsed.BuildCollapsedDictionary(asyncLocalContext, 1);
		if (dictionary != null)
		{
			dictionary[key] = value;
			ScopeContextPropertiesAsyncState<object> scopeContextPropertiesAsyncState = new ScopeContextPropertiesAsyncState<object>(asyncLocalContext?.Parent?.Parent, dictionary);
			SetAsyncLocalContext(scopeContextPropertiesAsyncState);
			return new ScopeContextPropertiesCollapsed(asyncLocalContext, scopeContextPropertiesAsyncState);
		}
		ScopeContextPropertyAsyncState<TValue> scopeContextPropertyAsyncState = new ScopeContextPropertyAsyncState<TValue>(asyncLocalContext, key, value);
		SetAsyncLocalContext(scopeContextPropertyAsyncState);
		return scopeContextPropertyAsyncState;
	}

	public static IDisposable PushProperty(string key, object? value)
	{
		return ScopeContext.PushProperty<object>(key, value);
	}

	public static IDisposable PushNestedState<T>(T nestedState)
	{
		ScopedContextNestedAsyncState<T> scopedContextNestedAsyncState = new ScopedContextNestedAsyncState<T>(GetAsyncLocalContext(), nestedState);
		SetAsyncLocalContext(scopedContextNestedAsyncState);
		return scopedContextNestedAsyncState;
	}

	public static IDisposable PushNestedState(object nestedState)
	{
		return ScopeContext.PushNestedState<object>(nestedState);
	}

	public static void Clear()
	{
		SetAsyncLocalContext(null);
	}

	public static IEnumerable<KeyValuePair<string, object?>> GetAllProperties()
	{
		IScopeContextAsyncState? asyncLocalContext = GetAsyncLocalContext();
		ScopeContextPropertyCollector contextCollector = default(ScopeContextPropertyCollector);
		return (IEnumerable<KeyValuePair<string, object?>>)(((object)asyncLocalContext?.CaptureContextProperties(ref contextCollector)) ?? ((object)ArrayHelper.Empty<KeyValuePair<string, object>>()));
	}

	internal static ScopeContextPropertyEnumerator<object?> GetAllPropertiesEnumerator()
	{
		return new ScopeContextPropertyEnumerator<object>(GetAllProperties());
	}

	public static bool TryGetProperty(string key, out object? value)
	{
		IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
		if (asyncLocalContext != null)
		{
			ScopeContextPropertyCollector contextCollector = default(ScopeContextPropertyCollector);
			IReadOnlyCollection<KeyValuePair<string, object>> readOnlyCollection = asyncLocalContext.CaptureContextProperties(ref contextCollector);
			if (readOnlyCollection != null && readOnlyCollection.Count > 0)
			{
				return TryLookupProperty(readOnlyCollection, key, out value);
			}
		}
		value = null;
		return false;
	}

	public static object[] GetAllNestedStates()
	{
		IList<object> allNestedStateList = GetAllNestedStateList();
		if (allNestedStateList != null && allNestedStateList.Count > 0)
		{
			if (allNestedStateList is object[] result)
			{
				return result;
			}
			return allNestedStateList.ToArray();
		}
		return ArrayHelper.Empty<object>();
	}

	internal static IList<object> GetAllNestedStateList()
	{
		IScopeContextAsyncState? asyncLocalContext = GetAsyncLocalContext();
		ScopeContextNestedStateCollector contextCollector = default(ScopeContextNestedStateCollector);
		return asyncLocalContext?.CaptureNestedContext(ref contextCollector) ?? ArrayHelper.Empty<object>();
	}

	public static object? PeekNestedState()
	{
		for (IScopeContextAsyncState scopeContextAsyncState = GetAsyncLocalContext(); scopeContextAsyncState != null; scopeContextAsyncState = scopeContextAsyncState.Parent)
		{
			object nestedState = scopeContextAsyncState.NestedState;
			if (nestedState != null)
			{
				return nestedState;
			}
		}
		return null;
	}

	internal static TimeSpan? PeekInnerNestedDuration()
	{
		long nestedContextTimestampNow = GetNestedContextTimestampNow();
		for (IScopeContextAsyncState scopeContextAsyncState = GetAsyncLocalContext(); scopeContextAsyncState != null; scopeContextAsyncState = scopeContextAsyncState.Parent)
		{
			long nestedStateTimestamp = scopeContextAsyncState.NestedStateTimestamp;
			if (nestedStateTimestamp != 0L)
			{
				return GetNestedStateDuration(nestedStateTimestamp, nestedContextTimestampNow);
			}
		}
		return null;
	}

	internal static TimeSpan? PeekOuterNestedDuration()
	{
		long nestedContextTimestampNow = GetNestedContextTimestampNow();
		IScopeContextAsyncState scopeContextAsyncState = GetAsyncLocalContext();
		long num = 0L;
		while (scopeContextAsyncState != null)
		{
			if (scopeContextAsyncState.NestedStateTimestamp != 0L)
			{
				num = scopeContextAsyncState.NestedStateTimestamp;
			}
			scopeContextAsyncState = scopeContextAsyncState.Parent;
		}
		if (num != 0L)
		{
			return GetNestedStateDuration(num, nestedContextTimestampNow);
		}
		return null;
	}

	private static bool TryLookupProperty(IReadOnlyCollection<KeyValuePair<string, object?>> scopeProperties, string key, out object? value)
	{
		if (scopeProperties is Dictionary<string, object> dictionary && dictionary.Comparer == DefaultComparer)
		{
			return dictionary.TryGetValue(key, out value);
		}
		using (ScopeContextPropertyEnumerator<object> scopeContextPropertyEnumerator = new ScopeContextPropertyEnumerator<object>(scopeProperties))
		{
			while (scopeContextPropertyEnumerator.MoveNext())
			{
				KeyValuePair<string, object> current = scopeContextPropertyEnumerator.Current;
				if (DefaultComparer.Equals(current.Key, key))
				{
					value = current.Value;
					return true;
				}
			}
		}
		value = null;
		return false;
	}

	internal static long GetNestedContextTimestampNow()
	{
		if (Stopwatch.IsHighResolution)
		{
			return Stopwatch.GetTimestamp();
		}
		return Environment.TickCount;
	}

	private static TimeSpan GetNestedStateDuration(long scopeTimestamp, long currentTimestamp)
	{
		if (Stopwatch.IsHighResolution)
		{
			return TimeSpan.FromTicks((currentTimestamp - scopeTimestamp) * 10000000 / Stopwatch.Frequency);
		}
		return TimeSpan.FromMilliseconds((double)((int)currentTimestamp - (int)scopeTimestamp));
	}

	internal static void SetAsyncLocalContext(IScopeContextAsyncState? newValue)
	{
		AsyncNestedDiagnosticsContext.Value = newValue;
	}

	private static IScopeContextAsyncState? GetAsyncLocalContext()
	{
		return AsyncNestedDiagnosticsContext.Value;
	}

	[Obsolete("Replaced by ScopeContext.PushProperty. Marked obsolete on NLog 5.0")]
	internal static void SetMappedContextLegacy<TValue>(string key, TValue? value)
	{
		PushProperty(key, value);
	}

	internal static ICollection<string> GetKeysMappedContextLegacy()
	{
		IScopeContextAsyncState? asyncLocalContext = GetAsyncLocalContext();
		ScopeContextPropertyCollector contextCollector = default(ScopeContextPropertyCollector);
		IReadOnlyCollection<KeyValuePair<string, object>> readOnlyCollection = asyncLocalContext?.CaptureContextProperties(ref contextCollector);
		if (readOnlyCollection != null && readOnlyCollection.Count > 0)
		{
			if (readOnlyCollection.Count == 1)
			{
				return new string[1] { readOnlyCollection.First().Key };
			}
			if (readOnlyCollection is IDictionary<string, object> dictionary)
			{
				return dictionary.Keys;
			}
			return readOnlyCollection.Select((KeyValuePair<string, object> prop) => prop.Key).ToList();
		}
		return ArrayHelper.Empty<string>();
	}

	[Obsolete("Replaced by disposing return value from ScopeContext.PushProperty. Marked obsolete on NLog 5.0")]
	internal static void RemoveMappedContextLegacy(string key)
	{
		if (TryGetProperty(key, out object _))
		{
			ScopeContextLegacyAsyncState.CaptureLegacyContext(GetAsyncLocalContext(), out Dictionary<string, object> allProperties, out object[] nestedContext, out long nestedContextTimestamp);
			allProperties.Remove(key);
			SetAsyncLocalContext(new ScopeContextLegacyAsyncState(allProperties, nestedContext, nestedContextTimestamp));
		}
	}

	[Obsolete("Replaced by disposing return value from ScopeContext.PushNestedState. Marked obsolete on NLog 5.0")]
	internal static object? PopNestedContextLegacy()
	{
		IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
		if (asyncLocalContext != null)
		{
			if ((asyncLocalContext.Parent == null && asyncLocalContext is ScopeContextLegacyAsyncState) || asyncLocalContext.NestedState == null)
			{
				ScopeContextNestedStateCollector contextCollector = default(ScopeContextNestedStateCollector);
				IList<object> list = asyncLocalContext.CaptureNestedContext(ref contextCollector) ?? ArrayHelper.Empty<object>();
				if (list.Count == 0)
				{
					return null;
				}
				ScopeContextPropertyCollector contextCollector2 = default(ScopeContextPropertyCollector);
				object result = list[0];
				IReadOnlyCollection<KeyValuePair<string, object>> allProperties = (IReadOnlyCollection<KeyValuePair<string, object>>)(((object)asyncLocalContext.CaptureContextProperties(ref contextCollector2)) ?? ((object)ArrayHelper.Empty<KeyValuePair<string, object>>()));
				object[] array = ArrayHelper.Empty<object>();
				if (list.Count > 1)
				{
					array = new object[list.Count - 1];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = list[i + 1];
					}
				}
				SetAsyncLocalContext(new ScopeContextLegacyAsyncState(allProperties, array, (array.Length != 0) ? GetNestedContextTimestampNow() : 0));
				return result;
			}
			SetAsyncLocalContext(asyncLocalContext.Parent);
			return asyncLocalContext.NestedState;
		}
		return null;
	}

	[Obsolete("Replaced by ScopeContext.Clear. Marked obsolete on NLog 5.0")]
	internal static void ClearMappedContextLegacy()
	{
		IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
		if (asyncLocalContext == null)
		{
			return;
		}
		ScopeContextLegacyAsyncState.CaptureLegacyContext(asyncLocalContext, out Dictionary<string, object> allProperties, out object[] nestedContext, out long nestedContextTimestamp);
		if (nestedContext != null && nestedContext.Length != 0)
		{
			if (allProperties != null && allProperties.Count > 0)
			{
				SetAsyncLocalContext(new ScopeContextLegacyAsyncState(null, nestedContext, nestedContextTimestamp));
			}
		}
		else
		{
			SetAsyncLocalContext(null);
		}
	}

	[Obsolete("Replaced by ScopeContext.Clear. Marked obsolete on NLog 5.0")]
	internal static void ClearNestedContextLegacy()
	{
		IScopeContextAsyncState asyncLocalContext = GetAsyncLocalContext();
		if (asyncLocalContext == null)
		{
			return;
		}
		ScopeContextLegacyAsyncState.CaptureLegacyContext(asyncLocalContext, out Dictionary<string, object> allProperties, out object[] nestedContext, out long _);
		if (allProperties != null && allProperties.Count > 0)
		{
			if (nestedContext != null && nestedContext.Length != 0)
			{
				SetAsyncLocalContext(new ScopeContextLegacyAsyncState(allProperties, ArrayHelper.Empty<object>(), 0L));
			}
		}
		else
		{
			SetAsyncLocalContext(null);
		}
	}
}
