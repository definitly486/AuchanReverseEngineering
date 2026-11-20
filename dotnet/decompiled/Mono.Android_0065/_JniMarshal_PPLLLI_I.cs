using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPLLLI_I(nint jnienv, nint klass, nint p0, nint p1, nint p2, int p3);
