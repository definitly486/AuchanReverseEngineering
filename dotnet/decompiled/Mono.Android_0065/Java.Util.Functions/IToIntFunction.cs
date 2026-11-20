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
	int ApplyAsInt(Java.Lang.Object? value);
}
