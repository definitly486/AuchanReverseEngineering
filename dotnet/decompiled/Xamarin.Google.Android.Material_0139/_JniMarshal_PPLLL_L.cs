using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLLL_L(nint jnienv, nint klass, nint p0, nint p1, nint p2);
