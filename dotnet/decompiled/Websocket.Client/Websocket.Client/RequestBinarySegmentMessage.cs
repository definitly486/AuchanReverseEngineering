using System;
using System.Runtime.CompilerServices;

namespace Websocket.Client;

internal class RequestBinarySegmentMessage : RequestMessage
{
	public ArraySegment<byte> Data
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
