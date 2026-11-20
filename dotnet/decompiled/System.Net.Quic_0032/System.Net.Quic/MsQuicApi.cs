using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Quic;

namespace System.Net.Quic;

internal sealed class MsQuicApi
{
	private static readonly Version s_minWindowsVersion;

	private static readonly Version s_minMsQuicVersion;

	private unsafe static readonly delegate* unmanaged[Cdecl]<uint, QUIC_API_TABLE**, int> MsQuicOpenVersion;

	private unsafe static readonly delegate* unmanaged[Cdecl]<QUIC_API_TABLE*, void> MsQuicClose;

	private static readonly Lazy<MsQuicApi> _api;

	[CompilerGenerated]
	private static readonly string _003CMsQuicLibraryVersion_003Ek__BackingField;

	[CompilerGenerated]
	private static readonly bool _003CTls13ServerMayBeDisabled_003Ek__BackingField;

	[CompilerGenerated]
	private static readonly bool _003CTls13ClientMayBeDisabled_003Ek__BackingField;

	public MsQuicSafeHandle Registration { get; }

	public unsafe QUIC_API_TABLE* ApiTable { get; }

	internal static MsQuicApi Api => _api.Value;

	internal static Version Version { get; }

	internal static bool IsQuicSupported { get; }

	internal static string NotSupportedReason { get; }

	internal static bool SupportsAsyncCertValidation => Version > new Version(2, 4);

	internal static bool UsesSChannelBackend { get; }

	private unsafe MsQuicApi(QUIC_API_TABLE* apiTable)
	{
		ApiTable = apiTable;
		fixed (byte* appName = "System.Net.Quic"u8)
		{
			QUIC_REGISTRATION_CONFIG qUIC_REGISTRATION_CONFIG = new QUIC_REGISTRATION_CONFIG
			{
				AppName = (sbyte*)appName,
				ExecutionProfile = QUIC_EXECUTION_PROFILE.LOW_LATENCY
			};
			Unsafe.SkipInit(out QUIC_HANDLE* handle);
			ThrowHelper.ThrowIfMsQuicError(ApiTable->RegistrationOpen(&qUIC_REGISTRATION_CONFIG, &handle), "RegistrationOpen failed");
			Registration = new MsQuicSafeHandle(handle, apiTable->RegistrationClose, SafeHandleType.Registration);
		}
	}

	[UnconditionalSuppressMessage("SingleFile", "IL3000: Avoid accessing Assembly file path when publishing as a single file", Justification = "The code handles the Assembly.Location being null/empty by falling back to AppContext.BaseDirectory")]
	static unsafe MsQuicApi()
	{
		s_minWindowsVersion = new Version(10, 0, 20145, 1000);
		s_minMsQuicVersion = new Version(2, 2, 2);
		_api = new Lazy<MsQuicApi>(AllocateMsQuicApi);
		_003CMsQuicLibraryVersion_003Ek__BackingField = "unknown";
		bool flag = false;
		nint handle = IntPtr.Zero;
		Version = null;
		if (!Socket.OSSupportsIPv6)
		{
			NotSupportedReason = "OS does not support dual mode sockets.";
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return;
		}
		if (false)
		{
		}
		if (!NativeLibrary.TryLoad($"{"libmsquic.so"}.{s_minMsQuicVersion.Major}", typeof(MsQuicApi).Assembly, null, out handle) && !NativeLibrary.TryLoad("libmsquic.so", typeof(MsQuicApi).Assembly, null, out handle))
		{
			NotSupportedReason = $"Unable to load MsQuic library version '{s_minMsQuicVersion.Major}'.";
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return;
		}
		MsQuicOpenVersion = (delegate* unmanaged[Cdecl]<uint, QUIC_API_TABLE**, int>)NativeLibrary.GetExport(handle, "MsQuicOpenVersion");
		MsQuicClose = (delegate* unmanaged[Cdecl]<QUIC_API_TABLE*, void>)NativeLibrary.GetExport(handle, "MsQuicClose");
		if (!TryOpenMsQuic(out var apiTable, out var openStatus))
		{
			NotSupportedReason = $"MsQuicOpenVersion for version {s_minMsQuicVersion.Major} returned {openStatus} status code.";
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return;
		}
		try
		{
			uint num = 16u;
			uint* ptr = stackalloc uint[4];
			int status = apiTable->GetParam(null, 16777220u, &num, ptr);
			if (MsQuic.StatusFailed(status))
			{
				if (!System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				return;
			}
			Version = new Version((int)(*ptr), (int)ptr[1], (int)ptr[2], (int)ptr[3]);
			num = 64u;
			sbyte* ptr2 = stackalloc sbyte[64];
			status = apiTable->GetParam(null, 16777224u, &num, ptr2);
			if (MsQuic.StatusFailed(status))
			{
				if (!System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				return;
			}
			string value = Marshal.PtrToStringUTF8((nint)ptr2);
			_003CMsQuicLibraryVersion_003Ek__BackingField = $"{"libmsquic.so"} {Version} ({value})";
			if (Version < s_minMsQuicVersion)
			{
				NotSupportedReason = $"Incompatible MsQuic library version '{Version}', expecting higher than '{s_minMsQuicVersion}'.";
				if (!System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				return;
			}
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			_ = 0;
			QUIC_TLS_PROVIDER qUIC_TLS_PROVIDER = QUIC_TLS_PROVIDER.OPENSSL;
			num = 4u;
			apiTable->GetParam(null, 16777226u, &num, &qUIC_TLS_PROVIDER);
			UsesSChannelBackend = qUIC_TLS_PROVIDER == QUIC_TLS_PROVIDER.SCHANNEL;
			if (UsesSChannelBackend)
			{
				if (!IsWindowsVersionSupported())
				{
					NotSupportedReason = $"Current Windows version ({Environment.OSVersion}) is not supported by QUIC. Minimal supported version is {s_minWindowsVersion}.";
					if (!System.Net.NetEventSource.Log.IsEnabled())
					{
					}
					return;
				}
				_003CTls13ServerMayBeDisabled_003Ek__BackingField = IsTls13Disabled(isServer: true);
				_003CTls13ClientMayBeDisabled_003Ek__BackingField = IsTls13Disabled(isServer: false);
			}
			IsQuicSupported = true;
		}
		finally
		{
			MsQuicClose(apiTable);
		}
	}

	private unsafe static MsQuicApi AllocateMsQuicApi()
	{
		if (!TryOpenMsQuic(out var apiTable, out var openStatus))
		{
			throw ThrowHelper.GetExceptionForMsQuicStatus(openStatus);
		}
		return new MsQuicApi(apiTable);
	}

	private unsafe static bool TryOpenMsQuic(out QUIC_API_TABLE* apiTable, out int openStatus)
	{
		QUIC_API_TABLE* ptr = null;
		openStatus = MsQuicOpenVersion((uint)s_minMsQuicVersion.Major, &ptr);
		if (MsQuic.StatusFailed(openStatus))
		{
			apiTable = null;
			return false;
		}
		apiTable = ptr;
		return true;
	}

	private static bool IsWindowsVersionSupported()
	{
		return OperatingSystem.IsWindowsVersionAtLeast(s_minWindowsVersion.Major, s_minWindowsVersion.Minor, s_minWindowsVersion.Build, s_minWindowsVersion.Revision);
	}

	private static bool IsTls13Disabled(bool isServer)
	{
		return false;
	}

	public unsafe void SetCallbackHandler(MsQuicSafeHandle handle, void* callback, void* context)
	{
		bool success = false;
		try
		{
			handle.DangerousAddRef(ref success);
			ApiTable->SetCallbackHandler(handle.QuicHandle, callback, context);
		}
		finally
		{
			if (success)
			{
				handle.DangerousRelease();
			}
		}
	}

	public unsafe int SetParam(MsQuicSafeHandle handle, uint param, uint bufferLength, void* buffer)
	{
		bool success = false;
		try
		{
			handle.DangerousAddRef(ref success);
			return ApiTable->SetParam(handle.QuicHandle, param, bufferLength, buffer);
		}
		finally
		{
			if (success)
			{
				handle.DangerousRelease();
			}
		}
	}

	public unsafe int GetParam(MsQuicSafeHandle handle, uint param, uint* bufferLength, void* buffer)
	{
		bool success = false;
		try
		{
			handle.DangerousAddRef(ref success);
			return ApiTable->GetParam(handle.QuicHandle, param, bufferLength, buffer);
		}
		finally
		{
			if (success)
			{
				handle.DangerousRelease();
			}
		}
	}

	public unsafe int ConfigurationOpen(MsQuicSafeHandle registration, QUIC_BUFFER* alpnBuffers, uint alpnBuffersCount, QUIC_SETTINGS* settings, uint settingsSize, void* context, QUIC_HANDLE** configuration)
	{
		bool success = false;
		try
		{
			registration.DangerousAddRef(ref success);
			return ApiTable->ConfigurationOpen(registration.QuicHandle, alpnBuffers, alpnBuffersCount, settings, settingsSize, context, configuration);
		}
		finally
		{
			if (success)
			{
				registration.DangerousRelease();
			}
		}
	}

	public unsafe int ConfigurationLoadCredential(MsQuicSafeHandle configuration, QUIC_CREDENTIAL_CONFIG* config)
	{
		bool success = false;
		try
		{
			configuration.DangerousAddRef(ref success);
			return ApiTable->ConfigurationLoadCredential(configuration.QuicHandle, config);
		}
		finally
		{
			if (success)
			{
				configuration.DangerousRelease();
			}
		}
	}

	public unsafe int ConnectionOpen(MsQuicSafeHandle registration, delegate* unmanaged[Cdecl]<QUIC_HANDLE*, void*, QUIC_CONNECTION_EVENT*, int> callback, void* context, QUIC_HANDLE** connection)
	{
		bool success = false;
		try
		{
			registration.DangerousAddRef(ref success);
			return ApiTable->ConnectionOpen(registration.QuicHandle, callback, context, connection);
		}
		finally
		{
			if (success)
			{
				registration.DangerousRelease();
			}
		}
	}

	public unsafe void ConnectionShutdown(MsQuicSafeHandle connection, QUIC_CONNECTION_SHUTDOWN_FLAGS flags, ulong code)
	{
		bool success = false;
		try
		{
			connection.DangerousAddRef(ref success);
			ApiTable->ConnectionShutdown(connection.QuicHandle, flags, code);
		}
		finally
		{
			if (success)
			{
				connection.DangerousRelease();
			}
		}
	}

	public unsafe int ConnectionStart(MsQuicSafeHandle connection, MsQuicSafeHandle configuration, ushort family, sbyte* serverName, ushort serverPort)
	{
		bool success = false;
		bool success2 = false;
		try
		{
			connection.DangerousAddRef(ref success);
			configuration.DangerousAddRef(ref success2);
			return ApiTable->ConnectionStart(connection.QuicHandle, configuration.QuicHandle, family, serverName, serverPort);
		}
		finally
		{
			if (success)
			{
				connection.DangerousRelease();
			}
			if (success2)
			{
				configuration.DangerousRelease();
			}
		}
	}

	public unsafe int StreamOpen(MsQuicSafeHandle connection, QUIC_STREAM_OPEN_FLAGS flags, delegate* unmanaged[Cdecl]<QUIC_HANDLE*, void*, QUIC_STREAM_EVENT*, int> callback, void* context, QUIC_HANDLE** stream)
	{
		bool success = false;
		try
		{
			connection.DangerousAddRef(ref success);
			return ApiTable->StreamOpen(connection.QuicHandle, flags, callback, context, stream);
		}
		finally
		{
			if (success)
			{
				connection.DangerousRelease();
			}
		}
	}

	public unsafe int StreamStart(MsQuicSafeHandle stream, QUIC_STREAM_START_FLAGS flags)
	{
		bool success = false;
		try
		{
			stream.DangerousAddRef(ref success);
			return ApiTable->StreamStart(stream.QuicHandle, flags);
		}
		finally
		{
			if (success)
			{
				stream.DangerousRelease();
			}
		}
	}

	public unsafe int StreamShutdown(MsQuicSafeHandle stream, QUIC_STREAM_SHUTDOWN_FLAGS flags, ulong code)
	{
		bool success = false;
		try
		{
			stream.DangerousAddRef(ref success);
			return ApiTable->StreamShutdown(stream.QuicHandle, flags, code);
		}
		finally
		{
			if (success)
			{
				stream.DangerousRelease();
			}
		}
	}

	public unsafe int StreamSend(MsQuicSafeHandle stream, QUIC_BUFFER* buffers, uint buffersCount, QUIC_SEND_FLAGS flags, void* context)
	{
		bool success = false;
		try
		{
			stream.DangerousAddRef(ref success);
			return ApiTable->StreamSend(stream.QuicHandle, buffers, buffersCount, flags, context);
		}
		finally
		{
			if (success)
			{
				stream.DangerousRelease();
			}
		}
	}

	public unsafe int StreamReceiveSetEnabled(MsQuicSafeHandle stream, byte enabled)
	{
		bool success = false;
		try
		{
			stream.DangerousAddRef(ref success);
			return ApiTable->StreamReceiveSetEnabled(stream.QuicHandle, enabled);
		}
		finally
		{
			if (success)
			{
				stream.DangerousRelease();
			}
		}
	}

	public unsafe int ConnectionCertificateValidationComplete(MsQuicSafeHandle connection, byte result, QUIC_TLS_ALERT_CODES alert)
	{
		bool success = false;
		try
		{
			connection.DangerousAddRef(ref success);
			return ApiTable->ConnectionCertificateValidationComplete(connection.QuicHandle, result, alert);
		}
		finally
		{
			if (success)
			{
				connection.DangerousRelease();
			}
		}
	}
}
