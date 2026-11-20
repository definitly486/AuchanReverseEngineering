using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/ToLongFunction", "", "Java.Util.Functions.IToLongFunctionInvoker", ApiSince = 24)]
[JavaTypeParameters(new string[] { "T" })]
public interface IToLongFunction : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android24.0")]
	long ApplyAsLong(Java.Lang.Object? value);
}
