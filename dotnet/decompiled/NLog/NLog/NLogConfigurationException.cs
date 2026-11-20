using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace NLog;

public class NLogConfigurationException : Exception
{
	public NLogConfigurationException()
	{
	}

	public NLogConfigurationException(string message)
		: base(message)
	{
	}

	[Obsolete("Instead use string interpolation. Marked obsolete with NLog 5.0")]
	[StringFormatMethod("message")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public NLogConfigurationException(string message, params object?[] messageParameters)
		: base(string.Format(message, messageParameters))
	{
	}

	[Obsolete("Instead use string interpolation. Marked obsolete with NLog 5.0")]
	[StringFormatMethod("message")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public NLogConfigurationException(Exception? innerException, string message, params object?[] messageParameters)
		: base(string.Format(message, messageParameters), innerException)
	{
	}

	public NLogConfigurationException(string message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
