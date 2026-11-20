using System;

namespace DryIoc;

internal sealed class ScopedItemException
{
	public readonly Exception Ex;

	public ScopedItemException(Exception ex)
	{
		Ex = ex;
	}

	internal void ReThrow()
	{
		throw Ex.TryRethrowWithPreservedStackTrace();
	}
}
