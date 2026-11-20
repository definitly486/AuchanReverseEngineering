using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLFFLL_V(nint jnienv, nint klass, nint p0, float p1, float p2, nint p3, nint p4);
