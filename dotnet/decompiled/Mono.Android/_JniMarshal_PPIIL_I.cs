using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPIIL_I(nint jnienv, nint klass, int p0, int p1, nint p2);
