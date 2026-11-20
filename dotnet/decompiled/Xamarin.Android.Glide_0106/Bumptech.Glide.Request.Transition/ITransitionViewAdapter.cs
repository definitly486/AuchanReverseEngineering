using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/Transition$ViewAdapter", "", "Bumptech.Glide.Request.Transition.ITransitionViewAdapterInvoker")]
public interface ITransitionViewAdapter : IJavaObject, IDisposable, IJavaPeerable
{
	Drawable? CurrentDrawable
	{
		[Register("getCurrentDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetCurrentDrawableHandler:Bumptech.Glide.Request.Transition.ITransitionViewAdapterInvoker, Xamarin.Android.Glide")]
		get;
	}

	View? View
	{
		[Register("getView", "()Landroid/view/View;", "GetGetViewHandler:Bumptech.Glide.Request.Transition.ITransitionViewAdapterInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("setDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetDrawable_Landroid_graphics_drawable_Drawable_Handler:Bumptech.Glide.Request.Transition.ITransitionViewAdapterInvoker, Xamarin.Android.Glide")]
	void SetDrawable(Drawable? p0);
}
