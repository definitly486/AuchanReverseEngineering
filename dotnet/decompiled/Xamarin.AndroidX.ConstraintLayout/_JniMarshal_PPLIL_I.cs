using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPLIL_I(nint jnienv, nint klass, nint p0, int p1, nint p2);
