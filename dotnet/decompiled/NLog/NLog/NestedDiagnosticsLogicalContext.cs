using System;
using System.Linq;
using System.Threading;
using NLog.Internal;

namespace NLog;

[Obsolete("Replaced by ScopeContext.PushNestedState or Logger.PushScopeNested using ${scopenested}. Marked obsolete on NLog 5.0")]
public static class NestedDiagnosticsLogicalContext
{
	[Obsolete("Required to be compatible with legacy NLog versions, when using remoting. Marked obsolete on NLog 5.0")]
	private interface INestedContext : IDisposable
	{
		INestedContext Parent { get; }

		int FrameLevel { get; }

		object? Value { get; }

		long CreatedTimeUtcTicks { get; }
	}

	[Obsolete("Required to be compatible with legacy NLog versions, when using remoting. Marked obsolete on NLog 5.0")]
	private sealed class NestedContext<T> : INestedContext, IDisposable
	{
		private int _disposed;

		public INestedContext Parent { get; }

		public T Value { get; }

		public long CreatedTimeUtcTicks { get; }

		public int FrameLevel { get; }

		object? INestedContext.Value => Value;

		public NestedContext(INestedContext parent, T value)
		{
			Parent = parent;
			Value = value;
			CreatedTimeUtcTicks = DateTime.UtcNow.Ticks;
			FrameLevel = ((parent == null) ? 1 : (parent.FrameLevel + 1));
		}

		void IDisposable.Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) != 1)
			{
				PopObject();
			}
		}

		public override string ToString()
		{
			return ((object)Value)?.ToString() ?? "null";
		}
	}

	[Obsolete("Replaced by ScopeContext.PushNestedState or Logger.PushScopeNested using ${scopenested}. Marked obsolete on NLog 5.0")]
	public static IDisposable Push<T>(T value)
	{
		return ScopeContext.PushNestedState(value);
	}

	[Obsolete("Replaced by ScopeContext.PushNestedState or Logger.PushScopeNested using ${scopenested}. Marked obsolete on NLog 5.0")]
	public static IDisposable PushObject(object value)
	{
		return Push(value);
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushNestedState or Logger.PushScopeNested. Marked obsolete on NLog 5.0")]
	public static object? Pop()
	{
		return PopObject();
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushNestedState or Logger.PushScopeNested. Marked obsolete on NLog 5.0")]
	public static string Pop(IFormatProvider formatProvider)
	{
		return FormatHelper.ConvertToString(PopObject() ?? string.Empty, formatProvider);
	}

	[Obsolete("Replaced by dispose of return value from ScopeContext.PushNestedState or Logger.PushScopeNested. Marked obsolete on NLog 5.0")]
	public static object? PopObject()
	{
		return ScopeContext.PopNestedContextLegacy();
	}

	[Obsolete("Replaced by ScopeContext.PeekNestedState. Marked obsolete on NLog 5.0")]
	public static object? PeekObject()
	{
		return ScopeContext.PeekNestedState();
	}

	[Obsolete("Replaced by ScopeContext.Clear. Marked obsolete on NLog 5.0")]
	public static void Clear()
	{
		ScopeContext.ClearNestedContextLegacy();
	}

	[Obsolete("Replaced by ScopeContext.GetAllNestedStates. Marked obsolete on NLog 5.0")]
	public static string[] GetAllMessages()
	{
		return GetAllMessages(null);
	}

	[Obsolete("Replaced by ScopeContext.GetAllNestedStates. Marked obsolete on NLog 5.0")]
	public static string[] GetAllMessages(IFormatProvider? formatProvider)
	{
		return (from o in GetAllObjects()
			select FormatHelper.ConvertToString(o, formatProvider)).ToArray();
	}

	[Obsolete("Replaced by ScopeContext.GetAllNestedStates. Marked obsolete on NLog 5.0")]
	public static object[] GetAllObjects()
	{
		return ScopeContext.GetAllNestedStates();
	}
}
