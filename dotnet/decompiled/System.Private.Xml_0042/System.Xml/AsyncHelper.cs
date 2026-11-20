using System.Threading.Tasks;

namespace System.Xml;

internal static class AsyncHelper
{
	public static bool IsSuccess(this Task task)
	{
		return task.IsCompletedSuccessfully;
	}

	public static Task CallVoidFuncWhenFinishAsync<TArg>(this Task task, Action<TArg> func, TArg arg)
	{
		if (task.IsSuccess())
		{
			func(arg);
			return Task.CompletedTask;
		}
		return task.CallVoidFuncWhenFinishCoreAsync(func, arg);
	}

	private static async Task CallVoidFuncWhenFinishCoreAsync<TArg>(this Task task, Action<TArg> func, TArg arg)
	{
		await task.ConfigureAwait(continueOnCapturedContext: false);
		func(arg);
	}
}
