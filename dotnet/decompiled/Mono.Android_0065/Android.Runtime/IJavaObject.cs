using System;
using Java.Interop;

namespace Android.Runtime;

[JniValueMarshaler(typeof(IJavaObjectValueMarshaler))]
public interface IJavaObject : IDisposable
{
	nint Handle { get; }
}
