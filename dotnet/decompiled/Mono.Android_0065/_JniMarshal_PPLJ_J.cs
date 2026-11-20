using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate long _JniMarshal_PPLJ_J(nint jnienv, nint klass, nint p0, long p1);
