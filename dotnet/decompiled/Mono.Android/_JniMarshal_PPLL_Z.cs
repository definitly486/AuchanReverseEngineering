using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PPLL_Z(nint jnienv, nint klass, nint p0, nint p1);
