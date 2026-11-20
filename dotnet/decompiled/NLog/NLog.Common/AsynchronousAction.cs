namespace NLog.Common;

public delegate void AsynchronousAction(AsyncContinuation asyncContinuation);
public delegate void AsynchronousAction<in T>(T argument, AsyncContinuation asyncContinuation);
