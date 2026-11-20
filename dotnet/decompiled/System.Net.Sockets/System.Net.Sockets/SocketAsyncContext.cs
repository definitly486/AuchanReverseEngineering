using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Net.Sockets;

internal sealed class SocketAsyncContext
{
	private abstract class AsyncOperation : IThreadPoolWorkItem
	{
		private enum State
		{
			Waiting,
			Running,
			RunningWithPendingCancellation,
			Complete,
			Canceled
		}

		private volatile State _state;

		public readonly SocketAsyncContext AssociatedContext;

		public AsyncOperation Next;

		public SocketError ErrorCode;

		public Memory<byte> SocketAddress;

		public CancellationTokenRegistration CancellationRegistration;

		public ManualResetEventSlim Event { get; set; }

		public AsyncOperation(SocketAsyncContext context)
		{
			AssociatedContext = context;
			Reset();
		}

		public void Reset()
		{
			_state = State.Waiting;
			Event = null;
			Next = this;
		}

		public OperationResult TryComplete(SocketAsyncContext context)
		{
			if (Interlocked.CompareExchange(ref _state, State.Running, State.Waiting) == State.Canceled)
			{
				return OperationResult.Cancelled;
			}
			if (DoTryComplete(context))
			{
				_state = State.Complete;
				return OperationResult.Completed;
			}
			State state;
			State state2;
			do
			{
				state = _state;
				state2 = ((state != State.Running) ? State.Canceled : State.Waiting);
			}
			while (state != Interlocked.CompareExchange(ref _state, state2, state));
			if (state2 == State.Canceled)
			{
				ProcessCancellation();
				return OperationResult.Cancelled;
			}
			return OperationResult.Pending;
		}

		public bool TryCancel()
		{
			CancellationRegistration.Dispose();
			State state;
			State state2;
			do
			{
				state = _state;
				if ((uint)(state - 2) <= 2u)
				{
					return false;
				}
				state2 = ((state == State.Waiting) ? State.Canceled : State.RunningWithPendingCancellation);
			}
			while (state != Interlocked.CompareExchange(ref _state, state2, state));
			if (state2 == State.RunningWithPendingCancellation)
			{
				return false;
			}
			ProcessCancellation();
			return true;
		}

		public void ProcessCancellation()
		{
			ErrorCode = SocketError.OperationAborted;
			ManualResetEventSlim manualResetEventSlim = Event;
			if (manualResetEventSlim != null)
			{
				manualResetEventSlim.Set();
				return;
			}
			ThreadPool.UnsafeQueueUserWorkItem(delegate(object o)
			{
				((AsyncOperation)o).InvokeCallback(allowPooling: false);
			}, this);
		}

		public void Dispatch()
		{
			ManualResetEventSlim manualResetEventSlim = Event;
			if (manualResetEventSlim != null)
			{
				manualResetEventSlim.Set();
			}
			else
			{
				Schedule();
			}
		}

		public void Schedule()
		{
			ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: false);
		}

		public void Process()
		{
			((IThreadPoolWorkItem)this).Execute();
		}

		void IThreadPoolWorkItem.Execute()
		{
			throw new InvalidOperationException();
		}

		public void DoAbort()
		{
			ErrorCode = SocketError.OperationAborted;
		}

		protected abstract bool DoTryComplete(SocketAsyncContext context);

		public abstract void InvokeCallback(bool allowPooling);
	}

	private abstract class ReadOperation : AsyncOperation, IThreadPoolWorkItem
	{
		public ReadOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		void IThreadPoolWorkItem.Execute()
		{
			AssociatedContext.ProcessAsyncReadOperation(this);
		}
	}

	private abstract class WriteOperation : AsyncOperation, IThreadPoolWorkItem
	{
		public WriteOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		void IThreadPoolWorkItem.Execute()
		{
			AssociatedContext.ProcessAsyncWriteOperation(this);
		}
	}

	private abstract class SendOperation : WriteOperation
	{
		public SocketFlags Flags;

		public int BytesTransferred;

		public int Offset;

		public int Count;

		public Action<int, Memory<byte>, SocketFlags, SocketError> Callback { get; set; }

		public SendOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Callback(BytesTransferred, SocketAddress, SocketFlags.None, ErrorCode);
		}
	}

	private class BufferMemorySendOperation : SendOperation
	{
		public Memory<byte> Buffer;

		public BufferMemorySendOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected override bool DoTryComplete(SocketAsyncContext context)
		{
			int bufferIndex = 0;
			return SocketPal.TryCompleteSendTo(context._socket, Buffer.Span, null, ref bufferIndex, ref Offset, ref Count, Flags, SocketAddress.Span, ref BytesTransferred, out ErrorCode);
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Action<int, Memory<byte>, SocketFlags, SocketError> callback = base.Callback;
			int bytesTransferred = BytesTransferred;
			Memory<byte> socketAddress = SocketAddress;
			SocketError errorCode = ErrorCode;
			if (allowPooling)
			{
				AssociatedContext.ReturnOperation(this);
			}
			callback(bytesTransferred, socketAddress, SocketFlags.None, errorCode);
		}
	}

	private sealed class BufferListSendOperation : SendOperation
	{
		public IList<ArraySegment<byte>> Buffers;

		public int BufferIndex;

		public BufferListSendOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected override bool DoTryComplete(SocketAsyncContext context)
		{
			return SocketPal.TryCompleteSendTo(context._socket, default(ReadOnlySpan<byte>), Buffers, ref BufferIndex, ref Offset, ref Count, Flags, SocketAddress.Span, ref BytesTransferred, out ErrorCode);
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Action<int, Memory<byte>, SocketFlags, SocketError> callback = base.Callback;
			int bytesTransferred = BytesTransferred;
			Memory<byte> socketAddress = SocketAddress;
			SocketError errorCode = ErrorCode;
			if (allowPooling)
			{
				AssociatedContext.ReturnOperation(this);
			}
			callback(bytesTransferred, socketAddress, SocketFlags.None, errorCode);
		}
	}

	private sealed class BufferPtrSendOperation : SendOperation
	{
		public unsafe byte* BufferPtr;

		public BufferPtrSendOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected unsafe override bool DoTryComplete(SocketAsyncContext context)
		{
			int bufferIndex = 0;
			int length = Offset + Count;
			return SocketPal.TryCompleteSendTo(context._socket, new ReadOnlySpan<byte>(BufferPtr, length), null, ref bufferIndex, ref Offset, ref Count, Flags, SocketAddress.Span, ref BytesTransferred, out ErrorCode);
		}
	}

	private abstract class ReceiveOperation : ReadOperation
	{
		public SocketFlags Flags;

		public SocketFlags ReceivedFlags;

		public int BytesTransferred;

		public Action<int, Memory<byte>, SocketFlags, SocketError> Callback { get; set; }

		public ReceiveOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Callback(BytesTransferred, SocketAddress, ReceivedFlags, ErrorCode);
		}
	}

	private sealed class BufferMemoryReceiveOperation : ReceiveOperation
	{
		public Memory<byte> Buffer;

		public bool SetReceivedFlags;

		public BufferMemoryReceiveOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected override bool DoTryComplete(SocketAsyncContext context)
		{
			if (Buffer.Length == 0 && Flags == SocketFlags.None && SocketAddress.Length == 0)
			{
				BytesTransferred = 0;
				ReceivedFlags = SocketFlags.None;
				ErrorCode = SocketError.Success;
				return true;
			}
			if (!SetReceivedFlags)
			{
				ReceivedFlags = SocketFlags.None;
				return SocketPal.TryCompleteReceive(context._socket, Buffer.Span, Flags, out BytesTransferred, out ErrorCode);
			}
			int receivedSocketAddressLength;
			bool num = SocketPal.TryCompleteReceiveFrom(context._socket, Buffer.Span, null, Flags, SocketAddress.Span, out receivedSocketAddressLength, out BytesTransferred, out ReceivedFlags, out ErrorCode);
			if (num && ErrorCode == SocketError.Success)
			{
				SocketAddress = SocketAddress.Slice(0, receivedSocketAddressLength);
			}
			return num;
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Action<int, Memory<byte>, SocketFlags, SocketError> callback = base.Callback;
			int bytesTransferred = BytesTransferred;
			Memory<byte> socketAddress = SocketAddress;
			SocketFlags receivedFlags = ReceivedFlags;
			SocketError errorCode = ErrorCode;
			if (allowPooling)
			{
				AssociatedContext.ReturnOperation(this);
			}
			callback(bytesTransferred, socketAddress, receivedFlags, errorCode);
		}
	}

	private sealed class BufferListReceiveOperation : ReceiveOperation
	{
		public IList<ArraySegment<byte>> Buffers;

		public BufferListReceiveOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected override bool DoTryComplete(SocketAsyncContext context)
		{
			int receivedSocketAddressLength;
			bool num = SocketPal.TryCompleteReceiveFrom(context._socket, default(Span<byte>), Buffers, Flags, SocketAddress.Span, out receivedSocketAddressLength, out BytesTransferred, out ReceivedFlags, out ErrorCode);
			if (num && ErrorCode == SocketError.Success)
			{
				SocketAddress = SocketAddress.Slice(0, receivedSocketAddressLength);
			}
			return num;
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Action<int, Memory<byte>, SocketFlags, SocketError> callback = base.Callback;
			int bytesTransferred = BytesTransferred;
			Memory<byte> socketAddress = SocketAddress;
			SocketFlags receivedFlags = ReceivedFlags;
			SocketError errorCode = ErrorCode;
			if (allowPooling)
			{
				AssociatedContext.ReturnOperation(this);
			}
			callback(bytesTransferred, socketAddress, receivedFlags, errorCode);
		}
	}

	private sealed class BufferPtrReceiveOperation : ReceiveOperation
	{
		public unsafe byte* BufferPtr;

		public int Length;

		public BufferPtrReceiveOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected unsafe override bool DoTryComplete(SocketAsyncContext context)
		{
			int receivedSocketAddressLength;
			bool num = SocketPal.TryCompleteReceiveFrom(context._socket, new Span<byte>(BufferPtr, Length), null, Flags, SocketAddress.Span, out receivedSocketAddressLength, out BytesTransferred, out ReceivedFlags, out ErrorCode);
			if (num && ErrorCode == SocketError.Success)
			{
				SocketAddress = SocketAddress.Slice(0, receivedSocketAddressLength);
			}
			return num;
		}
	}

	private sealed class AcceptOperation : ReadOperation
	{
		public nint AcceptedFileDescriptor;

		public Action<nint, Memory<byte>, SocketError> Callback { get; set; }

		public AcceptOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected override bool DoTryComplete(SocketAsyncContext context)
		{
			int socketAddressLen;
			bool result = SocketPal.TryCompleteAccept(context._socket, SocketAddress, out socketAddressLen, out AcceptedFileDescriptor, out ErrorCode);
			if (ErrorCode == SocketError.Success)
			{
				SocketAddress = SocketAddress.Slice(0, socketAddressLen);
			}
			return result;
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Action<nint, Memory<byte>, SocketError> callback = Callback;
			nint acceptedFileDescriptor = AcceptedFileDescriptor;
			Memory<byte> socketAddress = SocketAddress;
			SocketError errorCode = ErrorCode;
			if (allowPooling)
			{
				AssociatedContext.ReturnOperation(this);
			}
			callback(acceptedFileDescriptor, socketAddress, errorCode);
		}
	}

	private sealed class ConnectOperation : BufferMemorySendOperation
	{
		public ConnectOperation(SocketAsyncContext context)
			: base(context)
		{
		}

		protected override bool DoTryComplete(SocketAsyncContext context)
		{
			bool num = SocketPal.TryCompleteConnect(context._socket, out ErrorCode);
			context._socket.RegisterConnectResult(ErrorCode);
			if (num && ErrorCode == SocketError.Success && Buffer.Length > 0)
			{
				SocketError socketError = context.SendToAsync(Buffer, 0, Buffer.Length, SocketFlags.None, Memory<byte>.Empty, ref BytesTransferred, base.Callback);
				if (socketError != SocketError.Success && socketError != SocketError.IOPending)
				{
					context._socket.RegisterConnectResult(ErrorCode);
				}
			}
			return num;
		}

		public override void InvokeCallback(bool allowPooling)
		{
			Action<int, Memory<byte>, SocketFlags, SocketError> callback = base.Callback;
			int bytesTransferred = BytesTransferred;
			Memory<byte> socketAddress = SocketAddress;
			SocketError errorCode = ErrorCode;
			Memory<byte> buffer = Buffer;
			if (buffer.Length == 0)
			{
				callback(bytesTransferred, socketAddress, SocketFlags.None, errorCode);
			}
		}
	}

	private readonly struct LockToken : IDisposable
	{
		private readonly object _lockObject;

		public LockToken(object lockObject)
		{
			_lockObject = lockObject;
			Monitor.Enter(_lockObject);
		}

		public void Dispose()
		{
			Monitor.Exit(_lockObject);
		}
	}

	public enum OperationResult
	{
		Pending,
		Completed,
		Cancelled
	}

	private struct OperationQueue<TOperation> where TOperation : AsyncOperation
	{
		private enum QueueState
		{
			Ready,
			Waiting,
			Processing,
			Stopped
		}

		private QueueState _state;

		private bool _isNextOperationSynchronous;

		private int _sequenceNumber;

		private AsyncOperation _tail;

		private object _queueLock;

		public bool IsNextOperationSynchronous_Speculative => _isNextOperationSynchronous;

		private LockToken Lock()
		{
			return new LockToken(_queueLock);
		}

		public void Init()
		{
			_queueLock = new object();
			_state = QueueState.Ready;
			_sequenceNumber = 0;
		}

		public bool IsReady(SocketAsyncContext context, out int observedSequenceNumber)
		{
			QueueState queueState = (QueueState)Volatile.Read(in Unsafe.As<QueueState, int>(ref _state));
			observedSequenceNumber = Volatile.Read(in _sequenceNumber);
			int num;
			if (queueState != QueueState.Ready)
			{
				num = ((queueState == QueueState.Stopped) ? 1 : 0);
				if (num == 0)
				{
					observedSequenceNumber--;
				}
			}
			else
			{
				num = 1;
			}
			return (byte)num != 0;
		}

		public bool StartAsyncOperation(SocketAsyncContext context, TOperation operation, int observedSequenceNumber, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!context.IsRegistered && !context.TryRegister(out var error))
			{
				HandleFailedRegistration(context, operation, error);
				return false;
			}
			do
			{
				bool flag = false;
				using (Lock())
				{
					switch (_state)
					{
					case QueueState.Ready:
						if (observedSequenceNumber != _sequenceNumber)
						{
							observedSequenceNumber = _sequenceNumber;
							break;
						}
						_state = QueueState.Waiting;
						goto case QueueState.Waiting;
					case QueueState.Waiting:
					case QueueState.Processing:
						if (_tail == null)
						{
							_isNextOperationSynchronous = operation.Event != null;
						}
						else
						{
							operation.Next = _tail.Next;
							_tail.Next = operation;
						}
						_tail = operation;
						if (cancellationToken.CanBeCanceled)
						{
							operation.CancellationRegistration = cancellationToken.UnsafeRegister(delegate(object s)
							{
								((TOperation)s).TryCancel();
							}, operation);
						}
						return true;
					case QueueState.Stopped:
						flag = true;
						break;
					default:
						Environment.FailFast("unexpected queue state");
						break;
					}
				}
				if (flag)
				{
					operation.DoAbort();
					return false;
				}
			}
			while (operation.TryComplete(context) == OperationResult.Pending);
			return false;
			static void HandleFailedRegistration(SocketAsyncContext context2, TOperation val, global::Interop.Error error2)
			{
				if (error2 == global::Interop.Error.EPIPE && val.TryComplete(context2) != OperationResult.Pending)
				{
					return;
				}
				if (error2 == global::Interop.Error.ENOMEM || error2 == global::Interop.Error.ENOSPC)
				{
					throw new OutOfMemoryException();
				}
				throw new InternalException(error2);
			}
		}

		public AsyncOperation ProcessSyncEventOrGetAsyncEvent(SocketAsyncContext context, bool skipAsyncEvents = false)
		{
			AsyncOperation next;
			using (Lock())
			{
				switch (_state)
				{
				case QueueState.Ready:
					_sequenceNumber++;
					return null;
				case QueueState.Waiting:
					next = _tail.Next;
					if (skipAsyncEvents && !_isNextOperationSynchronous)
					{
						return next;
					}
					_state = QueueState.Processing;
					break;
				case QueueState.Processing:
					_sequenceNumber++;
					return null;
				case QueueState.Stopped:
					return null;
				default:
					Environment.FailFast("unexpected queue state");
					return null;
				}
			}
			ManualResetEventSlim manualResetEventSlim = next.Event;
			if (manualResetEventSlim != null)
			{
				manualResetEventSlim.Set();
				return null;
			}
			return next;
		}

		internal void ProcessAsyncOperation(TOperation op)
		{
			if (ProcessQueuedOperation(op) == OperationResult.Completed)
			{
				op.CancellationRegistration.Dispose();
				op.InvokeCallback(allowPooling: true);
			}
		}

		public OperationResult ProcessQueuedOperation(TOperation op)
		{
			SocketAsyncContext associatedContext = op.AssociatedContext;
			int sequenceNumber;
			using (Lock())
			{
				if (_state == QueueState.Stopped)
				{
					return OperationResult.Cancelled;
				}
				sequenceNumber = _sequenceNumber;
			}
			OperationResult operationResult;
			while (true)
			{
				operationResult = op.TryComplete(associatedContext);
				if (operationResult != OperationResult.Pending)
				{
					break;
				}
				using (Lock())
				{
					if (_state == QueueState.Stopped)
					{
						return OperationResult.Cancelled;
					}
					if (sequenceNumber != _sequenceNumber)
					{
						sequenceNumber = _sequenceNumber;
						continue;
					}
					_state = QueueState.Waiting;
					return OperationResult.Pending;
				}
			}
			AsyncOperation asyncOperation = null;
			using (Lock())
			{
				if (_state != QueueState.Stopped)
				{
					if (op == _tail)
					{
						_tail = null;
						_isNextOperationSynchronous = false;
						_state = QueueState.Ready;
						_sequenceNumber++;
					}
					else
					{
						asyncOperation = (_tail.Next = op.Next);
						_isNextOperationSynchronous = asyncOperation.Event != null;
					}
				}
			}
			asyncOperation?.Dispatch();
			return operationResult;
		}

		public void CancelAndContinueProcessing(TOperation op)
		{
			AsyncOperation asyncOperation = null;
			using (Lock())
			{
				if (_state != QueueState.Stopped)
				{
					if (_tail.Next == op)
					{
						if (op == _tail)
						{
							_tail = null;
							_isNextOperationSynchronous = false;
						}
						else
						{
							_tail.Next = op.Next;
							_isNextOperationSynchronous = op.Next.Event != null;
						}
						if (_state == QueueState.Processing)
						{
							if (_tail == null)
							{
								_state = QueueState.Ready;
								_sequenceNumber++;
							}
							else
							{
								asyncOperation = _tail.Next;
							}
						}
						else if (_state == QueueState.Waiting && _tail == null)
						{
							_state = QueueState.Ready;
							_sequenceNumber++;
						}
					}
					else
					{
						AsyncOperation next = _tail.Next;
						while (next.Next != op)
						{
							next = next.Next;
						}
						if (next.Next == _tail)
						{
							_tail = next;
						}
						next.Next = next.Next.Next;
					}
				}
			}
			asyncOperation?.Dispatch();
		}

		public bool StopAndAbort(SocketAsyncContext context)
		{
			bool flag = false;
			using (Lock())
			{
				_state = QueueState.Stopped;
				if (_tail != null)
				{
					AsyncOperation asyncOperation = _tail;
					do
					{
						flag |= asyncOperation.TryCancel();
						asyncOperation = asyncOperation.Next;
					}
					while (asyncOperation != _tail);
				}
				_tail = null;
				_isNextOperationSynchronous = false;
				return flag;
			}
		}
	}

	private AcceptOperation _cachedAcceptOperation;

	private BufferMemoryReceiveOperation _cachedBufferMemoryReceiveOperation;

	private BufferListReceiveOperation _cachedBufferListReceiveOperation;

	private BufferMemorySendOperation _cachedBufferMemorySendOperation;

	private BufferListSendOperation _cachedBufferListSendOperation;

	internal readonly SafeSocketHandle _socket;

	private OperationQueue<ReadOperation> _receiveQueue;

	private OperationQueue<WriteOperation> _sendQueue;

	private SocketAsyncEngine _asyncEngine;

	private bool _isHandleNonBlocking = false;

	internal int GlobalContextIndex = -1;

	private readonly object _registerLock = new object();

	private bool IsRegistered => _asyncEngine != null;

	public bool PreferInlineCompletions => _socket.PreferInlineCompletions;

	public bool IsHandleNonBlocking => _isHandleNonBlocking;

	private void ReturnOperation(AcceptOperation operation)
	{
		operation.Reset();
		operation.Callback = null;
		operation.SocketAddress = default(Memory<byte>);
		Volatile.Write(ref _cachedAcceptOperation, operation);
	}

	private void ReturnOperation(BufferMemoryReceiveOperation operation)
	{
		operation.Reset();
		operation.Buffer = default(Memory<byte>);
		operation.Callback = null;
		operation.SocketAddress = default(Memory<byte>);
		Volatile.Write(ref _cachedBufferMemoryReceiveOperation, operation);
	}

	private void ReturnOperation(BufferListReceiveOperation operation)
	{
		operation.Reset();
		operation.Buffers = null;
		operation.Callback = null;
		operation.SocketAddress = default(Memory<byte>);
		Volatile.Write(ref _cachedBufferListReceiveOperation, operation);
	}

	private void ReturnOperation(BufferMemorySendOperation operation)
	{
		operation.Reset();
		operation.Buffer = default(Memory<byte>);
		operation.Callback = null;
		operation.SocketAddress = default(Memory<byte>);
		Volatile.Write(ref _cachedBufferMemorySendOperation, operation);
	}

	private void ReturnOperation(BufferListSendOperation operation)
	{
		operation.Reset();
		operation.Buffers = null;
		operation.Callback = null;
		operation.SocketAddress = default(Memory<byte>);
		Volatile.Write(ref _cachedBufferListSendOperation, operation);
	}

	private AcceptOperation RentAcceptOperation()
	{
		return Interlocked.Exchange(ref _cachedAcceptOperation, null) ?? new AcceptOperation(this);
	}

	private BufferMemoryReceiveOperation RentBufferMemoryReceiveOperation()
	{
		return Interlocked.Exchange(ref _cachedBufferMemoryReceiveOperation, null) ?? new BufferMemoryReceiveOperation(this);
	}

	private BufferListReceiveOperation RentBufferListReceiveOperation()
	{
		return Interlocked.Exchange(ref _cachedBufferListReceiveOperation, null) ?? new BufferListReceiveOperation(this);
	}

	private BufferMemorySendOperation RentBufferMemorySendOperation()
	{
		return Interlocked.Exchange(ref _cachedBufferMemorySendOperation, null) ?? new BufferMemorySendOperation(this);
	}

	private BufferListSendOperation RentBufferListSendOperation()
	{
		return Interlocked.Exchange(ref _cachedBufferListSendOperation, null) ?? new BufferListSendOperation(this);
	}

	public SocketAsyncContext(SafeSocketHandle socket)
	{
		_socket = socket;
		_receiveQueue.Init();
		_sendQueue.Init();
	}

	private bool TryRegister(out global::Interop.Error error)
	{
		lock (_registerLock)
		{
			if (_asyncEngine == null)
			{
				bool success = false;
				try
				{
					_socket.DangerousAddRef(ref success);
					if (SocketAsyncEngine.TryRegisterSocket(_socket.DangerousGetHandle(), this, out var engine, out error))
					{
						Volatile.Write(ref _asyncEngine, engine);
						return true;
					}
					return false;
				}
				finally
				{
					if (success)
					{
						_socket.DangerousRelease();
					}
				}
			}
			error = global::Interop.Error.SUCCESS;
			return true;
		}
	}

	public bool StopAndAbort()
	{
		int result = (int)(0u | (_sendQueue.StopAndAbort(this) ? 1u : 0u)) | (_receiveQueue.StopAndAbort(this) ? 1 : 0);
		if (IsRegistered)
		{
			SocketAsyncEngine.UnregisterSocket(this);
		}
		return (byte)result != 0;
	}

	public void SetHandleNonBlocking()
	{
		if (false)
		{
		}
		if (!_isHandleNonBlocking)
		{
			if (global::Interop.Sys.Fcntl.SetIsNonBlocking(_socket, 1) != 0)
			{
				throw new SocketException((int)SocketPal.GetSocketErrorForErrorCode(global::Interop.Sys.GetLastError()));
			}
			_isHandleNonBlocking = true;
		}
	}

	private void PerformSyncOperation<TOperation>(ref OperationQueue<TOperation> queue, TOperation operation, int timeout, int observedSequenceNumber) where TOperation : AsyncOperation
	{
		if (1 == 0)
		{
		}
		using ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim(initialState: false, 0);
		operation.Event = manualResetEventSlim;
		if (!queue.StartAsyncOperation(this, operation, observedSequenceNumber))
		{
			return;
		}
		bool flag = false;
		while (true)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (!manualResetEventSlim.Wait(timeout))
			{
				flag = true;
				break;
			}
			manualResetEventSlim.Reset();
			OperationResult operationResult = queue.ProcessQueuedOperation(operation);
			if (operationResult == OperationResult.Completed || operationResult == OperationResult.Cancelled)
			{
				break;
			}
			if (timeout > 0)
			{
				timeout -= (DateTime.UtcNow - utcNow).Milliseconds;
				if (timeout <= 0)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			queue.CancelAndContinueProcessing(operation);
			operation.ErrorCode = SocketError.TimedOut;
		}
	}

	private bool ShouldRetrySyncOperation(out SocketError errorCode)
	{
		if (_isHandleNonBlocking)
		{
			errorCode = SocketError.Success;
			return true;
		}
		errorCode = SocketError.TimedOut;
		return false;
	}

	private void ProcessAsyncReadOperation(ReadOperation op)
	{
		_receiveQueue.ProcessAsyncOperation(op);
	}

	private void ProcessAsyncWriteOperation(WriteOperation op)
	{
		_sendQueue.ProcessAsyncOperation(op);
	}

	public SocketError Accept(Memory<byte> socketAddress, out int socketAddressLen, out nint acceptedFd)
	{
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteAccept(_socket, socketAddress, out socketAddressLen, out acceptedFd, out var errorCode))
		{
			return errorCode;
		}
		AcceptOperation acceptOperation = new AcceptOperation(this)
		{
			SocketAddress = socketAddress
		};
		PerformSyncOperation(ref _receiveQueue, acceptOperation, -1, observedSequenceNumber);
		socketAddressLen = acceptOperation.SocketAddress.Length;
		acceptedFd = acceptOperation.AcceptedFileDescriptor;
		return acceptOperation.ErrorCode;
	}

	public SocketError AcceptAsync(Memory<byte> socketAddress, out int socketAddressLen, out nint acceptedFd, Action<nint, Memory<byte>, SocketError> callback, CancellationToken cancellationToken)
	{
		SetHandleNonBlocking();
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteAccept(_socket, socketAddress, out socketAddressLen, out acceptedFd, out var errorCode))
		{
			return errorCode;
		}
		AcceptOperation acceptOperation = RentAcceptOperation();
		acceptOperation.Callback = callback;
		acceptOperation.SocketAddress = socketAddress;
		if (!_receiveQueue.StartAsyncOperation(this, acceptOperation, observedSequenceNumber, cancellationToken))
		{
			socketAddressLen = acceptOperation.SocketAddress.Length;
			acceptedFd = acceptOperation.AcceptedFileDescriptor;
			errorCode = acceptOperation.ErrorCode;
			ReturnOperation(acceptOperation);
			return errorCode;
		}
		acceptedFd = -1;
		socketAddressLen = 0;
		return SocketError.IOPending;
	}

	public SocketError Connect(Memory<byte> socketAddress)
	{
		if (1 == 0)
		{
		}
		_sendQueue.IsReady(this, out var observedSequenceNumber);
		if (SocketPal.TryStartConnect(_socket, socketAddress, out var errorCode) || !ShouldRetrySyncOperation(out errorCode))
		{
			_socket.RegisterConnectResult(errorCode);
			return errorCode;
		}
		ConnectOperation connectOperation = new ConnectOperation(this)
		{
			SocketAddress = socketAddress
		};
		PerformSyncOperation(ref _sendQueue, connectOperation, -1, observedSequenceNumber);
		return connectOperation.ErrorCode;
	}

	public SocketError ConnectAsync(Memory<byte> socketAddress, Action<int, Memory<byte>, SocketFlags, SocketError> callback, Memory<byte> buffer, out int sentBytes, CancellationToken cancellationToken)
	{
		SetHandleNonBlocking();
		_sendQueue.IsReady(this, out var observedSequenceNumber);
		if (SocketPal.TryStartConnect(_socket, socketAddress, out var errorCode, buffer.Span, tfo: false, out sentBytes))
		{
			_socket.RegisterConnectResult(errorCode);
			int num = buffer.Length - sentBytes;
			if (errorCode == SocketError.Success && num > 0)
			{
				return SendToAsync(buffer.Slice(sentBytes), 0, num, SocketFlags.None, Memory<byte>.Empty, ref sentBytes, callback);
			}
			return errorCode;
		}
		ConnectOperation connectOperation = new ConnectOperation(this)
		{
			Callback = callback,
			SocketAddress = socketAddress,
			Buffer = buffer.Slice(sentBytes),
			BytesTransferred = sentBytes
		};
		if (!_sendQueue.StartAsyncOperation(this, connectOperation, observedSequenceNumber, cancellationToken))
		{
			if (connectOperation.ErrorCode == SocketError.Success)
			{
				sentBytes += connectOperation.BytesTransferred;
			}
			return connectOperation.ErrorCode;
		}
		return SocketError.IOPending;
	}

	public SocketError Receive(Memory<byte> buffer, SocketFlags flags, int timeout, out int bytesReceived)
	{
		int socketAddressLen;
		return ReceiveFrom(buffer, ref flags, Memory<byte>.Empty, out socketAddressLen, timeout, out bytesReceived);
	}

	public SocketError Receive(Span<byte> buffer, SocketFlags flags, int timeout, out int bytesReceived)
	{
		int socketAddressLen;
		return ReceiveFrom(buffer, ref flags, Memory<byte>.Empty, out socketAddressLen, timeout, out bytesReceived);
	}

	public SocketError ReceiveAsync(Memory<byte> buffer, SocketFlags flags, out int bytesReceived, out SocketFlags receivedFlags, Action<int, Memory<byte>, SocketFlags, SocketError> callback, CancellationToken cancellationToken)
	{
		int socketAddressLen;
		return ReceiveFromAsync(buffer, flags, Memory<byte>.Empty, out socketAddressLen, out bytesReceived, out receivedFlags, callback, cancellationToken);
	}

	public SocketError ReceiveFrom(Memory<byte> buffer, ref SocketFlags flags, Memory<byte> socketAddress, out int socketAddressLen, int timeout, out int bytesReceived)
	{
		if (1 == 0)
		{
		}
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && (SocketPal.TryCompleteReceiveFrom(_socket, buffer.Span, flags, socketAddress.Span, out socketAddressLen, out bytesReceived, out var receivedFlags, out var errorCode) || !ShouldRetrySyncOperation(out errorCode)))
		{
			flags = receivedFlags;
			return errorCode;
		}
		BufferMemoryReceiveOperation bufferMemoryReceiveOperation = new BufferMemoryReceiveOperation(this)
		{
			Buffer = buffer,
			Flags = flags,
			SetReceivedFlags = true,
			SocketAddress = socketAddress
		};
		PerformSyncOperation(ref _receiveQueue, bufferMemoryReceiveOperation, timeout, observedSequenceNumber);
		flags = bufferMemoryReceiveOperation.ReceivedFlags;
		bytesReceived = bufferMemoryReceiveOperation.BytesTransferred;
		socketAddressLen = bufferMemoryReceiveOperation.SocketAddress.Length;
		return bufferMemoryReceiveOperation.ErrorCode;
	}

	public unsafe SocketError ReceiveFrom(Span<byte> buffer, ref SocketFlags flags, Memory<byte> socketAddress, out int socketAddressLen, int timeout, out int bytesReceived)
	{
		if (1 == 0)
		{
		}
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && (SocketPal.TryCompleteReceiveFrom(_socket, buffer, flags, socketAddress.Span, out socketAddressLen, out bytesReceived, out var receivedFlags, out var errorCode) || !ShouldRetrySyncOperation(out errorCode)))
		{
			flags = receivedFlags;
			return errorCode;
		}
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			BufferPtrReceiveOperation bufferPtrReceiveOperation = new BufferPtrReceiveOperation(this)
			{
				BufferPtr = reference,
				Length = buffer.Length,
				Flags = flags,
				SocketAddress = socketAddress
			};
			PerformSyncOperation(ref _receiveQueue, bufferPtrReceiveOperation, timeout, observedSequenceNumber);
			flags = bufferPtrReceiveOperation.ReceivedFlags;
			bytesReceived = bufferPtrReceiveOperation.BytesTransferred;
			socketAddressLen = bufferPtrReceiveOperation.SocketAddress.Length;
			return bufferPtrReceiveOperation.ErrorCode;
		}
	}

	public SocketError ReceiveAsync(Memory<byte> buffer, SocketFlags flags, out int bytesReceived, Action<int, Memory<byte>, SocketFlags, SocketError> callback, CancellationToken cancellationToken = default(CancellationToken))
	{
		SetHandleNonBlocking();
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteReceive(_socket, buffer.Span, flags, out bytesReceived, out var errorCode))
		{
			return errorCode;
		}
		BufferMemoryReceiveOperation bufferMemoryReceiveOperation = RentBufferMemoryReceiveOperation();
		bufferMemoryReceiveOperation.SetReceivedFlags = false;
		bufferMemoryReceiveOperation.Callback = callback;
		bufferMemoryReceiveOperation.Buffer = buffer;
		bufferMemoryReceiveOperation.Flags = flags;
		bufferMemoryReceiveOperation.SocketAddress = default(Memory<byte>);
		if (!_receiveQueue.StartAsyncOperation(this, bufferMemoryReceiveOperation, observedSequenceNumber, cancellationToken))
		{
			bytesReceived = bufferMemoryReceiveOperation.BytesTransferred;
			errorCode = bufferMemoryReceiveOperation.ErrorCode;
			ReturnOperation(bufferMemoryReceiveOperation);
			return errorCode;
		}
		bytesReceived = 0;
		return SocketError.IOPending;
	}

	public SocketError ReceiveFromAsync(Memory<byte> buffer, SocketFlags flags, Memory<byte> socketAddress, out int socketAddressLen, out int bytesReceived, out SocketFlags receivedFlags, Action<int, Memory<byte>, SocketFlags, SocketError> callback, CancellationToken cancellationToken = default(CancellationToken))
	{
		SetHandleNonBlocking();
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteReceiveFrom(_socket, buffer.Span, flags, socketAddress.Span, out socketAddressLen, out bytesReceived, out receivedFlags, out var errorCode))
		{
			return errorCode;
		}
		BufferMemoryReceiveOperation bufferMemoryReceiveOperation = RentBufferMemoryReceiveOperation();
		bufferMemoryReceiveOperation.SetReceivedFlags = true;
		bufferMemoryReceiveOperation.Callback = callback;
		bufferMemoryReceiveOperation.Buffer = buffer;
		bufferMemoryReceiveOperation.Flags = flags;
		bufferMemoryReceiveOperation.SocketAddress = socketAddress;
		if (!_receiveQueue.StartAsyncOperation(this, bufferMemoryReceiveOperation, observedSequenceNumber, cancellationToken))
		{
			receivedFlags = bufferMemoryReceiveOperation.ReceivedFlags;
			bytesReceived = bufferMemoryReceiveOperation.BytesTransferred;
			errorCode = bufferMemoryReceiveOperation.ErrorCode;
			socketAddressLen = bufferMemoryReceiveOperation.SocketAddress.Length;
			ReturnOperation(bufferMemoryReceiveOperation);
			return errorCode;
		}
		bytesReceived = 0;
		socketAddressLen = 0;
		receivedFlags = SocketFlags.None;
		return SocketError.IOPending;
	}

	public SocketError ReceiveAsync(IList<ArraySegment<byte>> buffers, SocketFlags flags, out int bytesReceived, out SocketFlags receivedFlags, Action<int, Memory<byte>, SocketFlags, SocketError> callback)
	{
		int socketAddressLen;
		return ReceiveFromAsync(buffers, flags, Memory<byte>.Empty, out socketAddressLen, out bytesReceived, out receivedFlags, callback);
	}

	public SocketError ReceiveFromAsync(IList<ArraySegment<byte>> buffers, SocketFlags flags, Memory<byte> socketAddress, out int socketAddressLen, out int bytesReceived, out SocketFlags receivedFlags, Action<int, Memory<byte>, SocketFlags, SocketError> callback)
	{
		SetHandleNonBlocking();
		if (_receiveQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteReceiveFrom(_socket, buffers, flags, socketAddress.Span, out socketAddressLen, out bytesReceived, out receivedFlags, out var errorCode))
		{
			return errorCode;
		}
		BufferListReceiveOperation bufferListReceiveOperation = RentBufferListReceiveOperation();
		bufferListReceiveOperation.Callback = callback;
		bufferListReceiveOperation.Buffers = buffers;
		bufferListReceiveOperation.Flags = flags;
		bufferListReceiveOperation.SocketAddress = socketAddress;
		if (!_receiveQueue.StartAsyncOperation(this, bufferListReceiveOperation, observedSequenceNumber))
		{
			socketAddressLen = bufferListReceiveOperation.SocketAddress.Length;
			receivedFlags = bufferListReceiveOperation.ReceivedFlags;
			bytesReceived = bufferListReceiveOperation.BytesTransferred;
			errorCode = bufferListReceiveOperation.ErrorCode;
			ReturnOperation(bufferListReceiveOperation);
			return errorCode;
		}
		receivedFlags = SocketFlags.None;
		socketAddressLen = 0;
		bytesReceived = 0;
		return SocketError.IOPending;
	}

	public SocketError Send(ReadOnlySpan<byte> buffer, SocketFlags flags, int timeout, out int bytesSent)
	{
		return SendTo(buffer, flags, Memory<byte>.Empty, timeout, out bytesSent);
	}

	public SocketError Send(byte[] buffer, int offset, int count, SocketFlags flags, int timeout, out int bytesSent)
	{
		return SendTo(buffer, offset, count, flags, Memory<byte>.Empty, timeout, out bytesSent);
	}

	public SocketError SendAsync(Memory<byte> buffer, int offset, int count, SocketFlags flags, out int bytesSent, Action<int, Memory<byte>, SocketFlags, SocketError> callback, CancellationToken cancellationToken)
	{
		bytesSent = 0;
		return SendToAsync(buffer, offset, count, flags, Memory<byte>.Empty, ref bytesSent, callback, cancellationToken);
	}

	public SocketError SendTo(byte[] buffer, int offset, int count, SocketFlags flags, Memory<byte> socketAddress, int timeout, out int bytesSent)
	{
		if (1 == 0)
		{
		}
		bytesSent = 0;
		if (_sendQueue.IsReady(this, out var observedSequenceNumber) && (SocketPal.TryCompleteSendTo(_socket, buffer, ref offset, ref count, flags, socketAddress.Span, ref bytesSent, out var errorCode) || !ShouldRetrySyncOperation(out errorCode)))
		{
			return errorCode;
		}
		BufferMemorySendOperation bufferMemorySendOperation = new BufferMemorySendOperation(this)
		{
			Buffer = buffer,
			Offset = offset,
			Count = count,
			Flags = flags,
			SocketAddress = socketAddress,
			BytesTransferred = bytesSent
		};
		PerformSyncOperation(ref _sendQueue, bufferMemorySendOperation, timeout, observedSequenceNumber);
		bytesSent = bufferMemorySendOperation.BytesTransferred;
		return bufferMemorySendOperation.ErrorCode;
	}

	public unsafe SocketError SendTo(ReadOnlySpan<byte> buffer, SocketFlags flags, Memory<byte> socketAddress, int timeout, out int bytesSent)
	{
		if (1 == 0)
		{
		}
		bytesSent = 0;
		int bufferIndex = 0;
		int offset = 0;
		int count = buffer.Length;
		if (_sendQueue.IsReady(this, out var observedSequenceNumber) && (SocketPal.TryCompleteSendTo(_socket, buffer, null, ref bufferIndex, ref offset, ref count, flags, socketAddress.Span, ref bytesSent, out var errorCode) || !ShouldRetrySyncOperation(out errorCode)))
		{
			return errorCode;
		}
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			BufferPtrSendOperation bufferPtrSendOperation = new BufferPtrSendOperation(this)
			{
				BufferPtr = reference,
				Offset = offset,
				Count = count,
				Flags = flags,
				SocketAddress = socketAddress,
				BytesTransferred = bytesSent
			};
			PerformSyncOperation(ref _sendQueue, bufferPtrSendOperation, timeout, observedSequenceNumber);
			bytesSent = bufferPtrSendOperation.BytesTransferred;
			return bufferPtrSendOperation.ErrorCode;
		}
	}

	public SocketError SendToAsync(Memory<byte> buffer, int offset, int count, SocketFlags flags, Memory<byte> socketAddress, ref int bytesSent, Action<int, Memory<byte>, SocketFlags, SocketError> callback, CancellationToken cancellationToken = default(CancellationToken))
	{
		SetHandleNonBlocking();
		if (_sendQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteSendTo(_socket, buffer.Span, ref offset, ref count, flags, socketAddress.Span, ref bytesSent, out var errorCode))
		{
			return errorCode;
		}
		BufferMemorySendOperation bufferMemorySendOperation = RentBufferMemorySendOperation();
		bufferMemorySendOperation.Callback = callback;
		bufferMemorySendOperation.Buffer = buffer;
		bufferMemorySendOperation.Offset = offset;
		bufferMemorySendOperation.Count = count;
		bufferMemorySendOperation.Flags = flags;
		bufferMemorySendOperation.SocketAddress = socketAddress;
		bufferMemorySendOperation.BytesTransferred = bytesSent;
		if (!_sendQueue.StartAsyncOperation(this, bufferMemorySendOperation, observedSequenceNumber, cancellationToken))
		{
			bytesSent = bufferMemorySendOperation.BytesTransferred;
			errorCode = bufferMemorySendOperation.ErrorCode;
			ReturnOperation(bufferMemorySendOperation);
			return errorCode;
		}
		return SocketError.IOPending;
	}

	public SocketError SendAsync(IList<ArraySegment<byte>> buffers, SocketFlags flags, out int bytesSent, Action<int, Memory<byte>, SocketFlags, SocketError> callback)
	{
		return SendToAsync(buffers, flags, Memory<byte>.Empty, out bytesSent, callback);
	}

	public SocketError SendToAsync(IList<ArraySegment<byte>> buffers, SocketFlags flags, Memory<byte> socketAddress, out int bytesSent, Action<int, Memory<byte>, SocketFlags, SocketError> callback)
	{
		SetHandleNonBlocking();
		bytesSent = 0;
		int bufferIndex = 0;
		int offset = 0;
		if (_sendQueue.IsReady(this, out var observedSequenceNumber) && SocketPal.TryCompleteSendTo(_socket, buffers, ref bufferIndex, ref offset, flags, socketAddress.Span, ref bytesSent, out var errorCode))
		{
			return errorCode;
		}
		BufferListSendOperation bufferListSendOperation = RentBufferListSendOperation();
		bufferListSendOperation.Callback = callback;
		bufferListSendOperation.Buffers = buffers;
		bufferListSendOperation.BufferIndex = bufferIndex;
		bufferListSendOperation.Offset = offset;
		bufferListSendOperation.Flags = flags;
		bufferListSendOperation.SocketAddress = socketAddress;
		bufferListSendOperation.BytesTransferred = bytesSent;
		if (!_sendQueue.StartAsyncOperation(this, bufferListSendOperation, observedSequenceNumber))
		{
			bytesSent = bufferListSendOperation.BytesTransferred;
			errorCode = bufferListSendOperation.ErrorCode;
			ReturnOperation(bufferListSendOperation);
			return errorCode;
		}
		return SocketError.IOPending;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public global::Interop.Sys.SocketEvents HandleSyncEventsSpeculatively(global::Interop.Sys.SocketEvents events)
	{
		if ((events & global::Interop.Sys.SocketEvents.Error) != global::Interop.Sys.SocketEvents.None)
		{
			events ^= global::Interop.Sys.SocketEvents.Error;
			events |= global::Interop.Sys.SocketEvents.Read | global::Interop.Sys.SocketEvents.Write;
		}
		if ((events & global::Interop.Sys.SocketEvents.Read) != global::Interop.Sys.SocketEvents.None && _receiveQueue.IsNextOperationSynchronous_Speculative && _receiveQueue.ProcessSyncEventOrGetAsyncEvent(this, skipAsyncEvents: true) == null)
		{
			events ^= global::Interop.Sys.SocketEvents.Read;
		}
		if ((events & global::Interop.Sys.SocketEvents.Write) != global::Interop.Sys.SocketEvents.None && _sendQueue.IsNextOperationSynchronous_Speculative && _sendQueue.ProcessSyncEventOrGetAsyncEvent(this, skipAsyncEvents: true) == null)
		{
			events ^= global::Interop.Sys.SocketEvents.Write;
		}
		return events;
	}

	public void HandleEventsInline(global::Interop.Sys.SocketEvents events)
	{
		if ((events & global::Interop.Sys.SocketEvents.Error) != global::Interop.Sys.SocketEvents.None)
		{
			events ^= global::Interop.Sys.SocketEvents.Error;
			events |= global::Interop.Sys.SocketEvents.Read | global::Interop.Sys.SocketEvents.Write;
		}
		if ((events & global::Interop.Sys.SocketEvents.Read) != global::Interop.Sys.SocketEvents.None)
		{
			_receiveQueue.ProcessSyncEventOrGetAsyncEvent(this)?.Process();
		}
		if ((events & global::Interop.Sys.SocketEvents.Write) != global::Interop.Sys.SocketEvents.None)
		{
			_sendQueue.ProcessSyncEventOrGetAsyncEvent(this)?.Process();
		}
	}

	public void HandleEvents(global::Interop.Sys.SocketEvents events)
	{
		AsyncOperation asyncOperation = (((events & global::Interop.Sys.SocketEvents.Read) != global::Interop.Sys.SocketEvents.None) ? _receiveQueue.ProcessSyncEventOrGetAsyncEvent(this) : null);
		AsyncOperation asyncOperation2 = (((events & global::Interop.Sys.SocketEvents.Write) != global::Interop.Sys.SocketEvents.None) ? _sendQueue.ProcessSyncEventOrGetAsyncEvent(this) : null);
		if (asyncOperation2 == null)
		{
			asyncOperation?.Process();
			return;
		}
		asyncOperation?.Schedule();
		asyncOperation2.Process();
	}
}
