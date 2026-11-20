namespace System.Threading;

internal sealed class IOCompletionCallbackHelper
{
	private readonly IOCompletionCallback _ioCompletionCallback;

	private readonly ExecutionContext _executionContext;

	public IOCompletionCallbackHelper(IOCompletionCallback ioCompletionCallback, ExecutionContext executionContext)
	{
		_ioCompletionCallback = ioCompletionCallback;
		_executionContext = executionContext;
	}
}
