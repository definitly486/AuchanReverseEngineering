using System;
using Android.Runtime;
using Bumptech.Glide.Load;
using Java.Interop;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/TransitionFactory", "", "Bumptech.Glide.Request.Transition.ITransitionFactoryInvoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface ITransitionFactory : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("build", "(Lcom/bumptech/glide/load/DataSource;Z)Lcom/bumptech/glide/request/transition/Transition;", "GetBuild_Lcom_bumptech_glide_load_DataSource_ZHandler:Bumptech.Glide.Request.Transition.ITransitionFactoryInvoker, Xamarin.Android.Glide")]
	ITransition? Build(DataSource? p0, bool p1);
}
