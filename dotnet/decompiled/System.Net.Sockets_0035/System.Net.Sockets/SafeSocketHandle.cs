using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace System.Net.Sockets;

public sealed class SafeSocketHandle : SafeHandleMinusOneIsInvalid
{
	[Flags]
	private enum Flags : byte
	{
		NonBlocking = 1,
		LastConnectFailed = 2,
		DualMode = 4,
		ExposedHandleOrUntrackedConfiguration = 8,
		PreferInlineCompletions = 0x10,
		IsSocket = 0x20,
		IsDisconnected = 0x40
	}

	private enum TrackableSocketOptions
	{
		None,
		IP_TOS,
		IP_TTL,
		IPV6_PROTECTION_LEVEL,
		IPV6_V6ONLY,
		TCP_NODELAY,
		TCP_EXPEDITED_1122,
		TCP_KEEPALIVE,
		TCP_FASTOPEN,
		TCP_KEEPCNT,
		TCP_KEEPINTVL,
		SO_DEBUG,
		SO_ACCEPTCONN,
		SO_REUSEADDR,
		SO_KEEPALIVE,
		SO_DONTROUTE,
		SO_USELOOPBACK,
		SO_LINGER,
		SO_OOBINLINE,
		SO_DONTLINGER,
		SO_EXCLUSIVEADDRUSE,
		SO_SNDBUF,
		SO_RCVBUF,
		SO_SNDLOWAT,
		SO_RCVLOWAT,
		SO_SNDTIMEO,
		SO_RCVTIMEO
	}

	private bool _ownClose;

	private volatile bool _released;

	private bool _hasShutdownSend;

	private int _receiveTimeout = -1;

	private int _sendTimeout = -1;

	private SocketAsyncContext _asyncContext;

	private Flags _flags = (Flags)(0x20 | (SocketAsyncEngine.InlineSocketCompletionsEnabled ? 16 : 0));

	private int _trackedOptions;

	internal bool OwnsHandle { get; }

	internal bool HasShutdownSend => _hasShutdownSend;

	public override bool IsInvalid
	{
		get
		{
			if (!base.IsClosed)
			{
				return base.IsInvalid;
			}
			return true;
		}
	}

	internal bool LastConnectFailed
	{
		get
		{
			return (_flags & Flags.LastConnectFailed) != 0;
		}
		set
		{
			SetFlag(Flags.LastConnectFailed, value);
		}
	}

	internal bool DualMode
	{
		get
		{
			return (_flags & Flags.DualMode) != 0;
		}
		set
		{
			SetFlag(Flags.DualMode, value);
		}
	}

	internal bool ExposedHandleOrUntrackedConfiguration
	{
		get
		{
			return (_flags & Flags.ExposedHandleOrUntrackedConfiguration) != 0;
		}
		private set
		{
			SetFlag(Flags.ExposedHandleOrUntrackedConfiguration, value);
		}
	}

	internal bool PreferInlineCompletions
	{
		get
		{
			return (_flags & Flags.PreferInlineCompletions) != 0;
		}
		set
		{
			SetFlag(Flags.PreferInlineCompletions, value);
		}
	}

	internal bool IsSocket
	{
		get
		{
			return (_flags & Flags.IsSocket) != 0;
		}
		set
		{
			SetFlag(Flags.IsSocket, value);
		}
	}

	internal SocketAsyncContext AsyncContext => _asyncContext ?? Interlocked.CompareExchange(ref _asyncContext, new SocketAsyncContext(this), null) ?? _asyncContext;

	internal bool IsNonBlocking
	{
		get
		{
			return (_flags & Flags.NonBlocking) != 0;
		}
		set
		{
			SetFlag(Flags.NonBlocking, value);
			if (value)
			{
				AsyncContext.SetHandleNonBlocking();
			}
		}
	}

	internal bool IsUnderlyingHandleBlocking => !AsyncContext.IsHandleNonBlocking;

	internal int ReceiveTimeout
	{
		get
		{
			return _receiveTimeout;
		}
		set
		{
			_receiveTimeout = value;
		}
	}

	internal int SendTimeout
	{
		get
		{
			return _sendTimeout;
		}
		set
		{
			_sendTimeout = value;
		}
	}

	internal bool IsDisconnected => (_flags & Flags.IsDisconnected) != 0;

	public SafeSocketHandle()
		: base(ownsHandle: true)
	{
		OwnsHandle = true;
	}

	public SafeSocketHandle(nint preexistingHandle, bool ownsHandle)
		: base(ownsHandle: true)
	{
		OwnsHandle = ownsHandle;
		SetHandleAndValid(preexistingHandle);
	}

	private bool TryOwnClose()
	{
		return !Interlocked.Exchange(ref _ownClose, value: true);
	}

	internal void TrackShutdown(SocketShutdown how)
	{
		if (how == SocketShutdown.Send || how == SocketShutdown.Both)
		{
			_hasShutdownSend = true;
		}
	}

	protected override bool ReleaseHandle()
	{
		_released = true;
		bool flag = TryOwnClose();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (flag)
		{
			CloseHandle(abortive: true, canceledOperations: false);
		}
		return true;
	}

	internal void CloseAsIs(bool abortive)
	{
		bool flag = TryOwnClose();
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		Dispose();
		if (flag)
		{
			bool flag2 = false;
			SpinWait spinWait = default(SpinWait);
			while (!_released)
			{
				flag2 |= TryUnblockSocket(abortive);
				spinWait.SpinOnce();
			}
			CloseHandle(abortive, flag2);
		}
	}

	private bool CloseHandle(bool abortive, bool canceledOperations)
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		canceledOperations |= OnHandleClose();
		if (canceledOperations && !_hasShutdownSend)
		{
			abortive = true;
		}
		if (OwnsHandle)
		{
			return DoCloseHandle(abortive) == SocketError.Success;
		}
		return true;
	}

	private void SetHandleAndValid(nint handle)
	{
		SetHandle(handle);
		if (IsInvalid)
		{
			TryOwnClose();
			SetHandleAsInvalid();
		}
	}

	private void SetFlag(Flags flag, bool value)
	{
		if (value)
		{
			_flags |= flag;
		}
		else
		{
			_flags &= (Flags)(byte)(~(int)flag);
		}
	}

	internal void RegisterConnectResult(SocketError error)
	{
		if (error != SocketError.Success && error != SocketError.WouldBlock)
		{
			LastConnectFailed = true;
		}
	}

	internal void TransferTrackedState(SafeSocketHandle target)
	{
		target._trackedOptions = _trackedOptions;
		target.LastConnectFailed = LastConnectFailed;
		target.DualMode = DualMode;
		target.ExposedHandleOrUntrackedConfiguration = ExposedHandleOrUntrackedConfiguration;
		target.IsSocket = IsSocket;
	}

	private bool OnHandleClose()
	{
		return _asyncContext?.StopAndAbort() ?? false;
	}

	private unsafe bool TryUnblockSocket(bool abortive)
	{
		if (!OwnsHandle)
		{
			return false;
		}
		if (!abortive && global::Interop.Sys.Fcntl.GetFD(handle) == 0)
		{
			return false;
		}
		int num = 0;
		int num2 = 4;
		if (global::Interop.Sys.GetSockOpt(handle, SocketOptionLevel.Socket, SocketOptionName.Type, (byte*)(&num), &num2) == global::Interop.Error.SUCCESS)
		{
			if (num == 1 && !_hasShutdownSend)
			{
				global::Interop.Sys.Disconnect(handle);
			}
			else
			{
				global::Interop.Sys.Shutdown(handle, SocketShutdown.Both);
			}
		}
		return true;
	}

	private unsafe SocketError DoCloseHandle(bool abortive)
	{
		global::Interop.Error error = global::Interop.Error.SUCCESS;
		if (!IsSocket)
		{
			return SocketPal.GetSocketErrorForErrorCode(CloseHandle(handle));
		}
		if (false)
		{
		}
		if (!abortive)
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			error = CloseHandle(handle);
			if (error != global::Interop.Error.EAGAIN)
			{
				return SocketPal.GetSocketErrorForErrorCode(error);
			}
			if (global::Interop.Sys.Fcntl.DangerousSetIsNonBlocking(handle, 0) == 0)
			{
				return SocketPal.GetSocketErrorForErrorCode(CloseHandle(handle));
			}
		}
		global::Interop.Sys.LingerOption lingerOption = new global::Interop.Sys.LingerOption
		{
			OnOff = 1,
			Seconds = 0
		};
		error = global::Interop.Sys.SetLingerOption(handle, &lingerOption);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		switch (error)
		{
		case global::Interop.Error.SUCCESS:
		case global::Interop.Error.EINVAL:
		case global::Interop.Error.ENOPROTOOPT:
		case global::Interop.Error.ENOTSOCK:
			error = CloseHandle(handle);
			break;
		}
		return SocketPal.GetSocketErrorForErrorCode(error);
	}

	private global::Interop.Error CloseHandle(nint handle)
	{
		global::Interop.Error error = global::Interop.Error.SUCCESS;
		bool flag = false;
		if (global::Interop.Sys.Close(handle) != 0)
		{
			error = global::Interop.Sys.GetLastError();
			if (error == global::Interop.Error.ECONNRESET)
			{
				error = global::Interop.Error.SUCCESS;
				flag = true;
			}
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return error;
	}

	internal void TrackSocketOption(SocketOptionLevel level, SocketOptionName name)
	{
		TrackableSocketOptions trackableSocketOptions = ToTrackableSocketOptions(name, level);
		if (trackableSocketOptions == TrackableSocketOptions.None)
		{
			ExposedHandleOrUntrackedConfiguration = true;
		}
		else
		{
			_trackedOptions |= GetFlag(trackableSocketOptions);
		}
	}

	internal void GetTrackedSocketOptions(Span<int> values, out LingerOption lingerOption)
	{
		int num = _trackedOptions;
		lingerOption = null;
		int flag = GetFlag(TrackableSocketOptions.SO_LINGER);
		if ((num & flag) == flag)
		{
			if (SocketPal.GetLingerOption(this, out lingerOption) != SocketError.Success)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				_trackedOptions &= ~flag;
			}
			num &= ~flag;
		}
		int flag2 = GetFlag(TrackableSocketOptions.IPV6_V6ONLY);
		if ((num & flag2) == flag2)
		{
			values[3] = ((!DualMode) ? 1 : 0);
			num &= ~flag2;
		}
		for (int i = 0; i < values.Length; i++)
		{
			int num2 = 1 << i;
			if ((num & num2) != num2)
			{
				continue;
			}
			var (optionName, optionLevel) = ToSocketOptions((TrackableSocketOptions)(i + 1));
			if (SocketPal.GetSockOpt(this, optionLevel, optionName, out values[i]) != SocketError.Success)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				_trackedOptions &= ~num2;
			}
		}
	}

	internal void SetTrackedSocketOptions(ReadOnlySpan<int> values, LingerOption lingerOption)
	{
		int flag = GetFlag(TrackableSocketOptions.SO_LINGER);
		if (lingerOption != null)
		{
			SocketError socketError = SocketPal.SetLingerOption(this, lingerOption);
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
		}
		int num = _trackedOptions & ~flag;
		for (int i = 0; i < values.Length; i++)
		{
			int num2 = 1 << i;
			if ((num & num2) == num2)
			{
				(SocketOptionName, SocketOptionLevel) tuple = ToSocketOptions((TrackableSocketOptions)(i + 1));
				SocketOptionName item = tuple.Item1;
				SocketOptionLevel item2 = tuple.Item2;
				SocketError socketError2 = SocketPal.SetSockOpt(this, item2, item, values[i]);
				if (!System.Net.NetEventSource.Log.IsEnabled())
				{
				}
			}
		}
	}

	private static int GetFlag(TrackableSocketOptions tracked)
	{
		return 1 << (int)(tracked - 1);
	}

	private static TrackableSocketOptions ToTrackableSocketOptions(SocketOptionName name, SocketOptionLevel level)
	{
		switch ((int)name)
		{
		case 3:
			switch (level)
			{
			case SocketOptionLevel.IP:
				return TrackableSocketOptions.IP_TOS;
			case SocketOptionLevel.Tcp:
				return TrackableSocketOptions.TCP_KEEPALIVE;
			}
			break;
		case 4:
			switch (level)
			{
			case SocketOptionLevel.IP:
				return TrackableSocketOptions.IP_TTL;
			case SocketOptionLevel.Socket:
				return TrackableSocketOptions.SO_REUSEADDR;
			}
			break;
		case 23:
			if (level != SocketOptionLevel.IPv6)
			{
				break;
			}
			return TrackableSocketOptions.IPV6_PROTECTION_LEVEL;
		case 27:
			if (level != SocketOptionLevel.IPv6)
			{
				break;
			}
			return TrackableSocketOptions.IPV6_V6ONLY;
		case 1:
			switch (level)
			{
			case SocketOptionLevel.Tcp:
				return TrackableSocketOptions.TCP_NODELAY;
			case SocketOptionLevel.Socket:
				return TrackableSocketOptions.SO_DEBUG;
			}
			break;
		case 2:
			switch (level)
			{
			case SocketOptionLevel.Tcp:
				return TrackableSocketOptions.TCP_EXPEDITED_1122;
			case SocketOptionLevel.Socket:
				return TrackableSocketOptions.SO_ACCEPTCONN;
			}
			break;
		case 15:
			if (level != SocketOptionLevel.Tcp)
			{
				break;
			}
			return TrackableSocketOptions.TCP_FASTOPEN;
		case 16:
			switch (level)
			{
			case SocketOptionLevel.Tcp:
				return TrackableSocketOptions.TCP_KEEPCNT;
			case SocketOptionLevel.Socket:
				return TrackableSocketOptions.SO_DONTROUTE;
			}
			break;
		case 17:
			if (level != SocketOptionLevel.Tcp)
			{
				break;
			}
			return TrackableSocketOptions.TCP_KEEPINTVL;
		case 8:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_KEEPALIVE;
		case 64:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_USELOOPBACK;
		case 128:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_LINGER;
		case 256:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_OOBINLINE;
		case -129:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_DONTLINGER;
		case -5:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_EXCLUSIVEADDRUSE;
		case 4097:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_SNDBUF;
		case 4098:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_RCVBUF;
		case 4099:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_SNDLOWAT;
		case 4100:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_RCVLOWAT;
		case 4101:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_SNDTIMEO;
		case 4102:
			if (level != SocketOptionLevel.Socket)
			{
				break;
			}
			return TrackableSocketOptions.SO_RCVTIMEO;
		}
		return TrackableSocketOptions.None;
	}

	private static (SocketOptionName, SocketOptionLevel) ToSocketOptions(TrackableSocketOptions options)
	{
		return options switch
		{
			TrackableSocketOptions.IP_TOS => (SocketOptionName.TypeOfService, SocketOptionLevel.IP), 
			TrackableSocketOptions.IP_TTL => (SocketOptionName.ReuseAddress, SocketOptionLevel.IP), 
			TrackableSocketOptions.IPV6_PROTECTION_LEVEL => (SocketOptionName.IPProtectionLevel, SocketOptionLevel.IPv6), 
			TrackableSocketOptions.IPV6_V6ONLY => (SocketOptionName.IPv6Only, SocketOptionLevel.IPv6), 
			TrackableSocketOptions.TCP_NODELAY => (SocketOptionName.Debug, SocketOptionLevel.Tcp), 
			TrackableSocketOptions.TCP_EXPEDITED_1122 => (SocketOptionName.AcceptConnection, SocketOptionLevel.Tcp), 
			TrackableSocketOptions.TCP_KEEPALIVE => (SocketOptionName.TypeOfService, SocketOptionLevel.Tcp), 
			TrackableSocketOptions.TCP_FASTOPEN => (SocketOptionName.AddSourceMembership, SocketOptionLevel.Tcp), 
			TrackableSocketOptions.TCP_KEEPCNT => (SocketOptionName.DontRoute, SocketOptionLevel.Tcp), 
			TrackableSocketOptions.TCP_KEEPINTVL => (SocketOptionName.BlockSource, SocketOptionLevel.Tcp), 
			TrackableSocketOptions.SO_DEBUG => (SocketOptionName.Debug, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_ACCEPTCONN => (SocketOptionName.AcceptConnection, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_REUSEADDR => (SocketOptionName.ReuseAddress, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_KEEPALIVE => (SocketOptionName.KeepAlive, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_DONTROUTE => (SocketOptionName.DontRoute, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_USELOOPBACK => (SocketOptionName.UseLoopback, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_LINGER => (SocketOptionName.Linger, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_OOBINLINE => (SocketOptionName.OutOfBandInline, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_DONTLINGER => (SocketOptionName.DontLinger, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_EXCLUSIVEADDRUSE => (SocketOptionName.ExclusiveAddressUse, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_SNDBUF => (SocketOptionName.SendBuffer, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_RCVBUF => (SocketOptionName.ReceiveBuffer, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_SNDLOWAT => (SocketOptionName.SendLowWater, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_RCVLOWAT => (SocketOptionName.ReceiveLowWater, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_SNDTIMEO => (SocketOptionName.SendTimeout, SocketOptionLevel.Socket), 
			TrackableSocketOptions.SO_RCVTIMEO => (SocketOptionName.ReceiveTimeout, SocketOptionLevel.Socket), 
			_ => default((SocketOptionName, SocketOptionLevel)), 
		};
	}
}
