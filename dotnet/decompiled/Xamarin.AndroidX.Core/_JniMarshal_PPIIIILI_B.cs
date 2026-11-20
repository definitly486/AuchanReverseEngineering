using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate sbyte _JniMarshal_PPIIIILI_B(nint jnienv, nint klass, int p0, int p1, int p2, int p3, nint p4, int p5);
