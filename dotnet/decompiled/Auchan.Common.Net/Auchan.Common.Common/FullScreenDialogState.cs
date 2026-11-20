using System;
using System.Reactive.Disposables;
using System.Threading;

namespace Auchan.Common.Common;

internal sealed class FullScreenDialogState : IFullScreenDialogState
{
	private volatile int _visiblityCounter;

	public bool IsVisible => _visiblityCounter > 0;

	public IDisposable SetVisible()
	{
		Interlocked.Increment(ref _visiblityCounter);
		return Disposable.Create(delegate
		{
			Interlocked.Decrement(ref _visiblityCounter);
		});
	}
}
