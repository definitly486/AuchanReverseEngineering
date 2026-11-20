using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Diagnostics;

internal sealed class ProcessWaitState : IDisposable
{
	internal sealed class Holder : IDisposable
	{
		internal ProcessWaitState _state;

		internal Holder(int processId, bool isNewChild = false, bool usesTerminal = false)
		{
			_state = AddRef(processId, isNewChild, usesTerminal);
		}

		~Holder()
		{
			if (_state != null)
			{
				_ = 0;
				_state.ReleaseRef();
			}
		}

		public void Dispose()
		{
			if (_state != null)
			{
				GC.SuppressFinalize(this);
				_state.ReleaseRef();
				_state = null;
			}
		}
	}

	private static readonly Dictionary<int, ProcessWaitState> s_processWaitStates = new Dictionary<int, ProcessWaitState>();

	private static readonly Dictionary<int, ProcessWaitState> s_childProcessWaitStates = new Dictionary<int, ProcessWaitState>();

	private readonly object _gate = new object();

	private readonly int _processId;

	private readonly bool _isChild;

	private readonly bool _usesTerminal;

	private Task _waitInProgress = Task.CompletedTask;

	private int _outstandingRefCount;

	private bool _exited;

	private int? _exitCode;

	private DateTime _exitTime;

	private ManualResetEvent _exitedEvent;

	internal DateTime ExitTime
	{
		get
		{
			lock (_gate)
			{
				return _exitTime;
			}
		}
	}

	internal static ProcessWaitState AddRef(int processId, bool isNewChild, bool usesTerminal)
	{
		lock (s_childProcessWaitStates)
		{
			ProcessWaitState value;
			if (isNewChild)
			{
				s_childProcessWaitStates.Remove(processId);
				value = new ProcessWaitState(processId, isChild: true, usesTerminal);
				s_childProcessWaitStates.Add(processId, value);
				value._outstandingRefCount++;
				value._outstandingRefCount++;
			}
			else
			{
				lock (s_processWaitStates)
				{
					DateTime exitTime = default(DateTime);
					if (!s_childProcessWaitStates.TryGetValue(processId, out value) && s_processWaitStates.TryGetValue(processId, out value) && value.GetExited(out var _, refresh: false))
					{
						s_processWaitStates.Remove(processId);
						exitTime = value.ExitTime;
						value = null;
					}
					if (value == null)
					{
						value = new ProcessWaitState(processId, isChild: false, usesTerminal: false, exitTime);
						s_processWaitStates.Add(processId, value);
					}
					value._outstandingRefCount++;
				}
			}
			return value;
		}
	}

	internal void ReleaseRef()
	{
		Dictionary<int, ProcessWaitState> dictionary = (_isChild ? s_childProcessWaitStates : s_processWaitStates);
		ProcessWaitState value;
		lock (dictionary)
		{
			if (dictionary.TryGetValue(_processId, out value))
			{
				_outstandingRefCount--;
				if (_outstandingRefCount == 0)
				{
					if (value == this)
					{
						dictionary.Remove(_processId);
					}
					value = this;
				}
				else
				{
					value = null;
				}
			}
		}
		value?.Dispose();
	}

	private ProcessWaitState(int processId, bool isChild, bool usesTerminal, DateTime exitTime = default(DateTime))
	{
		_processId = processId;
		_isChild = isChild;
		_usesTerminal = usesTerminal;
		_exitTime = exitTime;
	}

	public void Dispose()
	{
		lock (_gate)
		{
			if (_exitedEvent != null)
			{
				_exitedEvent.Dispose();
				_exitedEvent = null;
			}
		}
	}

	private void SetExited()
	{
		_exited = true;
		if (_exitTime == default(DateTime))
		{
			_exitTime = DateTime.Now;
		}
		_exitedEvent?.Set();
	}

	internal ManualResetEvent EnsureExitedEvent()
	{
		lock (_gate)
		{
			if (_exitedEvent == null)
			{
				_exitedEvent = new ManualResetEvent(_exited);
				if (!_exited && !_isChild)
				{
					_waitInProgress = WaitForExitAsync(CancellationToken.None);
				}
			}
			return _exitedEvent;
		}
	}

	internal bool GetExited(out int? exitCode, bool refresh)
	{
		lock (_gate)
		{
			if (_exited)
			{
				exitCode = _exitCode;
				return true;
			}
			if (!_waitInProgress.IsCompleted)
			{
				exitCode = null;
				return false;
			}
			if (refresh)
			{
				CheckForNonChildExit();
			}
			exitCode = _exitCode;
			return _exited;
		}
	}

	private void CheckForNonChildExit()
	{
		if (!_isChild)
		{
			if (global::Interop.Sys.Kill(_processId, global::Interop.Sys.Signals.None) != 0 && global::Interop.Sys.GetLastError() switch
			{
				global::Interop.Error.ESRCH => true, 
				global::Interop.Error.EPERM => false, 
				_ => true, 
			})
			{
				SetExited();
			}
			else
			{
				_exitTime = default(DateTime);
			}
		}
	}

	private async Task WaitForExitAsync(CancellationToken cancellationToken)
	{
		await _waitInProgress.ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing | ConfigureAwaitOptions.ForceYielding);
		int pollingIntervalMs = 1;
		while (!cancellationToken.IsCancellationRequested)
		{
			lock (_gate)
			{
				if (!_exited)
				{
					CheckForNonChildExit();
				}
				if (_exited)
				{
					break;
				}
			}
			await Task.Delay(pollingIntervalMs, cancellationToken).ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
			pollingIntervalMs = Math.Min(pollingIntervalMs * 2, 100);
		}
	}
}
