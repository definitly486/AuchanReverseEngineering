using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices;

[EditorBrowsable(EditorBrowsableState.Never)]
[Experimental("SYSLIB5007", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
public static class AsyncHelpers
{
	[RequiresPreviewFeatures]
	public static void UnsafeAwaitAwaiter<TAwaiter>(TAwaiter awaiter) where TAwaiter : ICriticalNotifyCompletion
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static void AwaitAwaiter<TAwaiter>(TAwaiter awaiter) where TAwaiter : INotifyCompletion
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static void Await(Task task)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static T Await<T>(Task<T> task)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static void Await(ValueTask task)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static T Await<T>(ValueTask<T> task)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static void Await(ConfiguredTaskAwaitable configuredAwaitable)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static void Await(ConfiguredValueTaskAwaitable configuredAwaitable)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static T Await<T>(ConfiguredTaskAwaitable<T> configuredAwaitable)
	{
		throw new NotImplementedException();
	}

	[RequiresPreviewFeatures]
	public static T Await<T>(ConfiguredValueTaskAwaitable<T> configuredAwaitable)
	{
		throw new NotImplementedException();
	}
}
