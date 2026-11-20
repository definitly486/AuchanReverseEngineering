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
	double ApplyAsDouble(Java.Lang.Object? value);
}
