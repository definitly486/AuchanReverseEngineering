using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Internal;

[Register("androidx/camera/core/internal/TargetConfig$Builder", "", "AndroidX.Camera.Core.Internal.ITargetConfigBuilderInvoker")]
[JavaTypeParameters(new string[] { "T", "B" })]
public interface ITargetConfigBuilder : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("setTargetClass", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetSetTargetClass_Ljava_lang_Class_Handler:AndroidX.Camera.Core.Internal.ITargetConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetTargetClass(Class p0);

	[Register("setTargetName", "(Ljava/lang/String;)Ljava/lang/Object;", "GetSetTargetName_Ljava_lang_String_Handler:AndroidX.Camera.Core.Internal.ITargetConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetTargetName(string p0);
}
