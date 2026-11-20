using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace NLog;

public class NLogRuntimeException : Exception
{
	public NLogRuntimeException()
	{
	}

	public NLogRuntimeException(string message)
		: base(message)
	{
	}

	[Obsolete("Instead use string interpolation. Marked obsolete with NLog 5.0")]
	[StringFormatMethod("message")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public NLogRuntimeException(string message, params object?[] messageParameters)
		: base(string.Format(message, messageParameters))
	{
	}

	public NLogRuntimeException(string message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
