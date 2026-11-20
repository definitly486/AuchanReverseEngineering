using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Util;

[Register("androidx/core/util/Consumer", "", "AndroidX.Core.Util.IConsumerInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IConsumer : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("accept", "(Ljava/lang/Object;)V", "GetAccept_Ljava_lang_Object_Handler:AndroidX.Core.Util.IConsumerInvoker, Xamarin.AndroidX.Core")]
	void Accept(Java.Lang.Object? t);
}
