using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NLog;

[Obsolete("ISuppress should be replaced with ILogger. Marked obsolete with NLog v5.3")]
[EditorBrowsable(EditorBrowsableState.Never)]
public interface ISuppress
{
	void Swallow(Action action);

	T? Swallow<T>(Func<T?> func);

	T? Swallow<T>(Func<T?> func, T? fallback);

	void Swallow(Task task);

	Task SwallowAsync(Task task);

	Task SwallowAsync(Func<Task> asyncAction);

	Task<TResult?> SwallowAsync<TResult>(Func<Task<TResult?>> asyncFunc);

	Task<TResult?> SwallowAsync<TResult>(Func<Task<TResult?>> asyncFunc, TResult? fallback);
}
