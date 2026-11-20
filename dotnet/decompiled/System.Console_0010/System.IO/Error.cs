namespace System.IO;

internal static class Error
{
	internal static Exception GetReadNotSupported()
	{
		return new NotSupportedException("NotSupported_UnreadableStream");
	}

	internal static Exception GetSeekNotSupported()
	{
		return new NotSupportedException("NotSupported_UnseekableStream");
	}

	internal static Exception GetWriteNotSupported()
	{
		return new NotSupportedException("NotSupported_UnwritableStream");
	}
}
