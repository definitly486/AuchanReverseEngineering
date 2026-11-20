using System;
using System.Runtime.CompilerServices;

namespace Websocket.Client;

internal class RequestBinaryMessage : RequestMessage
{
	public byte[] Data
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
