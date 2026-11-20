using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

internal static class TraceInternal
{
	private sealed class TraceProvider : DebugProvider
	{
		public override void Fail(string message, string detailMessage)
		{
			TraceInternal.Fail(message, detailMessage);
		}

		public override void OnIndentLevelChanged(int indentLevel)
		{
			lock (critSec)
			{
				foreach (TraceListener listener in Listeners)
				{
					listener.IndentLevel = indentLevel;
				}
			}
		}

		public override void OnIndentSizeChanged(int indentSize)
		{
			lock (critSec)
			{
				foreach (TraceListener listener in Listeners)
				{
					listener.IndentSize = indentSize;
				}
			}
		}

		public override void Write(string message)
		{
			TraceInternal.Write(message);
		}

		public override void WriteLine(string message)
		{
			TraceInternal.WriteLine(message);
		}
	}

	private static volatile TraceListenerCollection s_listeners;

	private static volatile bool s_autoFlush;

	private static volatile bool s_useGlobalLock;

	private static volatile bool s_settingsInitialized;

	private static volatile bool s_settingsInitializing;

	internal static readonly object critSec = new object();

	public static TraceListenerCollection Listeners
	{
		get
		{
			InitializeSettings();
			if (s_listeners == null)
			{
				lock (critSec)
				{
					if (s_listeners == null)
					{
						Debug.SetProvider(new TraceProvider());
						s_listeners = new TraceListenerCollection();
						TraceListener traceListener = new DefaultTraceListener();
						traceListener.IndentLevel = Debug.IndentLevel;
						traceListener.IndentSize = Debug.IndentSize;
						s_listeners.Add(traceListener);
					}
				}
			}
			return s_listeners;
		}
	}

	public static bool AutoFlush
	{
		get
		{
			InitializeSettings();
			return s_autoFlush;
		}
	}

	public static bool UseGlobalLock
	{
		get
		{
			InitializeSettings();
			return s_useGlobalLock;
		}
	}

	public static int IndentLevel => Debug.IndentLevel;

	public static int IndentSize => Debug.IndentSize;

	[DoesNotReturn]
	public static void Fail(string message, string detailMessage)
	{
		if (UseGlobalLock)
		{
			lock (critSec)
			{
				foreach (TraceListener listener in Listeners)
				{
					listener.Fail(message, detailMessage);
					if (AutoFlush)
					{
						listener.Flush();
					}
				}
				return;
			}
		}
		foreach (TraceListener listener2 in Listeners)
		{
			if (!listener2.IsThreadSafe)
			{
				lock (listener2)
				{
					listener2.Fail(message, detailMessage);
					if (AutoFlush)
					{
						listener2.Flush();
					}
				}
			}
			else
			{
				listener2.Fail(message, detailMessage);
				if (AutoFlush)
				{
					listener2.Flush();
				}
			}
		}
	}

	private static void InitializeSettings()
	{
		if (s_settingsInitialized)
		{
			return;
		}
		lock (critSec)
		{
			if (!s_settingsInitializing)
			{
				s_settingsInitializing = true;
				if (!s_settingsInitialized)
				{
					s_autoFlush = false;
					s_useGlobalLock = true;
					s_settingsInitialized = true;
					s_settingsInitializing = false;
				}
			}
		}
	}

	public static void Write(string message)
	{
		if (UseGlobalLock)
		{
			lock (critSec)
			{
				foreach (TraceListener listener in Listeners)
				{
					listener.Write(message);
					if (AutoFlush)
					{
						listener.Flush();
					}
				}
				return;
			}
		}
		foreach (TraceListener listener2 in Listeners)
		{
			if (!listener2.IsThreadSafe)
			{
				lock (listener2)
				{
					listener2.Write(message);
					if (AutoFlush)
					{
						listener2.Flush();
					}
				}
			}
			else
			{
				listener2.Write(message);
				if (AutoFlush)
				{
					listener2.Flush();
				}
			}
		}
	}

	public static void WriteLine(string message)
	{
		if (UseGlobalLock)
		{
			lock (critSec)
			{
				foreach (TraceListener listener in Listeners)
				{
					listener.WriteLine(message);
					if (AutoFlush)
					{
						listener.Flush();
					}
				}
				return;
			}
		}
		foreach (TraceListener listener2 in Listeners)
		{
			if (!listener2.IsThreadSafe)
			{
				lock (listener2)
				{
					listener2.WriteLine(message);
					if (AutoFlush)
					{
						listener2.Flush();
					}
				}
			}
			else
			{
				listener2.WriteLine(message);
				if (AutoFlush)
				{
					listener2.Flush();
				}
			}
		}
	}
}
