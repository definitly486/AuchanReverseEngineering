using System.Runtime.Versioning;

namespace System.Runtime.InteropServices;

public sealed class PosixSignalRegistration : IDisposable
{
	private sealed class Token
	{
	}

	private Token _token;

	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	public static PosixSignalRegistration Create(PosixSignal signal, Action<PosixSignalContext> handler)
	{
		ArgumentNullException.ThrowIfNull(handler, "handler");
		return Register(signal, handler);
	}

	private PosixSignalRegistration(Token token)
	{
		_token = token;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	~PosixSignalRegistration()
	{
	}

	private PosixSignalRegistration()
	{
	}

	private static PosixSignalRegistration Register(PosixSignal signal, Action<PosixSignalContext> handler)
	{
		throw new PlatformNotSupportedException();
	}
}
