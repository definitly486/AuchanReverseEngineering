using System;
using System.Runtime.Serialization;

namespace Auchan.Common.Networking;

internal sealed class NetworkChangedException : Exception
{
	public NetworkChangedException()
	{
	}

	public NetworkChangedException(string message)
		: base(message)
	{
	}

	public NetworkChangedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public NetworkChangedException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
