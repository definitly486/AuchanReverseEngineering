using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

internal static class TaskExtensions
{
	public static Task<T> AsCompletedTask<T>(this T obj)
	{
		return Task.FromResult(obj);
	}

	public static ConfiguredTaskAwaitable DefaultAwait(this Task task)
	{
		return task.ConfigureAwait(Result.Configuration.DefaultConfigureAwait);
	}

	public static ConfiguredTaskAwaitable<T> DefaultAwait<T>(this Task<T> task)
	{
		return task.ConfigureAwait(Result.Configuration.DefaultConfigureAwait);
	}
}
