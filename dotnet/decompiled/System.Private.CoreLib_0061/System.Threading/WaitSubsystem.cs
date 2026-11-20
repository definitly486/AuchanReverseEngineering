using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

internal static class WaitSubsystem
{
	private static class HandleManager
	{
		public static nint NewHandle(WaitableObject waitableObject)
		{
			return GCHandle.ToIntPtr(GCHandle.Alloc(waitableObject, GCHandleType.Normal));
		}

		public static WaitableObject FromHandle(nint handle)
		{
			if (handle == IntPtr.Zero || handle == new IntPtr(-1))
			{
				WaitHandle.ThrowInvalidHandleException();
			}
			return (WaitableObject)GCHandle.FromIntPtr(handle).Target;
		}

		public static void DeleteHandle(nint handle)
		{
			if (handle != IntPtr.Zero && handle != new IntPtr(-1))
			{
				FromHandle(handle).OnDeleteHandle();
				GCHandle.FromIntPtr(handle).Free();
			}
		}
	}

	public sealed class ThreadWaitInfo
	{
		public sealed class WaitedListNode
		{
			private readonly ThreadWaitInfo _waitInfo;

			private readonly int _waitedObjectIndex;

			private WaitedListNode _previous;

			private WaitedListNode _next;

			public ThreadWaitInfo WaitInfo => _waitInfo;

			public int WaitedObjectIndex => _waitedObjectIndex;

			public WaitedListNode NextThread
			{
				get
				{
					WaitedListNode next = _next;
					while (next != null && next._waitInfo == _waitInfo)
					{
						next = next._next;
					}
					return next;
				}
			}

			public WaitedListNode(ThreadWaitInfo waitInfo, int waitedObjectIndex)
			{
				_waitInfo = waitInfo;
				_waitedObjectIndex = waitedObjectIndex;
			}

			public void RegisterWait(WaitableObject waitableObject)
			{
				WaitedListNode waitersTail = waitableObject.WaitersTail;
				if (waitersTail != null)
				{
					_previous = waitersTail;
					waitersTail._next = this;
				}
				else
				{
					waitableObject.WaitersHead = this;
				}
				waitableObject.WaitersTail = this;
			}

			public void RegisterPrioritizedWait(WaitableObject waitableObject)
			{
				WaitedListNode waitersHead = waitableObject.WaitersHead;
				if (waitersHead != null)
				{
					_next = waitersHead;
					waitersHead._previous = this;
				}
				else
				{
					waitableObject.WaitersTail = this;
				}
				waitableObject.WaitersHead = this;
			}

			public void UnregisterWait(WaitableObject waitableObject)
			{
				WaitedListNode previous = _previous;
				WaitedListNode next = _next;
				if (previous != null)
				{
					previous._next = next;
					_previous = null;
				}
				else
				{
					waitableObject.WaitersHead = next;
				}
				if (next != null)
				{
					next._previous = previous;
					_next = null;
				}
				else
				{
					waitableObject.WaitersTail = previous;
				}
			}
		}

		private enum WaitSignalState : byte
		{
			Waiting,
			Waiting_Interruptible,
			NotWaiting,
			NotWaiting_SignaledToSatisfyWait,
			NotWaiting_SignaledToSatisfyWaitWithAbandonedMutex,
			NotWaiting_SignaledToAbortWaitDueToMaximumMutexReacquireCount,
			NotWaiting_SignaledToInterruptWait
		}

		private readonly Thread _thread;

		private LowLevelMonitor _waitMonitor;

		private WaitSignalState _waitSignalState;

		private int _waitedObjectIndexThatSatisfiedWait;

		private bool _isWaitForAll;

		private int _waitedCount;

		private WaitableObject[] _waitedObjects;

		private WaitedListNode[] _waitedListNodes;

		private bool _isPendingInterrupt;

		private WaitableObject _lockedMutexesHead;

		public Thread Thread => _thread;

		private bool IsWaiting => (int)_waitSignalState < 2;

		public bool CheckAndResetPendingInterrupt
		{
			get
			{
				if (!_isPendingInterrupt)
				{
					return false;
				}
				_isPendingInterrupt = false;
				return true;
			}
		}

		private bool CheckAndResetPendingInterrupt_NotLocked => Interlocked.CompareExchange(ref _isPendingInterrupt, value: false, comparand: true);

		public WaitableObject LockedMutexesHead
		{
			get
			{
				return _lockedMutexesHead;
			}
			set
			{
				_lockedMutexesHead = value;
			}
		}

		public ThreadWaitInfo(Thread thread)
		{
			_thread = thread;
			_waitMonitor.Initialize();
			_waitSignalState = WaitSignalState.NotWaiting;
			_waitedObjectIndexThatSatisfiedWait = -1;
			_waitedObjects = new WaitableObject[1];
			_waitedListNodes = new WaitedListNode[1]
			{
				new WaitedListNode(this, 0)
			};
		}

		~ThreadWaitInfo()
		{
			_waitMonitor.Dispose();
		}

		public WaitableObject[] GetWaitedObjectArray(int requiredCapacity)
		{
			int num = _waitedObjects.Length;
			if (num < requiredCapacity)
			{
				_waitedObjects = new WaitableObject[Math.Max(requiredCapacity, Math.Min(64, 2 * num))];
			}
			return _waitedObjects;
		}

		private WaitedListNode[] GetWaitedListNodeArray(int requiredCapacity)
		{
			int num = _waitedListNodes.Length;
			if (num < requiredCapacity)
			{
				WaitedListNode[] array = new WaitedListNode[Math.Max(requiredCapacity, Math.Min(64, 2 * num))];
				Array.Copy(_waitedListNodes, 0, array, 0, num);
				for (int i = num; i < array.Length; i++)
				{
					array[i] = new WaitedListNode(this, i);
				}
				_waitedListNodes = array;
			}
			return _waitedListNodes;
		}

		public void RegisterWait(int waitedCount, bool prioritize, bool isWaitForAll)
		{
			WaitableObject[] waitedObjects = _waitedObjects;
			bool flag = false;
			WaitedListNode[] waitedListNodeArray;
			try
			{
				waitedListNodeArray = GetWaitedListNodeArray(waitedCount);
				flag = true;
			}
			finally
			{
				if (!flag)
				{
					for (int i = 0; i < waitedCount; i++)
					{
						waitedObjects[i] = null;
					}
				}
			}
			_isWaitForAll = isWaitForAll;
			_waitedCount = waitedCount;
			if (prioritize)
			{
				for (int j = 0; j < waitedCount; j++)
				{
					waitedListNodeArray[j].RegisterPrioritizedWait(waitedObjects[j]);
				}
			}
			else
			{
				for (int k = 0; k < waitedCount; k++)
				{
					waitedListNodeArray[k].RegisterWait(waitedObjects[k]);
				}
			}
		}

		public void UnregisterWait()
		{
			for (int i = 0; i < _waitedCount; i++)
			{
				_waitedListNodes[i].UnregisterWait(_waitedObjects[i]);
				_waitedObjects[i] = null;
			}
			_waitedCount = 0;
		}

		private int ProcessSignaledWaitState()
		{
			switch (_waitSignalState)
			{
			case WaitSignalState.Waiting:
			case WaitSignalState.Waiting_Interruptible:
				return 258;
			case WaitSignalState.NotWaiting_SignaledToSatisfyWait:
			{
				int waitedObjectIndexThatSatisfiedWait2 = _waitedObjectIndexThatSatisfiedWait;
				_waitedObjectIndexThatSatisfiedWait = -1;
				return waitedObjectIndexThatSatisfiedWait2;
			}
			case WaitSignalState.NotWaiting_SignaledToSatisfyWaitWithAbandonedMutex:
			{
				int waitedObjectIndexThatSatisfiedWait = _waitedObjectIndexThatSatisfiedWait;
				_waitedObjectIndexThatSatisfiedWait = -1;
				return 128 + waitedObjectIndexThatSatisfiedWait;
			}
			case WaitSignalState.NotWaiting_SignaledToAbortWaitDueToMaximumMutexReacquireCount:
				throw new OverflowException("Overflow_MutexReacquireCount");
			default:
				throw new ThreadInterruptedException();
			}
		}

		public int Wait(int timeoutMilliseconds, bool interruptible, bool isSleep, ref LockHolder lockHolder)
		{
			_thread.SetWaitSleepJoinState();
			_waitMonitor.Acquire();
			if (!isSleep)
			{
				lockHolder.Dispose();
			}
			_waitSignalState = (interruptible ? WaitSignalState.Waiting_Interruptible : WaitSignalState.Waiting);
			try
			{
				if (isSleep && interruptible && CheckAndResetPendingInterrupt)
				{
					throw new ThreadInterruptedException();
				}
				if (timeoutMilliseconds < 0)
				{
					do
					{
						_waitMonitor.Wait();
					}
					while (IsWaiting);
					return ProcessSignaledWaitState();
				}
				int num = 0;
				int tickCount = Environment.TickCount;
				do
				{
					bool flag = _waitMonitor.Wait(timeoutMilliseconds - num);
					int num2 = ProcessSignaledWaitState();
					if (num2 != 258)
					{
						return num2;
					}
					if (flag)
					{
						num = Environment.TickCount - tickCount;
						continue;
					}
					break;
				}
				while (num < timeoutMilliseconds);
			}
			finally
			{
				_waitSignalState = WaitSignalState.NotWaiting;
				_waitMonitor.Release();
				_thread.ClearWaitSleepJoinState();
			}
			if (!isSleep)
			{
				s_lock.Acquire();
				UnregisterWait();
				s_lock.Release();
			}
			return 258;
		}

		public static void UninterruptibleSleep0()
		{
			Thread.Yield();
		}

		public static void Sleep(int timeoutMilliseconds, bool interruptible)
		{
			if (timeoutMilliseconds == 0)
			{
				if (interruptible && Thread.CurrentThread.WaitInfo.CheckAndResetPendingInterrupt_NotLocked)
				{
					throw new ThreadInterruptedException();
				}
				UninterruptibleSleep0();
			}
			else
			{
				LockHolder lockHolder = default(LockHolder);
				Thread.CurrentThread.WaitInfo.Wait(timeoutMilliseconds, interruptible, isSleep: true, ref lockHolder);
			}
		}

		public bool TrySignalToSatisfyWait(WaitedListNode registeredListNode, bool isAbandonedMutex)
		{
			int waitedObjectIndex = registeredListNode.WaitedObjectIndex;
			bool isWaitForAll = _isWaitForAll;
			bool wouldAnyMutexReacquireCountOverflow = false;
			if (isWaitForAll && !WaitableObject.WouldWaitForAllBeSatisfiedOrAborted(_thread, _waitedObjects, _waitedCount, waitedObjectIndex, ref wouldAnyMutexReacquireCountOverflow, ref isAbandonedMutex))
			{
				return false;
			}
			_waitMonitor.Acquire();
			if (!IsWaiting)
			{
				_waitMonitor.Release();
				return false;
			}
			if (isWaitForAll && !wouldAnyMutexReacquireCountOverflow)
			{
				WaitableObject.SatisfyWaitForAll(this, _waitedObjects, _waitedCount, waitedObjectIndex);
			}
			UnregisterWait();
			if (wouldAnyMutexReacquireCountOverflow)
			{
				_waitSignalState = WaitSignalState.NotWaiting_SignaledToAbortWaitDueToMaximumMutexReacquireCount;
			}
			else
			{
				_waitedObjectIndexThatSatisfiedWait = waitedObjectIndex;
				_waitSignalState = (isAbandonedMutex ? WaitSignalState.NotWaiting_SignaledToSatisfyWaitWithAbandonedMutex : WaitSignalState.NotWaiting_SignaledToSatisfyWait);
			}
			_waitMonitor.Signal_Release();
			return !wouldAnyMutexReacquireCountOverflow;
		}

		public void TrySignalToInterruptWaitOrRecordPendingInterrupt()
		{
			_waitMonitor.Acquire();
			if (_waitSignalState != WaitSignalState.Waiting_Interruptible)
			{
				RecordPendingInterrupt();
				_waitMonitor.Release();
				return;
			}
			if (_waitedCount != 0)
			{
				UnregisterWait();
			}
			_waitSignalState = WaitSignalState.NotWaiting_SignaledToInterruptWait;
			_waitMonitor.Signal_Release();
		}

		private void RecordPendingInterrupt()
		{
			_isPendingInterrupt = true;
		}

		public void OnThreadExiting()
		{
			s_lock.Acquire();
			try
			{
				while (true)
				{
					WaitableObject lockedMutexesHead = LockedMutexesHead;
					if (lockedMutexesHead == null)
					{
						break;
					}
					lockedMutexesHead.AbandonMutex();
				}
			}
			finally
			{
				s_lock.Release();
			}
		}
	}

	public struct LockHolder
	{
		private LowLevelLock _lock;

		public LockHolder(LowLevelLock l)
		{
			l.Acquire();
			_lock = l;
		}

		public void Dispose()
		{
			if (_lock != null)
			{
				_lock.Release();
				_lock = null;
			}
		}
	}

	public sealed class WaitableObject
	{
		private sealed class OwnershipInfo
		{
			private Thread _thread;

			private int _reacquireCount;

			private bool _isAbandoned;

			private WaitableObject _previous;

			private WaitableObject _next;

			public Thread Thread => _thread;

			public bool IsAbandoned => _isAbandoned;

			public bool CanIncrementReacquireCount => _reacquireCount + 1 > _reacquireCount;

			public void AssignOwnership(WaitableObject waitableObject, ThreadWaitInfo waitInfo)
			{
				_thread = waitInfo.Thread;
				_isAbandoned = false;
				WaitableObject lockedMutexesHead = waitInfo.LockedMutexesHead;
				if (lockedMutexesHead != null)
				{
					_next = lockedMutexesHead;
					lockedMutexesHead._ownershipInfo._previous = waitableObject;
				}
				waitInfo.LockedMutexesHead = waitableObject;
			}

			public void RelinquishOwnership(WaitableObject waitableObject, bool isAbandoned)
			{
				ThreadWaitInfo waitInfo = _thread.WaitInfo;
				_thread = null;
				if (isAbandoned)
				{
					_reacquireCount = 0;
					_isAbandoned = isAbandoned;
				}
				WaitableObject previous = _previous;
				WaitableObject next = _next;
				if (previous != null)
				{
					previous._ownershipInfo._next = next;
					_previous = null;
				}
				else
				{
					waitInfo.LockedMutexesHead = next;
				}
				if (next != null)
				{
					next._ownershipInfo._previous = previous;
					_next = null;
				}
			}

			public void IncrementReacquireCount()
			{
				_reacquireCount++;
			}

			public bool TryDecrementReacquireCount()
			{
				if (_reacquireCount == 0)
				{
					return false;
				}
				_reacquireCount--;
				return true;
			}
		}

		private enum WaitableObjectType : byte
		{
			ManualResetEvent,
			AutoResetEvent,
			Semaphore,
			Mutex
		}

		private static Dictionary<string, WaitableObject> s_namedObjects;

		private readonly WaitableObjectType _type;

		private int _signalCount;

		private readonly int _maximumSignalCount;

		private int _referenceCount;

		private readonly string _name;

		private readonly OwnershipInfo _ownershipInfo;

		private ThreadWaitInfo.WaitedListNode _waitersHead;

		private ThreadWaitInfo.WaitedListNode _waitersTail;

		private bool IsEvent => (int)_type <= 1;

		private bool IsSemaphore => _type == WaitableObjectType.Semaphore;

		private bool IsMutex => _type == WaitableObjectType.Mutex;

		private bool IsAbandonedMutex
		{
			get
			{
				if (IsMutex && _ownershipInfo != null)
				{
					return _ownershipInfo.IsAbandoned;
				}
				return false;
			}
		}

		public ThreadWaitInfo.WaitedListNode WaitersHead
		{
			get
			{
				return _waitersHead;
			}
			set
			{
				_waitersHead = value;
			}
		}

		public ThreadWaitInfo.WaitedListNode WaitersTail
		{
			get
			{
				return _waitersTail;
			}
			set
			{
				_waitersTail = value;
			}
		}

		private bool IsSignaled => _signalCount != 0;

		private WaitableObject(WaitableObjectType type, int initialSignalCount, int maximumSignalCount, string name, OwnershipInfo ownershipInfo)
		{
			_type = type;
			_signalCount = initialSignalCount;
			_maximumSignalCount = maximumSignalCount;
			_referenceCount = 1;
			_name = name;
			_ownershipInfo = ownershipInfo;
		}

		public static WaitableObject NewEvent(bool initiallySignaled, EventResetMode resetMode)
		{
			return new WaitableObject((resetMode != EventResetMode.ManualReset) ? WaitableObjectType.AutoResetEvent : WaitableObjectType.ManualResetEvent, initiallySignaled ? 1 : 0, 1, null, null);
		}

		public static WaitableObject NewSemaphore(int initialSignalCount, int maximumSignalCount)
		{
			return new WaitableObject(WaitableObjectType.Semaphore, initialSignalCount, maximumSignalCount, null, null);
		}

		public static WaitableObject NewMutex()
		{
			return new WaitableObject(WaitableObjectType.Mutex, 1, 1, null, new OwnershipInfo());
		}

		public static WaitableObject CreateNamedMutex_Locked(string name, out bool createdNew)
		{
			if (s_namedObjects == null)
			{
				s_namedObjects = new Dictionary<string, WaitableObject>();
			}
			if (s_namedObjects.TryGetValue(name, out var value))
			{
				createdNew = false;
				if (!value.IsMutex)
				{
					return null;
				}
				value._referenceCount++;
			}
			else
			{
				createdNew = true;
				value = new WaitableObject(WaitableObjectType.Mutex, 1, 1, name, new OwnershipInfo());
				s_namedObjects.Add(name, value);
			}
			return value;
		}

		public static OpenExistingResult OpenNamedMutex(string name, out WaitableObject result)
		{
			s_lock.Acquire();
			try
			{
				if (s_namedObjects == null || !s_namedObjects.TryGetValue(name, out result))
				{
					result = null;
					return OpenExistingResult.NameNotFound;
				}
				if (!result.IsMutex)
				{
					result = null;
					return OpenExistingResult.NameInvalid;
				}
				result._referenceCount++;
				return OpenExistingResult.Success;
			}
			finally
			{
				s_lock.Release();
			}
		}

		public void OnDeleteHandle()
		{
			s_lock.Acquire();
			try
			{
				_referenceCount--;
				if (_referenceCount <= 0)
				{
					if (_name != null)
					{
						s_namedObjects.Remove(_name);
					}
					if (IsMutex && !IsSignaled)
					{
						AbandonMutex();
					}
				}
			}
			finally
			{
				s_lock.Release();
			}
		}

		private void AcceptSignal(ThreadWaitInfo waitInfo)
		{
			switch (_type)
			{
			case WaitableObjectType.ManualResetEvent:
				break;
			case WaitableObjectType.AutoResetEvent:
			case WaitableObjectType.Semaphore:
				_signalCount--;
				break;
			default:
				_signalCount--;
				_ownershipInfo.AssignOwnership(this, waitInfo);
				break;
			}
		}

		public int Wait(ThreadWaitInfo waitInfo, int timeoutMilliseconds, bool interruptible, bool prioritize)
		{
			LockHolder lockHolder = new LockHolder(s_lock);
			try
			{
				if (interruptible && waitInfo.CheckAndResetPendingInterrupt)
				{
					lockHolder.Dispose();
					throw new ThreadInterruptedException();
				}
				return Wait_Locked(waitInfo, timeoutMilliseconds, interruptible, prioritize, ref lockHolder);
			}
			finally
			{
				lockHolder.Dispose();
			}
		}

		public int Wait_Locked(ThreadWaitInfo waitInfo, int timeoutMilliseconds, bool interruptible, bool prioritize, ref LockHolder lockHolder)
		{
			if (IsSignaled)
			{
				bool isAbandonedMutex = IsAbandonedMutex;
				AcceptSignal(waitInfo);
				if (!isAbandonedMutex)
				{
					return 0;
				}
				return 128;
			}
			if (IsMutex && _ownershipInfo != null && _ownershipInfo.Thread == waitInfo.Thread)
			{
				if (!_ownershipInfo.CanIncrementReacquireCount)
				{
					lockHolder.Dispose();
					throw new OverflowException("Overflow_MutexReacquireCount");
				}
				_ownershipInfo.IncrementReacquireCount();
				return 0;
			}
			if (timeoutMilliseconds == 0)
			{
				return 258;
			}
			waitInfo.GetWaitedObjectArray(1)[0] = this;
			waitInfo.RegisterWait(1, prioritize, isWaitForAll: false);
			return waitInfo.Wait(timeoutMilliseconds, interruptible, isSleep: false, ref lockHolder);
		}

		public static int Wait(WaitableObject[] waitableObjects, int count, bool waitForAll, ThreadWaitInfo waitInfo, int timeoutMilliseconds, bool interruptible, bool prioritize)
		{
			LockHolder lockHolder = new LockHolder(s_lock);
			try
			{
				if (interruptible && waitInfo.CheckAndResetPendingInterrupt)
				{
					lockHolder.Dispose();
					throw new ThreadInterruptedException();
				}
				if (!waitForAll)
				{
					for (int i = 0; i < count; i++)
					{
						WaitableObject waitableObject = waitableObjects[i];
						if (waitableObject.IsSignaled)
						{
							bool isAbandonedMutex = waitableObject.IsAbandonedMutex;
							waitableObject.AcceptSignal(waitInfo);
							if (isAbandonedMutex)
							{
								return 128 + i;
							}
							return i;
						}
						if (!waitableObject.IsMutex)
						{
							continue;
						}
						OwnershipInfo ownershipInfo = waitableObject._ownershipInfo;
						if (ownershipInfo.Thread == waitInfo.Thread)
						{
							if (!ownershipInfo.CanIncrementReacquireCount)
							{
								lockHolder.Dispose();
								throw new OverflowException("Overflow_MutexReacquireCount");
							}
							ownershipInfo.IncrementReacquireCount();
							return i;
						}
					}
				}
				else
				{
					bool flag = true;
					bool flag2 = false;
					for (int j = 0; j < count; j++)
					{
						WaitableObject waitableObject2 = waitableObjects[j];
						if (waitableObject2.IsSignaled)
						{
							if (!flag2 && waitableObject2.IsAbandonedMutex)
							{
								flag2 = true;
							}
							continue;
						}
						if (waitableObject2.IsMutex)
						{
							OwnershipInfo ownershipInfo2 = waitableObject2._ownershipInfo;
							if (ownershipInfo2.Thread == waitInfo.Thread)
							{
								if (!ownershipInfo2.CanIncrementReacquireCount)
								{
									lockHolder.Dispose();
									throw new OverflowException("Overflow_MutexReacquireCount");
								}
								continue;
							}
						}
						flag = false;
						break;
					}
					if (flag)
					{
						for (int k = 0; k < count; k++)
						{
							WaitableObject waitableObject3 = waitableObjects[k];
							if (waitableObject3.IsSignaled)
							{
								waitableObject3.AcceptSignal(waitInfo);
							}
							else
							{
								waitableObject3._ownershipInfo.IncrementReacquireCount();
							}
						}
						if (flag2)
						{
							lockHolder.Dispose();
							throw new AbandonedMutexException();
						}
						return 0;
					}
				}
				if (timeoutMilliseconds == 0)
				{
					return 258;
				}
				waitableObjects = null;
				waitInfo.RegisterWait(count, prioritize, waitForAll);
				return waitInfo.Wait(timeoutMilliseconds, interruptible, isSleep: false, ref lockHolder);
			}
			finally
			{
				lockHolder.Dispose();
				if (waitableObjects != null)
				{
					for (int l = 0; l < count; l++)
					{
						waitableObjects[l] = null;
					}
				}
			}
		}

		public static bool WouldWaitForAllBeSatisfiedOrAborted(Thread waitingThread, WaitableObject[] waitedObjects, int waitedCount, int signaledWaitedObjectIndex, ref bool wouldAnyMutexReacquireCountOverflow, ref bool isAnyAbandonedMutex)
		{
			for (int i = 0; i < waitedCount; i++)
			{
				if (i == signaledWaitedObjectIndex)
				{
					continue;
				}
				WaitableObject waitableObject = waitedObjects[i];
				if (waitableObject.IsSignaled)
				{
					if (!isAnyAbandonedMutex && waitableObject.IsAbandonedMutex)
					{
						isAnyAbandonedMutex = true;
					}
					continue;
				}
				if (waitableObject.IsMutex)
				{
					OwnershipInfo ownershipInfo = waitableObject._ownershipInfo;
					if (ownershipInfo.Thread == waitingThread)
					{
						if (!ownershipInfo.CanIncrementReacquireCount)
						{
							wouldAnyMutexReacquireCountOverflow = true;
							return true;
						}
						continue;
					}
				}
				return false;
			}
			return true;
		}

		public static void SatisfyWaitForAll(ThreadWaitInfo waitInfo, WaitableObject[] waitedObjects, int waitedCount, int signaledWaitedObjectIndex)
		{
			for (int i = 0; i < waitedCount; i++)
			{
				if (i != signaledWaitedObjectIndex)
				{
					WaitableObject waitableObject = waitedObjects[i];
					if (waitableObject.IsSignaled)
					{
						waitableObject.AcceptSignal(waitInfo);
					}
					else
					{
						waitableObject._ownershipInfo.IncrementReacquireCount();
					}
				}
			}
		}

		public void Signal(int count, ref LockHolder lockHolder)
		{
			switch (_type)
			{
			case WaitableObjectType.ManualResetEvent:
				SignalManualResetEvent();
				break;
			case WaitableObjectType.AutoResetEvent:
				SignalAutoResetEvent();
				break;
			case WaitableObjectType.Semaphore:
				SignalSemaphore(count, ref lockHolder);
				break;
			default:
				SignalMutex(ref lockHolder);
				break;
			}
		}

		public void SignalEvent(ref LockHolder lockHolder)
		{
			switch (_type)
			{
			case WaitableObjectType.ManualResetEvent:
				SignalManualResetEvent();
				break;
			case WaitableObjectType.AutoResetEvent:
				SignalAutoResetEvent();
				break;
			default:
				lockHolder.Dispose();
				WaitHandle.ThrowInvalidHandleException();
				break;
			}
		}

		private void SignalManualResetEvent()
		{
			if (!IsSignaled)
			{
				ThreadWaitInfo.WaitedListNode waitedListNode = _waitersHead;
				while (waitedListNode != null)
				{
					ThreadWaitInfo.WaitedListNode nextThread = waitedListNode.NextThread;
					waitedListNode.WaitInfo.TrySignalToSatisfyWait(waitedListNode, isAbandonedMutex: false);
					waitedListNode = nextThread;
				}
				_signalCount = 1;
			}
		}

		private void SignalAutoResetEvent()
		{
			if (IsSignaled)
			{
				return;
			}
			ThreadWaitInfo.WaitedListNode waitedListNode = _waitersHead;
			while (waitedListNode != null)
			{
				ThreadWaitInfo.WaitedListNode nextThread = waitedListNode.NextThread;
				if (waitedListNode.WaitInfo.TrySignalToSatisfyWait(waitedListNode, isAbandonedMutex: false))
				{
					return;
				}
				waitedListNode = nextThread;
			}
			_signalCount = 1;
		}

		public void UnsignalEvent(ref LockHolder lockHolder)
		{
			if (!IsEvent)
			{
				lockHolder.Dispose();
				WaitHandle.ThrowInvalidHandleException();
			}
			if (IsSignaled)
			{
				_signalCount--;
			}
		}

		public int SignalSemaphore(int count, ref LockHolder lockHolder)
		{
			if (!IsSemaphore)
			{
				lockHolder.Dispose();
				WaitHandle.ThrowInvalidHandleException();
			}
			int signalCount = _signalCount;
			if (count > _maximumSignalCount - signalCount)
			{
				lockHolder.Dispose();
				throw new SemaphoreFullException();
			}
			if (signalCount != 0)
			{
				_signalCount = signalCount + count;
				return signalCount;
			}
			ThreadWaitInfo.WaitedListNode waitedListNode = _waitersHead;
			while (waitedListNode != null)
			{
				ThreadWaitInfo.WaitedListNode nextThread = waitedListNode.NextThread;
				if (waitedListNode.WaitInfo.TrySignalToSatisfyWait(waitedListNode, isAbandonedMutex: false) && --count == 0)
				{
					return signalCount;
				}
				waitedListNode = nextThread;
			}
			_signalCount = count;
			return signalCount;
		}

		public void SignalMutex(ref LockHolder lockHolder)
		{
			if (!IsMutex)
			{
				lockHolder.Dispose();
				WaitHandle.ThrowInvalidHandleException();
			}
			if (IsSignaled || _ownershipInfo.Thread != Thread.CurrentThread)
			{
				lockHolder.Dispose();
				throw new ApplicationException("Arg_SynchronizationLockException");
			}
			if (!_ownershipInfo.TryDecrementReacquireCount())
			{
				SignalMutex(isAbandoned: false);
			}
		}

		public void AbandonMutex()
		{
			SignalMutex(isAbandoned: true);
		}

		private void SignalMutex(bool isAbandoned)
		{
			_ownershipInfo.RelinquishOwnership(this, isAbandoned);
			ThreadWaitInfo.WaitedListNode waitedListNode = _waitersHead;
			while (waitedListNode != null)
			{
				ThreadWaitInfo.WaitedListNode nextThread = waitedListNode.NextThread;
				ThreadWaitInfo waitInfo = waitedListNode.WaitInfo;
				if (waitInfo.TrySignalToSatisfyWait(waitedListNode, isAbandoned))
				{
					_ownershipInfo.AssignOwnership(this, waitInfo);
					return;
				}
				waitedListNode = nextThread;
			}
			_signalCount = 1;
		}
	}

	private static readonly LowLevelLock s_lock = new LowLevelLock();

	private static SafeWaitHandle NewHandle(WaitableObject waitableObject)
	{
		SafeWaitHandle safeWaitHandle = new SafeWaitHandle();
		nint num = IntPtr.Zero;
		try
		{
			num = HandleManager.NewHandle(waitableObject);
		}
		finally
		{
			if (num == IntPtr.Zero)
			{
				waitableObject.OnDeleteHandle();
			}
		}
		Marshal.InitHandle(safeWaitHandle, num);
		return safeWaitHandle;
	}

	public static SafeWaitHandle NewEvent(bool initiallySignaled, EventResetMode resetMode)
	{
		return NewHandle(WaitableObject.NewEvent(initiallySignaled, resetMode));
	}

	public static SafeWaitHandle NewSemaphore(int initialSignalCount, int maximumSignalCount)
	{
		return NewHandle(WaitableObject.NewSemaphore(initialSignalCount, maximumSignalCount));
	}

	public static SafeWaitHandle NewMutex(bool initiallyOwned)
	{
		WaitableObject waitableObject = WaitableObject.NewMutex();
		SafeWaitHandle result = NewHandle(waitableObject);
		if (!initiallyOwned)
		{
			return result;
		}
		ThreadWaitInfo waitInfo = Thread.CurrentThread.WaitInfo;
		waitableObject.Wait(waitInfo, 0, interruptible: false, prioritize: false);
		return result;
	}

	public static SafeWaitHandle CreateNamedMutex(bool initiallyOwned, string name, out bool createdNew)
	{
		LockHolder lockHolder = new LockHolder(s_lock);
		try
		{
			WaitableObject waitableObject = WaitableObject.CreateNamedMutex_Locked(name, out createdNew);
			if (waitableObject == null)
			{
				return null;
			}
			SafeWaitHandle result = NewHandle(waitableObject);
			if (!initiallyOwned || !createdNew)
			{
				return result;
			}
			ThreadWaitInfo waitInfo = Thread.CurrentThread.WaitInfo;
			waitableObject.Wait_Locked(waitInfo, 0, interruptible: false, prioritize: false, ref lockHolder);
			return result;
		}
		finally
		{
			lockHolder.Dispose();
		}
	}

	public static OpenExistingResult OpenNamedMutex(string name, out SafeWaitHandle result)
	{
		WaitableObject result2;
		OpenExistingResult openExistingResult = WaitableObject.OpenNamedMutex(name, out result2);
		result = ((openExistingResult == OpenExistingResult.Success) ? NewHandle(result2) : null);
		return openExistingResult;
	}

	public static void DeleteHandle(nint handle)
	{
		HandleManager.DeleteHandle(handle);
	}

	public static void SetEvent(nint handle)
	{
		SetEvent(HandleManager.FromHandle(handle));
	}

	public static void SetEvent(WaitableObject waitableObject)
	{
		LockHolder lockHolder = new LockHolder(s_lock);
		try
		{
			waitableObject.SignalEvent(ref lockHolder);
		}
		finally
		{
			lockHolder.Dispose();
		}
	}

	public static void ResetEvent(nint handle)
	{
		ResetEvent(HandleManager.FromHandle(handle));
	}

	public static void ResetEvent(WaitableObject waitableObject)
	{
		LockHolder lockHolder = new LockHolder(s_lock);
		try
		{
			waitableObject.UnsignalEvent(ref lockHolder);
		}
		finally
		{
			lockHolder.Dispose();
		}
	}

	public static int ReleaseSemaphore(nint handle, int count)
	{
		return ReleaseSemaphore(HandleManager.FromHandle(handle), count);
	}

	public static int ReleaseSemaphore(WaitableObject waitableObject, int count)
	{
		LockHolder lockHolder = new LockHolder(s_lock);
		try
		{
			return waitableObject.SignalSemaphore(count, ref lockHolder);
		}
		finally
		{
			lockHolder.Dispose();
		}
	}

	public static void ReleaseMutex(nint handle)
	{
		ReleaseMutex(HandleManager.FromHandle(handle));
	}

	public static void ReleaseMutex(WaitableObject waitableObject)
	{
		LockHolder lockHolder = new LockHolder(s_lock);
		try
		{
			waitableObject.SignalMutex(ref lockHolder);
		}
		finally
		{
			lockHolder.Dispose();
		}
	}

	public static int Wait(nint handle, int timeoutMilliseconds, bool interruptible)
	{
		return Wait(HandleManager.FromHandle(handle), timeoutMilliseconds, interruptible);
	}

	public static int Wait(WaitableObject waitableObject, int timeoutMilliseconds, bool interruptible = true, bool prioritize = false)
	{
		return waitableObject.Wait(Thread.CurrentThread.WaitInfo, timeoutMilliseconds, interruptible, prioritize);
	}

	public static int Wait(ReadOnlySpan<nint> waitHandles, bool waitForAll, int timeoutMilliseconds)
	{
		ThreadWaitInfo waitInfo = Thread.CurrentThread.WaitInfo;
		WaitableObject[] waitedObjectArray = waitInfo.GetWaitedObjectArray(waitHandles.Length);
		bool flag = false;
		try
		{
			for (int i = 0; i < waitHandles.Length; i++)
			{
				WaitableObject waitableObject = HandleManager.FromHandle(waitHandles[i]);
				if (waitForAll)
				{
					for (int j = 0; j < i; j++)
					{
						if (waitableObject == waitedObjectArray[j])
						{
							throw new DuplicateWaitObjectException("waitHandles[" + i + "]");
						}
					}
				}
				waitedObjectArray[i] = waitableObject;
			}
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				for (int k = 0; k < waitHandles.Length; k++)
				{
					waitedObjectArray[k] = null;
				}
			}
		}
		if (waitHandles.Length == 1)
		{
			WaitableObject obj = waitedObjectArray[0];
			waitedObjectArray[0] = null;
			return obj.Wait(waitInfo, timeoutMilliseconds, interruptible: true, prioritize: false);
		}
		return WaitableObject.Wait(waitedObjectArray, waitHandles.Length, waitForAll, waitInfo, timeoutMilliseconds, interruptible: true, prioritize: false);
	}

	public static int SignalAndWait(nint handleToSignal, nint handleToWaitOn, int timeoutMilliseconds)
	{
		return SignalAndWait(HandleManager.FromHandle(handleToSignal), HandleManager.FromHandle(handleToWaitOn), timeoutMilliseconds);
	}

	public static int SignalAndWait(WaitableObject waitableObjectToSignal, WaitableObject waitableObjectToWaitOn, int timeoutMilliseconds, bool interruptible = true, bool prioritize = false)
	{
		ThreadWaitInfo waitInfo = Thread.CurrentThread.WaitInfo;
		LockHolder lockHolder = new LockHolder(s_lock);
		try
		{
			if (interruptible && waitInfo.CheckAndResetPendingInterrupt)
			{
				lockHolder.Dispose();
				throw new ThreadInterruptedException();
			}
			try
			{
				waitableObjectToSignal.Signal(1, ref lockHolder);
			}
			catch (SemaphoreFullException innerException)
			{
				throw new InvalidOperationException("Threading_WaitHandleTooManyPosts", innerException);
			}
			return waitableObjectToWaitOn.Wait_Locked(waitInfo, timeoutMilliseconds, interruptible, prioritize, ref lockHolder);
		}
		finally
		{
			lockHolder.Dispose();
		}
	}

	public static void Sleep(int timeoutMilliseconds, bool interruptible = true)
	{
		ThreadWaitInfo.Sleep(timeoutMilliseconds, interruptible);
	}

	public static void Interrupt(Thread thread)
	{
		s_lock.Acquire();
		try
		{
			thread.WaitInfo.TrySignalToInterruptWaitOrRecordPendingInterrupt();
		}
		finally
		{
			s_lock.Release();
		}
	}
}
