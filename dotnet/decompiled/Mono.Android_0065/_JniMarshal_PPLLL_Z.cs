using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PPLLL_Z(nint jnienv, nint klass, nint p0, nint p1, nint p2);
