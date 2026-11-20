using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Bson.Utilities;

internal static class AsyncUtils
{
	public static readonly Task<bool> False = Task.FromResult(result: false);

	public static readonly Task<bool> True = Task.FromResult(result: true);

	private static Task<string> s_EmptyString;

	internal static readonly Task CompletedTask = Task.Delay(0);

	public static Task<string> EmptyString => s_EmptyString ?? (s_EmptyString = Task.FromResult(""));

	public static Task FromCanceled(this CancellationToken cancellationToken)
	{
		return new Task(delegate
		{
		}, cancellationToken);
	}
}
