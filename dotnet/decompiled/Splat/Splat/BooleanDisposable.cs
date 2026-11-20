using System;

namespace Splat;

internal sealed class BooleanDisposable : IDisposable
{
	private volatile bool _isDisposed;

	public bool IsDisposed => _isDisposed;

	public void Dispose()
	{
		_isDisposed = true;
	}
}
