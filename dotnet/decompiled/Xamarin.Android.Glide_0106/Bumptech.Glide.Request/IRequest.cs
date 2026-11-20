using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/Request", "", "Bumptech.Glide.Request.IRequestInvoker")]
public interface IRequest : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsAnyResourceSet
	{
		[Register("isAnyResourceSet", "()Z", "GetIsAnyResourceSetHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
		get;
	}

	bool IsCleared
	{
		[Register("isCleared", "()Z", "GetIsClearedHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
		get;
	}

	bool IsComplete
	{
		[Register("isComplete", "()Z", "GetIsCompleteHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
		get;
	}

	bool IsRunning
	{
		[Register("isRunning", "()Z", "GetIsRunningHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("begin", "()V", "GetBeginHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
	void Begin();

	[Register("clear", "()V", "GetClearHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
	void Clear();

	[Register("isEquivalentTo", "(Lcom/bumptech/glide/request/Request;)Z", "GetIsEquivalentTo_Lcom_bumptech_glide_request_Request_Handler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
	bool IsEquivalentTo(IRequest? p0);

	[Register("pause", "()V", "GetPauseHandler:Bumptech.Glide.Request.IRequestInvoker, Xamarin.Android.Glide")]
	void Pause();
}
