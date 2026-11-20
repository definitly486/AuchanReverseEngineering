using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Net.Sockets;

internal sealed class SocketAsyncEngine : IThreadPoolWorkItem
{
	private readonly struct SocketEventHandler
	{
		private readonly ConcurrentQueue<SocketIOEvent> _eventQueue;

		public unsafe global::Interop.Sys.SocketEvent* Buffer { get; }

		public unsafe SocketEventHandler(SocketAsyncEngine engine)
		{
			Buffer = engine._buffer;
			_eventQueue = engine._eventQueue;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe bool HandleSocketEvents(int numEvents)
		{
			bool result = false;
			ReadOnlySpan<global::Interop.Sys.SocketEvent> readOnlySpan = new ReadOnlySpan<global::Interop.Sys.SocketEvent>(Buffer, numEvents);
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				global::Interop.Sys.SocketEvent socketEvent = readOnlySpan[i];
				SocketAsyncContext socketAsyncContext = s_registeredContexts[(int)socketEvent.Data];
				if (socketAsyncContext == null)
				{
					continue;
				}
				if (socketAsyncContext.PreferInlineCompletions)
				{
					socketAsyncContext.HandleEventsInline(socketEvent.Events);
					continue;
				}
				global::Interop.Sys.SocketEvents socketEvents = socketAsyncContext.HandleSyncEventsSpeculatively(socketEvent.Events);
				if (socketEvents != global::Interop.Sys.SocketEvents.None)
				{
					_eventQueue.Enqueue(new SocketIOEvent(socketAsyncContext, socketEvents));
					result = true;
				}
			}
			return result;
		}
	}

	private readonly struct SocketIOEvent
	{
		public SocketAsyncContext Context { get; }

		public global::Interop.Sys.SocketEvents Events { get; }

		public SocketIOEvent(SocketAsyncContext context, global::Interop.Sys.SocketEvents events)
		{
			Context = context;
			Events = events;
		}
	}

	internal static readonly bool InlineSocketCompletionsEnabled = Environment.GetEnvironmentVariable("DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS") == "1";

	private static readonly SocketAsyncEngine[] s_engines = CreateEngines();

	private static int s_allocateFromEngine = -1;

	private static SocketAsyncContext[] s_registeredContexts = Array.Empty<SocketAsyncContext>();

	private static readonly Queue<int> s_registeredContextsFreeList = new Queue<int>();

	private readonly nint _port;

	private unsafe readonly global::Interop.Sys.SocketEvent* _buffer;

	private readonly ConcurrentQueue<SocketIOEvent> _eventQueue = new ConcurrentQueue<SocketIOEvent>();

	private int _hasOutstandingThreadRequest;

	private static int GetEngineCount()
	{
		if (uint.TryParse(Environment.GetEnvironmentVariable("DOTNET_SYSTEM_NET_SOCKETS_THREAD_COUNT"), out var result))
		{
			return (int)result;
		}
		if (InlineSocketCompletionsEnabled)
		{
			return Environment.ProcessorCount;
		}
		Architecture architecture = Architecture.Arm;
		int num = ((architecture == Architecture.Arm64 || architecture == Architecture.Arm) ? 8 : 30);
		return Math.Max(1, (int)Math.Round((double)Environment.ProcessorCount / (double)num));
	}

	private static SocketAsyncEngine[] CreateEngines()
	{
		int engineCount = GetEngineCount();
		SocketAsyncEngine[] array = new SocketAsyncEngine[engineCount];
		for (int i = 0; i < engineCount; i++)
		{
			array[i] = new SocketAsyncEngine();
		}
		return array;
	}

	public static bool TryRegisterSocket(nint socketHandle, SocketAsyncContext context, out SocketAsyncEngine engine, out global::Interop.Error error)
	{
		int num = Math.Abs(Interlocked.Increment(ref s_allocateFromEngine) % s_engines.Length);
		SocketAsyncEngine socketAsyncEngine = s_engines[num];
		bool flag = socketAsyncEngine.TryRegisterCore(socketHandle, context, out error);
		engine = (flag ? socketAsyncEngine : null);
		return flag;
	}

	private bool TryRegisterCore(nint socketHandle, SocketAsyncContext context, out global::Interop.Error error)
	{
		lock (s_registeredContextsFreeList)
		{
			if (!s_registeredContextsFreeList.TryDequeue(out var result))
			{
				int num = s_registeredContexts.Length;
				int num2 = Math.Max(4, 2 * num);
				Array.Resize(ref s_registeredContexts, num2);
				for (int i = num + 1; i < num2; i++)
				{
					s_registeredContextsFreeList.Enqueue(i);
				}
				result = num;
			}
			s_registeredContexts[result] = context;
			context.GlobalContextIndex = result;
		}
		error = global::Interop.Sys.TryChangeSocketEventRegistration(_port, socketHandle, global::Interop.Sys.SocketEvents.None, global::Interop.Sys.SocketEvents.Read | global::Interop.Sys.SocketEvents.Write, context.GlobalContextIndex);
		if (error == global::Interop.Error.SUCCESS)
		{
			return true;
		}
		UnregisterSocket(context);
		return false;
	}

	public static void UnregisterSocket(SocketAsyncContext context)
	{
		lock (s_registeredContextsFreeList)
		{
			s_registeredContexts[context.GlobalContextIndex] = null;
			s_registeredContextsFreeList.Enqueue(context.GlobalContextIndex);
		}
		context.GlobalContextIndex = -1;
	}

	private unsafe SocketAsyncEngine()
	{
		_port = -1;
		try
		{
			fixed (nint* port = &_port)
			{
				global::Interop.Error error = global::Interop.Sys.CreateSocketEventPort(port);
				if (error != global::Interop.Error.SUCCESS)
				{
					throw new InternalException(error);
				}
			}
			fixed (global::Interop.Sys.SocketEvent** buffer = &_buffer)
			{
				global::Interop.Error error = global::Interop.Sys.CreateSocketEventBuffer(1024, buffer);
				if (error != global::Interop.Error.SUCCESS)
				{
					throw new InternalException(error);
				}
			}
			Thread thread = new Thread(delegate(object s)
			{
				((SocketAsyncEngine)s).EventLoop();
			});
			thread.IsBackground = true;
			thread.Name = ".NET Sockets";
			thread.UnsafeStart(this);
		}
		catch
		{
			FreeNativeResources();
			throw;
		}
	}

	private unsafe void EventLoop()
	{
		try
		{
			SocketEventHandler socketEventHandler = new SocketEventHandler(this);
			global::Interop.Error error;
			while (true)
			{
				int numEvents = 1024;
				error = global::Interop.Sys.WaitForSocketEvents(_port, socketEventHandler.Buffer, &numEvents);
				if (error != global::Interop.Error.SUCCESS)
				{
					break;
				}
				if (socketEventHandler.HandleSocketEvents(numEvents))
				{
					EnsureWorkerScheduled();
				}
			}
			throw new InternalException(error);
		}
		catch (Exception ex)
		{
			Environment.FailFast("Exception thrown from SocketAsyncEngine event loop: " + ex.ToString(), ex);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void EnsureWorkerScheduled()
	{
		if (Interlocked.Exchange(ref _hasOutstandingThreadRequest, 1) == 0)
		{
			ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: false);
		}
	}

	void IThreadPoolWorkItem.Execute()
	{
		_hasOutstandingThreadRequest = 0;
		Interlocked.MemoryBarrier();
		ConcurrentQueue<SocketIOEvent> eventQueue = _eventQueue;
		if (eventQueue.TryDequeue(out var result))
		{
			if (!eventQueue.IsEmpty)
			{
				EnsureWorkerScheduled();
			}
			int tickCount = Environment.TickCount;
			do
			{
				result.Context.HandleEvents(result.Events);
			}
			while (Environment.TickCount - tickCount < 15 && eventQueue.TryDequeue(out result));
		}
	}

	private unsafe void FreeNativeResources()
	{
		if (_buffer != null)
		{
			global::Interop.Sys.FreeSocketEventBuffer(_buffer);
		}
		if (_port != -1)
		{
			global::Interop.Sys.CloseSocketEventPort(_port);
		}
	}
}
