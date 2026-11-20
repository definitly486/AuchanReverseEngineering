using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks;

internal static class ValueTaskExtensions
{
	public static ValueTask<T> AsCompletedValueTask<T>(this T obj)
	{
		return ValueTask.FromResult(obj);
	}
}
