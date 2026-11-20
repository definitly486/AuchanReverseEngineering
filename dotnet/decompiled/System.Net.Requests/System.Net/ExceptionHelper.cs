namespace System.Net;

internal static class ExceptionHelper
{
	internal static NotSupportedException PropertyNotSupportedException => new NotSupportedException("net_PropertyNotSupportedException");

	internal static WebException RequestAbortedException => new WebException("net_reqaborted");

	internal static WebException TimeoutException => new WebException("net_timeout");
}
