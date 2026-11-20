using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request.Transition;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Target;

[Register("com/bumptech/glide/request/target/Target", "", "Bumptech.Glide.Request.Target.ITargetInvoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface ITarget : ILifecycleListener, IJavaObject, IDisposable, IJavaPeerable
{
	IRequest? Request
	{
		[Register("getRequest", "()Lcom/bumptech/glide/request/Request;", "GetGetRequestHandler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
		get;
		[Register("setRequest", "(Lcom/bumptech/glide/request/Request;)V", "GetSetRequest_Lcom_bumptech_glide_request_Request_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
		set;
	}

	[Register("getSize", "(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", "GetGetSize_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
	void GetSize(ISizeReadyCallback p0);

	[Register("onLoadCleared", "(Landroid/graphics/drawable/Drawable;)V", "GetOnLoadCleared_Landroid_graphics_drawable_Drawable_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
	void OnLoadCleared(Drawable? p0);

	[Register("onLoadFailed", "(Landroid/graphics/drawable/Drawable;)V", "GetOnLoadFailed_Landroid_graphics_drawable_Drawable_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
	void OnLoadFailed(Drawable? p0);

	[Register("onLoadStarted", "(Landroid/graphics/drawable/Drawable;)V", "GetOnLoadStarted_Landroid_graphics_drawable_Drawable_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
	void OnLoadStarted(Drawable? p0);

	[Register("onResourceReady", "(Ljava/lang/Object;Lcom/bumptech/glide/request/transition/Transition;)V", "GetOnResourceReady_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
	void OnResourceReady(Java.Lang.Object p0, ITransition? p1);

	[Register("removeCallback", "(Lcom/bumptech/glide/request/target/SizeReadyCallback;)V", "GetRemoveCallback_Lcom_bumptech_glide_request_target_SizeReadyCallback_Handler:Bumptech.Glide.Request.Target.ITargetInvoker, Xamarin.Android.Glide")]
	void RemoveCallback(ISizeReadyCallback p0);
}
