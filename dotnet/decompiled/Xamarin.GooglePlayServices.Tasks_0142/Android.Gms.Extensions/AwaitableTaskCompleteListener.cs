using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Extensions;

[Preserve]
internal class AwaitableTaskCompleteListener<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] TResult> : Java.Lang.Object, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable where TResult : class, IJavaObject
{
	private TaskCompletionSource<TResult> taskCompletionSource;

	[Preserve]
	public AwaitableTaskCompleteListener()
	{
		taskCompletionSource = new TaskCompletionSource<TResult>();
	}

	[Preserve]
	public void OnComplete(Android.Gms.Tasks.Task task)
	{
		if (task.IsSuccessful)
		{
			TaskCompletionSource<TResult> obj = taskCompletionSource;
			object result;
			if (task == null)
			{
				result = null;
			}
			else
			{
				Java.Lang.Object result2 = task.Result;
				result = ((result2 != null) ? Android.Runtime.Extensions.JavaCast<TResult>(result2) : null);
			}
			obj.SetResult((TResult)result);
		}
		else
		{
			taskCompletionSource.SetException(task.Exception);
		}
	}

	[Preserve]
	public Task<TResult> AwaitAsync()
	{
		return taskCompletionSource.Task;
	}

	[Preserve]
	public TaskAwaiter<TResult> GetAwaiter()
	{
		return taskCompletionSource.Task.GetAwaiter();
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
