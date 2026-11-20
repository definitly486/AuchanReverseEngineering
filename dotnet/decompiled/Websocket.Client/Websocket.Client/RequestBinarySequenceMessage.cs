using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Websocket.Client;

internal class RequestBinarySequenceMessage : RequestMessage
{
	public ReadOnlySequence<byte> Data
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
