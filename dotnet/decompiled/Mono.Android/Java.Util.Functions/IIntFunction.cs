using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/IntFunction", "", "Java.Util.Functions.IIntFunctionInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "R" })]
public interface IIntFunction : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android24.0")]
	[Register("apply", "(I)Ljava/lang/Object;", "GetApply_IHandler:Java.Util.Functions.IIntFunctionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	Java.Lang.Object? Apply(int value);
}
