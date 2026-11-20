using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/ToIntFunction", "", "Java.Util.Functions.IToIntFunctionInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface IToIntFunction : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android24.0")]
	[Register("applyAsInt", "(Ljava/lang/Object;)I", "GetApplyAsInt_Ljava_lang_Object_Handler:Java.Util.Functions.IToIntFunctionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	int ApplyAsInt(Java.Lang.Object? value);
}
