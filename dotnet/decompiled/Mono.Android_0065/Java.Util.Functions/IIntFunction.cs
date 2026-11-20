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
	Java.Lang.Object? Apply(int value);
}
