using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/ToDoubleFunction", "", "Java.Util.Functions.IToDoubleFunctionInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface IToDoubleFunction : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android24.0")]
	[Register("applyAsDouble", "(Ljava/lang/Object;)D", "GetApplyAsDouble_Ljava_lang_Object_Handler:Java.Util.Functions.IToDoubleFunctionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	double ApplyAsDouble(Java.Lang.Object? value);
}
