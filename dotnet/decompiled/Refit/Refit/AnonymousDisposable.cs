using System;

namespace Refit;

internal sealed class AnonymousDisposable : IDisposable
{
	private readonly Action block;

	public AnonymousDisposable(Action block)
	{
		this.block = block;
	}

	public void Dispose()
	{
		block();
	}
}
