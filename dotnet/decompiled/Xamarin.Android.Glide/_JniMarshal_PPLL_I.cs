using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPLL_I(nint jnienv, nint klass, nint p0, nint p1);
