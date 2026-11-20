using System;
using System.Threading;

namespace Microsoft.Maui.ApplicationModel;

internal static class Utils
{
	internal static CancellationToken TimeoutToken(CancellationToken cancellationToken, TimeSpan timeout)
	{
		CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
		if (timeout > TimeSpan.Zero)
		{
			cancellationTokenSource.CancelAfter(timeout);
		}
		return cancellationTokenSource.Token;
	}
}
