using System;
using System.Threading;

namespace Splat;

internal sealed class ActionDisposable(Action block) : IDisposable
{
	private Action _block = block;

	public static IDisposable Empty => new ActionDisposable(delegate
	{
	});

	public void Dispose()
	{
		Interlocked.Exchange(ref block, delegate
		{
		})();
	}
}
