using System;

namespace Java.Interop;

[JniTypeSignature("net/dot/jni/internal/JavaProxyThrowable", GenerateJavaPeer = false)]
internal sealed class JavaProxyThrowable : JavaException
{
	public Exception Exception { get; private set; }

	public JavaProxyThrowable(Exception exception)
		: base(GetMessage(exception))
	{
		Exception = exception;
	}

	private static string GetMessage(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		return exception.ToString();
	}
}
