using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPILL_I(nint jnienv, nint klass, int p0, nint p1, nint p2);
